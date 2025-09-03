using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Users.Commands
{
    public class AddRoleToUserCommand : IRequest<BaseResult<object>>
    {

        public string UserId { get; set; }
        public List<string> RoleList { get; set; }
    }
}
