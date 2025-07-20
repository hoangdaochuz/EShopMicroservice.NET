using BuildingBlocks.CQRS;
using MediatR;

namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(string Name, string Description, decimal Price, string ImageUrl, List<string> Categories) : ICommand<CreateProductResult>;
public record CreateProductResult(Guid Id, string Name, string Description, decimal Price, string ImageUrl, List<string> Categories) ;

public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand,CreateProductResult>
{
    public Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        // implement business logic here
        throw new NotImplementedException();
    }
}