using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Users.Commands
{
    public class UpdateRoleCommand : IRequest<BaseResult<object>>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
