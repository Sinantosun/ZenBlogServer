
using MediatR;
using Microsoft.AspNetCore.Identity;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Users.Commands;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.Users.Handlers
{
    public class AddRoleToUserCommandHandler(UserManager<AppUser> _usermanger) : IRequestHandler<AddRoleToUserCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(AddRoleToUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _usermanger.FindByIdAsync(request.UserId);
            if (user == null)
                return BaseResult<object>.NotFound("Kullanıcı bulunamadı.");

            var userActiveRoles = await _usermanger.GetRolesAsync(user);

            var rolesToRemove = userActiveRoles.Except(request.RoleList).ToList();
            if (rolesToRemove.Any())
                await _usermanger.RemoveFromRolesAsync(user, rolesToRemove);

            var rolesToAdd = request.RoleList.Except(userActiveRoles).ToList();
            if (rolesToAdd.Any())
                await _usermanger.AddToRolesAsync(user, rolesToAdd);

            return BaseResult<object>.Success("Değişiklikler kaydedildi.");
        }
    }
}
