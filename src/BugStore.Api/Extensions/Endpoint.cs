using BugStore.Api.Endpoints.Customers;
using BugStore.Api.Endpoints.Orders;
using BugStore.Api.Endpoints.Products;

namespace BugStore.Api.Extensions; 

public static class Endpoint
{
    public static void MapEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", () => "BugStore API - Hello World!");

        // Registrar Endpoints - Customers
        app.MapCreateCustomerEndpoint();
        app.MapUpdateCustomerEndpoint();
        app.MapDeleteCustomerEndpoint();
        app.MapGetCustomersEndpoint();
        app.MapGetByIdCustomerEndpoint();

        // Registrar Endpoints - Products
        app.MapCreateProductEndpoint();
        app.MapUpdateProductEndpoint();
        app.MapDeleteProductEndpoint();
        app.MapGetProductsEndpoint();
        app.MapGetProductByIdEndpoint();

        // Registrar Endpoints - Orders
        app.MapCreateOrderEndpoint();
        app.MapGetOrderByIdEndpoint();
    }
}
