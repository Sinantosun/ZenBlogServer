using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.ParentSubComments.Commands
{
    public class RemoveParentSubCommentCommand : IRequest<BaseResult<object>>
    {
        public Guid Id { get; set; }

        public RemoveParentSubCommentCommand(Guid id)
        {
            Id = id;
        }
    }
}
