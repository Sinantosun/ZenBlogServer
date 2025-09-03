using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Users.Queries;
using ZenBlog.Application.Features.Users.Result;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.Users.Handlers
{
    public class GetRolesQueryHandler(RoleManager<AppRole> _roleManager, IMapper _mapper) : IRequestHandler<GetRolesQuery, BaseResult<List<GetRolesQueryResult>>>
    {
        public async Task<BaseResult<List<GetRolesQueryResult>>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            var values = _roleManager.Roles.ToList();
            var mappedValues = _mapper.Map<List<GetRolesQueryResult>>(values);
            return BaseResult<List<GetRolesQueryResult>>.Success(mappedValues);
        }
    }
}
