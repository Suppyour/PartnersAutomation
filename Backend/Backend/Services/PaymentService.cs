using System.Net;
using System.Net.Http.Headers;
using System.Text;
using Backend.Abstractions.Payment;
using Backend.Contracts;
using Backend.Entities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Backend.Services;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _repository;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<PaymentService> _logger;

    private const string ShopId = "misha";
    private const string SecretKey = "misha";
    private const string YooKassaApiUrl = "https://api.yookassa.ru/v3/payments";

    public PaymentService(
        IPaymentRepository repository,
        IHttpClientFactory httpClientFactory,
        ILogger<PaymentService> logger)
    {
        _repository = repository;
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }

    public async Task<PaymentResponse> CreatePaymentAsync(PaymentRequest request)
    {
        try
        {
            ValidatePaymentRequest(request);
            
            var client = CreateYooKassaClient();

            var requestBody = CreatePaymentRequestBody(request);
            var content = new StringContent(
                JsonConvert.SerializeObject(requestBody),
                Encoding.UTF8,
                "application/json");

            var response = await client.PostAsync(YooKassaApiUrl, content);

            var responseContent = await response.Content.ReadAsStringAsync();
            
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Ошибка API ЮКассы: {StatusCode} - {Content}", 
                    response.StatusCode, responseContent);
                throw new PaymentException($"Ошибка при обращении к API ЮКассы. Код статуса: {response.StatusCode}");
            }

            var result = JsonConvert.DeserializeObject<dynamic>(responseContent) 
                ?? throw new PaymentException("Некорректный ответ от ЮКассы");

            var payment = CreatePaymentEntity(request, result);
            await _repository.SaveAsync(payment);
            return CreatePaymentResponse(result);
        }
        catch (PaymentException)
        {
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при создании платежа");
            throw new PaymentException("Не удалось создать платеж", ex);
        }
    }

    public async Task HandleCallbackAsync(string eventType, string paymentId, string status)
    {
        try
        {
            if (string.IsNullOrEmpty(paymentId))
                throw new ArgumentNullException(nameof(paymentId), "ID платежа не может быть пустым");

            if (string.IsNullOrEmpty(status))
                throw new ArgumentNullException(nameof(status), "Статус платежа не может быть пустым");

            if (eventType == "payment.succeeded" || eventType == "payment.waiting_for_capture")
            {
                await _repository.UpdateStatusAsync(paymentId, status);
                _logger.LogInformation("Статус платежа {PaymentId} обновлен на {Status}", 
                    paymentId, status);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при обработке callback уведомления");
            throw;
        }
    }

    private HttpClient CreateYooKassaClient()
    {
        var client = _httpClientFactory.CreateClient();
        var authValue = Convert.ToBase64String(
            Encoding.ASCII.GetBytes($"{ShopId}:{SecretKey}"));
        client.DefaultRequestHeaders.Authorization = 
            new AuthenticationHeaderValue("Basic", authValue);
        return client;
    }

    private static object CreatePaymentRequestBody(PaymentRequest request)
    {
        return new
        {
            amount = new 
            { 
                value = request.Amount.ToString("F2"), 
                currency = "RUB" 
            },
            confirmation = new 
            { 
                type = "redirect", 
                return_url = "https://your-site.ru/payment-success" 
            },
            capture = true,
            description = $"Оплата заказа №{request.ProductId}"
        };
    }

    private static PaymentEntity CreatePaymentEntity(PaymentRequest request, dynamic result)
    {
        return new PaymentEntity
        {
            Id = Guid.NewGuid(),
            OrderId = request.ProductId,
            Amount = request.Amount,
            YooKassaPaymentId = result.id?.ToString() 
                ?? throw new PaymentException("В ответе отсутствует ID платежа"),
            Status = result.status?.ToString() ?? "pending",
            CreatedAt = DateTime.UtcNow
        };
    }

    private static PaymentResponse CreatePaymentResponse(dynamic result)
    {
        return new PaymentResponse
        {
            PaymentId = result.id?.ToString(),
            ConfirmationUrl = result.confirmation?.confirmation_url?.ToString(),
            Status = result.status?.ToString()
        };
    }

    private static void ValidatePaymentRequest(PaymentRequest request)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request), "Запрос на платеж не может быть null");

        if (request.Amount <= 0)
            throw new ArgumentException("Сумма платежа должна быть положительной", nameof(request.Amount));

        if (request.ProductId <= 0)
            throw new ArgumentException("Неверный ID продукта", nameof(request.ProductId));
    }
}

public class PaymentException : Exception
{
    public PaymentException(string message) : base(message) { }
    public PaymentException(string message, Exception inner) : base(message, inner) { }
}