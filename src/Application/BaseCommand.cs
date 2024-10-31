using MediatR;

namespace Application;
public abstract class BaseCommand<TResponse> : IRequest<TResponse>
{
}