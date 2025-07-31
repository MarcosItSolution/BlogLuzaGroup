using Blog.Intenal.Domains.Core.Abstractions;
using Blog.Intenal.Domains.Core.Results;
using Blog.Internal.Applications.Core.Abstractions;

namespace Blog.Internal.Applications.Core.Queries.Posts
{
    public class GetPostsQuery : IQuery<CustomResult>
    {
        public int PostId { get; set; }

        public sealed class GetPostsQueryHandler :
             IQueryHandler<GetPostsQuery, CustomResult>
        {
            private readonly IUnitOfWork _unitOfWork;


            public GetPostsQueryHandler(
                IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;

            }

            public async Task<CustomResult> HandlerAsync(
                GetPostsQuery query,
                CancellationToken cancellationToken)
            {
                var result = await _unitOfWork.PostRepository
                    .GetByIdAsync(query.PostId, cancellationToken);

                return result;
            }
        }
    }
}

