using Blog.Intenal.Domains.Core.Results;

namespace Blog.Internal.Applications.Core.Abstractions
{
    public interface IBaseCommand { }

    public interface ICommand : IBaseCommand { }

    public interface ICommand<out TResponse> : IBaseCommand { }

    public interface ICommandHandler<in TCommand>
      where TCommand : ICommand
    {
        Task<Result> HandlerAsync(
            TCommand command, CancellationToken cancellationToken = default);
    }

    public interface ICommandHandler<in TCommand, TResponse>
        where TCommand : ICommand<TResponse>
    {
        Task<TResponse> HandlerAsync(
            TCommand command, CancellationToken cancellationToken = default);
    }
}

