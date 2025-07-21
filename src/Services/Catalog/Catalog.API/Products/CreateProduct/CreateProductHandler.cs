using BuildingBlocks.CQRS;
using Catalog.API.Models;
using MediatR;

namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(string Name, string Description, decimal Price, string ImageUrl, List<string> Categories) : ICommand<CreateProductResult>;
public record CreateProductResult(Guid Id, string Name, string Description, decimal Price, string ImageUrl, List<string> Categories) ;

public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand,CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        // implement business logic here
        Product product = new Product();
        product.Id = Guid.NewGuid();
        product.Name = request.Name;
        product.Description = request.Description;
        product.Price = request.Price;
        product.ImageUrl = request.ImageUrl;
        product.Categories = request.Categories;
        
        // Save to database
        
        return new CreateProductResult(product.Id, product.Name, product.Description, product.Price, product.ImageUrl, product.Categories);
    }
}