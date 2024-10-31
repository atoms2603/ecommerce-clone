using MediatR;
using Serilog;

namespace Application;
public abstract class BaseCommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, TResponse> where TCommand : BaseCommand<TResponse>
{
    protected BaseCommandHandler()
    {
    }

    public async Task<TResponse> Handle(TCommand request, CancellationToken cancellationToken)
    {
        Log.Information($"Handling command of type {typeof(TCommand).Name}");
        
        // Delegate to the actual handler logic
        return await HandleCommand(request, cancellationToken);
    }

    protected abstract Task<TResponse> HandleCommand(TCommand request, CancellationToken cancellationToken);
}

