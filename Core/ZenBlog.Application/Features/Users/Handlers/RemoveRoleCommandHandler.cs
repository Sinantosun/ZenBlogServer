using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Users.Commands;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.Users.Handlers
{
    public class RemoveRoleCommandHandler(RoleManager<AppRole> _roleManager) : IRequestHandler<RemoveRoleCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleManager.FindByIdAsync(request.Id);

            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return BaseResult<object>.Success("Rol Kaydı Silindi...!");
            }
            return BaseResult<object>.Fail();
        }
    }
}
