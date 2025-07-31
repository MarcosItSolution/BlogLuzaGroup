namespace Blog.Internal.Applications.Core.Abstractions
{
    public interface IQuery<out TResponse>{}

    public interface IQueryHandler<in TQuery, TResponse>
        where TQuery : IQuery<TResponse>
    {
        Task<TResponse> HandlerAsync(
           TQuery query, CancellationToken cancellationToken);
    }
}