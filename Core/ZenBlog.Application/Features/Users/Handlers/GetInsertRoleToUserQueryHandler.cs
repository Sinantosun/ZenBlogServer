
using MediatR;
using Microsoft.AspNetCore.Identity;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Users.Queries;
using ZenBlog.Application.Features.Users.Result;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.Users.Handlers
{
    public class GetInsertRoleToUserQueryHandler(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager) : IRequestHandler<GetInsertRoleToUserQuery, BaseResult<List<GetInsertRoleToUserQueryResult>>>
    {
        public async Task<BaseResult<List<GetInsertRoleToUserQueryResult>>> Handle(GetInsertRoleToUserQuery request, CancellationToken cancellationToken)
        {
            List<GetInsertRoleToUserQueryResult> result = new List<GetInsertRoleToUserQueryResult>();
            var user = await userManager.FindByIdAsync(request._userId);
            var roles = roleManager.Roles.ToList();
            foreach (var item in roles)
            {
                result.Add(new GetInsertRoleToUserQueryResult
                {
                    IsExist = await userManager.IsInRoleAsync(user, item.Name),
                    RoleName = item.Name,
                    roleId = item.Id,
                });
            }

            return BaseResult<List<GetInsertRoleToUserQueryResult>>.Success(result);

        }
    }
}
