
using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Users.Commands
{
    public class CreateRoleCommand : IRequest<BaseResult<object>>
    {
        public string Name { get; set; }
    }
}
