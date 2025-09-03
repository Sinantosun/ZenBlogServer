
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Users.Queries;
using ZenBlog.Application.Features.Users.Result;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.Users.Handlers
{
    public class GetUserListQueryHandler(UserManager<AppUser> _userManager, IMapper _mapper) : IRequestHandler<GetUserListQuery, BaseResult<List<GetUsersQueryResult>>>
    {
        public async Task<BaseResult<List<GetUsersQueryResult>>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var values = _userManager.Users.ToList();
            var mappedValue = _mapper.Map<List<GetUsersQueryResult>>(values);
            return BaseResult<List<GetUsersQueryResult>>.Success(mappedValue);
        }
    }
}
