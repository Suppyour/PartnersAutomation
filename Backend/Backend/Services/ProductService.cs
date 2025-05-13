using Backend.Abstractions;
using Backend.Models;

namespace Backend.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<Product?>> GetProducts()
    {
        return await _productRepository.GetProducts();
    }

    public async Task<Product?> GetProductById(Guid id)
    {
        var products = await _productRepository.GetProducts();
        return products.FirstOrDefault(p => p?.Id == id);
    }

    public async Task<Guid> CreateProduct(Product? product)
    {
        return await _productRepository.CreateProduct(product);
    }

    public async Task<Guid> UpdateProducts(Guid id, string name, string description, decimal price, string category)
    {
        return await _productRepository.UpdateProduct(id, name, description, price, 0, category);
    }

    public async Task<Guid> DeleteProduct(Guid id)
    {
        return await _productRepository.DeleteProduct(id);
    }

    public async Task<List<Product?>> SearchProductsByName(string name)
    {
        return await _productRepository.SearchProductsByName(name);
    }
}