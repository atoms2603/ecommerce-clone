using MediatR;

namespace Application;
public abstract class BaseQuery<TResponse> : IRequest<TResponse>
{
}