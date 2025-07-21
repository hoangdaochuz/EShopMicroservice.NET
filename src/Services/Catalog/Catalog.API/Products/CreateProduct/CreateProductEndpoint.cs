using BuildingBlocks.CQRS;
namespace Catalog.API.Products.CreateProduct;

public record CreateProductRequest(string Name, string Description, decimal Price, string ImageUrl, List<string> Categories);
public record CreateProductResponse(Guid Id, string Name, string Description, decimal Price, string ImageUrl, List<string> Categories);

public class CreateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products", async (HttpContext context, CreateProductRequest request, ISender sender)=>
        {
            CreateProductCommand command = request.Adapt<CreateProductCommand>();   
            // Send command to mediator handler
            var result = await sender.Send(command);
            var response = result.Adapt<CreateProductResponse>();
            return Results.Created($"/products/{response.Id}",response);
        }).WithName("CreateProduct")
        .WithTags("Products")
        .WithDescription("Creates a new product")
        .Produces<CreateProductResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest);
    }
}