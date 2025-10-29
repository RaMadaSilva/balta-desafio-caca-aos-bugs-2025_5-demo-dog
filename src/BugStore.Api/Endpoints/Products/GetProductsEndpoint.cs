using BugStore.Application.Features.Products.GetProducts;

namespace BugStore.Api.Endpoints.Products;

public static class GetProductsEndpoint
{
    public static void MapGetProductsEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/v1/products", HandleAsync)
            .WithTags("Products")
            .WithName("GetProducts")
            .Produces<List<GetProductsResponse>>(StatusCodes.Status200OK);
    }

    static async Task<IResult> HandleAsync(GetProductsHandler handler)
    {
        var request = new GetProductsRequest();
        var result = await handler.HandleAsync(request);
        return Results.Ok(result);
    }
}


