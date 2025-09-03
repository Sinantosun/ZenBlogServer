
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Users.Commands;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.Users.Handlers
{
    public class UpdateRoleCommandHandler(IMapper _mapper, RoleManager<AppRole> _roleManager) : IRequestHandler<UpdateRoleCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleManager.FindByIdAsync(request.Id);
            role.Name = request.Name;
            var result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded)
            {
                return BaseResult<object>.Success("Rol Güncellendi...!");
            }
            var err = result.Errors.FirstOrDefault(t => t.Code == "DuplicateRoleName");
            if (err is not null)
            {
                return BaseResult<object>.Fail("Bu rol zaten ekli.");
            }
            return BaseResult<object>.Fail();
        }
    }
}
