

using MediatR;

namespace Shared.CQRS
{
    // Unit for returning void
    public interface ICommand : ICommand<Unit>
    {

    }
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
