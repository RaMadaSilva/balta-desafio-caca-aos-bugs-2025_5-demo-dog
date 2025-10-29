using BugStore.Domain.Entities;

namespace BugStore.Domain.Contracts.IRepositories; 

public interface IOrderRepository
{
    Task<Order?> GetByIdAsync(Guid id);
    Task<Order> CreateAsync(Order order);
}
