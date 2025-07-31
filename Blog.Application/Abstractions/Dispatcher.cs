using Microsoft.Extensions.DependencyInjection;

namespace Blog.Internal.Applications.Core.Abstractions
{
    public class Dispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public Dispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResult> QueryAsync<TQuery, TResult>(
            TQuery query, CancellationToken cancellationToken = default)
                where TQuery : IQuery<TResult>
        {
            var handler = _serviceProvider.GetRequiredService<IQueryHandler<TQuery, TResult>>();
            return await handler.HandlerAsync(query, cancellationToken);
        }

        public async Task CommandAsync<TCommand>(
            TCommand command, CancellationToken cancellationToken = default)
                where TCommand : ICommand
        {
            var handler = _serviceProvider.GetRequiredService<ICommandHandler<TCommand>>();
            await handler.HandlerAsync(command, cancellationToken);
        }

        public async Task<TResult> CommandAsync<TCommand, TResult>(
           TCommand command, CancellationToken cancellationToken = default)
               where TCommand : ICommand<TResult>
        {
            var handler = _serviceProvider.GetRequiredService<ICommandHandler<TCommand, TResult>>();
            return await handler.HandlerAsync(command, cancellationToken);
        }
    }
}

