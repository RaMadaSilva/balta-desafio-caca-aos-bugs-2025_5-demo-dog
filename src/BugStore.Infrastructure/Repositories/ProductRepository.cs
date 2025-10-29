using BugStore.Domain.Contracts.IRepositories;
using BugStore.Domain.Entities;
using BugStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BugStore.Infrastructure.Repositories; 

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) 
        : base(context) { }

    public Task<Product> CreateAsync(Product product)
    {
        Add(product); 
        return Task.FromResult(product);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
       var product = await GetByCondition(x=>x.Id==id, true)
            .FirstOrDefaultAsync();

        if(product == null) 
            return false;

        Delete(product);
        return true;
    }

    public async Task<bool> ExistsAsync(Guid id)
        => await _context.Products.AnyAsync(p => p.Id == id);

    public async Task<IEnumerable<Product>> GetAllAsync()
        =>  await GetAll(false).ToListAsync()
            .ContinueWith(t => (IEnumerable<Product>)t.Result);

    public Task<Product?> GetByIdAsync(Guid id)
        => GetByCondition(p => p.Id == id, false)
            .FirstOrDefaultAsync();

    public async Task<IEnumerable<Product>> GetByIdsAsync(IEnumerable<Guid> ids)
        => await GetByCondition(p => ids.Contains(p.Id), false)
            .ToListAsync();

    public Task<Product> UpdateAsync(Product product)
    {
       Update(product);
         return  Task.FromResult(product);
    }
}
