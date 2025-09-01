using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Categories.Commands;
using ZenBlog.Application.Features.Users.Commands;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.Users.Handlers
{
    public class CreateUserCommandHandler(UserManager<AppUser> _userManager,IMapper _mapper) : IRequestHandler<CreateUserCommand, BaseResult<bool>>
    {
        public async Task<BaseResult<bool>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new AppUser
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                UserName = request.UserName,
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                return BaseResult<bool>.Fail(result.Errors);
            }

            return BaseResult<bool>.Success(true);
        }
    }
}
