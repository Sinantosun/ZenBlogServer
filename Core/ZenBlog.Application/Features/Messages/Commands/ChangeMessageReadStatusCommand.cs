
using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Messages.Commands
{
    public class ChangeMessageReadStatusCommand : IRequest<BaseResult<object>>
    {
        public Guid MessageId { get; set; }

        public ChangeMessageReadStatusCommand(Guid messageId)
        {
            MessageId = messageId;
        }
    }
}
