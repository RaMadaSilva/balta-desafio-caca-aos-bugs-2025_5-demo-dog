using BugStore.Application.Mappings.Customers;
using BugStore.Domain.Contracts.IRepositories;

namespace BugStore.Application.Features.Customers.GetCustomers;

public class GetCustomersHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCustomersHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<GetCustomersResponse>> HandleAsync(GetCustomersRequest query)
    {
        var customers = await _unitOfWork.Customers.GetAllAsync();

        return customers.ToGetResponseList();
    }
}
