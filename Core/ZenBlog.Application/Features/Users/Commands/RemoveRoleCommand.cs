using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Users.Commands
{
    public class RemoveRoleCommand : IRequest<BaseResult<object>>
    {
        public string Id { get; set; }

        public RemoveRoleCommand(string id)
        {
            Id = id;
        }
    }
}
