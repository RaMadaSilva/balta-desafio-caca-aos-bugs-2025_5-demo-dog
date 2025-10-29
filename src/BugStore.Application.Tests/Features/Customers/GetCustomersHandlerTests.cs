using BugStore.Application.Features.Customers.GetCustomers;
using BugStore.Application.Tests.Helpers;
using BugStore.Domain.Contracts.IRepositories;
using FluentAssertions;
using Moq;

namespace BugStore.Application.Tests.Features.Customers.GetCustomers;

public class GetCustomersHandlerTests
{
    [Fact]
    public async Task HandleAsync_ShouldReturnListOfCustomers()
    {
        // Arrange
        var customers = new List<BugStore.Domain.Entities.Customer>
        {
            TestDataHelper.CreateCustomer(),
            TestDataHelper.CreateCustomer(),
            TestDataHelper.CreateCustomer()
        };

        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var customerRepoMock = new Mock<ICustomerRepository>();

        unitOfWorkMock.Setup(x => x.Customers).Returns(customerRepoMock.Object);
        customerRepoMock.Setup(x => x.GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(customers);

        var handler = new GetCustomersHandler(unitOfWorkMock.Object);
        var request = new GetCustomersRequest();

        // Act
        var result = await handler.HandleAsync(request);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(3);
    }

    [Fact]
    public async Task HandleAsync_WithEmptyDatabase_ShouldReturnEmptyList()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var customerRepoMock = new Mock<ICustomerRepository>();

        unitOfWorkMock.Setup(x => x.Customers).Returns(customerRepoMock.Object);
        customerRepoMock.Setup(x => x.GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<BugStore.Domain.Entities.Customer>());

        var handler = new GetCustomersHandler(unitOfWorkMock.Object);
        var request = new GetCustomersRequest();

        // Act
        var result = await handler.HandleAsync(request);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEmpty();
    }
}

