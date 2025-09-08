using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.SubComments.Commands;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.SubComments.Handlers
{
    public class RemoveManySubCommentCommandHandler(IRepository<SubComment> _repository) : IRequestHandler<RemoveManySubCommentCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveManySubCommentCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteManyWithFilterAsync(t => t.CommentId == request.Id);
            return BaseResult<object>.Success("Silindi...!");
        }
    }
}
