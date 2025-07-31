using Blog.Intenal.Domains.Core.Abstractions;
using Blog.Intenal.Domains.Core.Results;
using Blog.Internal.Applications.Core.Abstractions;

namespace Blog.Internal.Applications.Core.Queries.Posts
{
    public sealed class GetPostsByIdQuery : IQuery<CustomResult>
    {

        public sealed class GetPostsByIdQueryHandler :
            IQueryHandler<GetPostsByIdQuery, CustomResult>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetPostsByIdQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<CustomResult> HandlerAsync(
                GetPostsByIdQuery query,
                CancellationToken cancellationToken)
            {
                var response = await _unitOfWork.PostRepository
                    .GetsAsync(cancellationToken: cancellationToken);

                return response;
            }
        }
    }
}

