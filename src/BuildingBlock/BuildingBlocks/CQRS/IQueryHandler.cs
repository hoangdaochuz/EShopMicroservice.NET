using MediatR;

namespace BuildingBlocks.CQRS;

public interface IQueryHandler<in TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
where TRequest : IQuery<TResponse>
where TResponse : notnull
{
    
}

public interface IQueryHandler<in TRequest> : IQueryHandler<TRequest, Unit>
where TRequest : IQuery<Unit>
{
    
}