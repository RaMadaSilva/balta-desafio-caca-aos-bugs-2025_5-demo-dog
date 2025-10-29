using BugStore.Domain.Contracts.IRepositories;
using BugStore.Domain.Entities;
using BugStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BugStore.Infrastructure.Repositories;

public class CustomerRepository 
    : BaseRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(AppDbContext context) 
        : base(context) { }
    public Task<Customer> CreateAsync(Customer customer)
    {
        Add(customer); 
        return Task.FromResult(customer);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
       var customer = await GetByCondition(x=>x.Id==id, true)
            .FirstOrDefaultAsync();

        if(customer == null) 
            return false;

        Delete(customer);
        return true;
    }

    public async Task<bool> ExistsAsync(Guid id)
        => await _context.Customers.AnyAsync(c => c.Id == id);

    public async Task<IEnumerable<Customer>> GetAllAsync(CancellationToken cancellationToken = default)
        =>  await GetAll(false).ToListAsync(cancellationToken)
            .ContinueWith(t => (IEnumerable<Customer>)t.Result);

    public Task<Customer?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => GetByCondition(c => c.Id == id, false)
            .FirstOrDefaultAsync(cancellationToken);

    public Task<Customer> UpdateAsync(Customer customer)
    {
       Update(customer);
         return  Task.FromResult(customer);
    }
}