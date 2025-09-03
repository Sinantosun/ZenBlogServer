
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Users.Queries;
using ZenBlog.Application.Features.Users.Result;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.Users.Handlers
{
    public class GetRoleByIdQueryHandler(IMapper _mapper, RoleManager<AppRole> _appRole) : IRequestHandler<GetRoleByIdQuery, BaseResult<GetRoleByIdQueryResult>>
    {
        public async Task<BaseResult<GetRoleByIdQueryResult>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var role = await _appRole.FindByIdAsync(request.Id);
            var mappedValue = _mapper.Map<GetRoleByIdQueryResult>(role);
            return BaseResult<GetRoleByIdQueryResult>.Success(mappedValue);
        }
    }
}
