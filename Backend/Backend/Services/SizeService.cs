using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Abstractions.Size;
using Backend.Contracts;
using Backend.Entities;

namespace Backend.Services
{
    public class SizeService : ISizeService
    {
        private readonly ISizeRepository _sizeRepository;

        public SizeService(ISizeRepository sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }

        public async Task AddSizesToProduct(Guid productId, List<ProductSizeRequest> sizes)
        {
            if (sizes == null || sizes.Count == 0)
                throw new ArgumentException("Size list cannot be null or empty", nameof(sizes));

            var entities = sizes.Select(s => new ProductSizeEntity
            {
                ProductId = productId,
                SizeId = s.SizeId,
                Quantity = s.Quantity
            }).ToList();

            await _sizeRepository.AddSizesToProductAsync(productId, entities);
        }

        public async Task UpdateProductSizes(Guid productId, List<ProductSizeRequest> sizes)
        {
            if (sizes == null)
                throw new ArgumentNullException(nameof(sizes));

            var updatedEntities = sizes.Select(s => new ProductSizeEntity
            {
                ProductId = productId,
                SizeId= s.SizeId,
                Quantity = s.Quantity
            }).ToList();

            await _sizeRepository.UpdateProductSizesAsync(productId, updatedEntities);
        }

        public async Task<List<ProductSizeEntity>> GetProductSizes(Guid productId)
        {
            return await _sizeRepository.GetProductSizesAsync(productId);
        }
    }
}