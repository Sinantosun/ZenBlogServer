using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Users.Commands;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.Users.Handlers
{
    public class CreateRoleCommandHandler(RoleManager<AppRole> _roleManager) : IRequestHandler<CreateRoleCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _roleManager.CreateAsync(new AppRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.Name,
            });
            if (result.Succeeded)
            {
                return BaseResult<object>.Success("Rol Kaydı Eklendi...!");
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
