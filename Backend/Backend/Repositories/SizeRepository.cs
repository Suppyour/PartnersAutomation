using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Abstractions.Size;
using Backend.Entities;

namespace Backend.Repositories
{
    public class SizeRepository : ISizeRepository
    {
        private readonly MyDbContext _context;

        public SizeRepository(MyDbContext context)
        {
            _context = context;
        }

        // ------------------------------
        // Работа с SizeEntity
        // ------------------------------
        
        public async Task<SizeEntity> GetByIdAsync(Guid id)
        {
            return await _context.Sizes.FindAsync(id);
        }

        public async Task<IEnumerable<SizeEntity>> GetAllAsync()
        {
            return await _context.Sizes.ToListAsync();
        }

        public async Task AddAsync(SizeEntity size)
        {
            await _context.Sizes.AddAsync(size);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SizeEntity size)
        {
            _context.Sizes.Update(size);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var size = await GetByIdAsync(id);
            if (size != null)
            {
                _context.Sizes.Remove(size);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _context.Sizes.AnyAsync(s => s.Id == id);
        }

        // ------------------------------
        // Работа с ProductSizeEntity
        // ------------------------------

        public async Task AddSizesToProductAsync(Guid productId, List<ProductSizeEntity> sizes)
        {
            if (sizes == null || sizes.Count == 0)
                return;

            foreach (var size in sizes)
            {
                size.ProductId = productId; // на всякий случай принудительно
                _context.ProductSizes.Add(size);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<List<ProductSizeEntity>> GetProductSizesAsync(Guid productId)
        {
            return await _context.ProductSizes
                .Where(ps => ps.ProductId == productId)
                .ToListAsync();
        }

        public async Task UpdateProductSizesAsync(Guid productId, List<ProductSizeEntity> updatedSizes)
        {
            // Удалить старые размеры
            var existing = await _context.ProductSizes
                .Where(ps => ps.ProductId == productId)
                .ToListAsync();

            _context.ProductSizes.RemoveRange(existing);

            // Добавить новые
            foreach (var size in updatedSizes)
            {
                size.ProductId = productId;
                _context.ProductSizes.Add(size);
            }

            await _context.SaveChangesAsync();
        }
    }
}
