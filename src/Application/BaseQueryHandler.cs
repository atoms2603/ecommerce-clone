using MediatR;
using Serilog;

namespace Application;
public abstract class BaseQueryHandler<TCommand, TResponse> : IRequestHandler<TCommand, TResponse> where TCommand : BaseQuery<TResponse>
{
    protected BaseQueryHandler()
    {
    }

    public async Task<TResponse> Handle(TCommand request, CancellationToken cancellationToken)
    {
        Log.Information($"Handling command of type {typeof(TCommand).Name}");
        
        // Delegate to the actual handler logic
        return await HandleQuery(request, cancellationToken);
    }

    protected abstract Task<TResponse> HandleQuery(TCommand request, CancellationToken cancellationToken);
}

