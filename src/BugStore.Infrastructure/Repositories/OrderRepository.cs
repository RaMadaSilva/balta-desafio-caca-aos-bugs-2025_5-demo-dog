using BugStore.Domain.Contracts.IRepositories;
using BugStore.Domain.Entities;
using BugStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BugStore.Infrastructure.Repositories; 

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(AppDbContext context) 
        : base(context) { }

    public Task<Order> CreateAsync(Order order)
    {
        Add(order); 
        return Task.FromResult(order);
    }

    public Task<Order?> GetByIdAsync(Guid id)
        => GetByCondition(o => o.Id == id, false)
            .FirstOrDefaultAsync();
}
