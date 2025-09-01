
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Users.Result;
using ZenBlog.Application.Options;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Persistence.Concrete
{
    public class JwtService(UserManager<AppUser> _userManager, IOptions<JwtTokenOptions> tokenOptions) : IJwtService
    {
        private readonly JwtTokenOptions _jwttokenoptions = tokenOptions.Value;

        public async Task<GetLoginQueryResult> GenerateTokenAsync(GetUsersQueryResult result)
        {

            var user = await _userManager.FindByNameAsync(result.UserName);

            SymmetricSecurityKey symmetricSecurityKey = new(Encoding.UTF8.GetBytes(_jwttokenoptions.Key));
            var dateTimeNow = DateTime.UtcNow;

            List<Claim> claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Name,user.UserName),
                new Claim(JwtRegisteredClaimNames.Sub,user.Id),
                new Claim("FullName",string.Join(" ",user.FirstName,user.LastName)),
            };

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                 issuer: _jwttokenoptions.Issuer,
                 audience: _jwttokenoptions.Audience,
                 claims: claims,
                 notBefore: dateTimeNow,
                 expires: dateTimeNow.AddMinutes(_jwttokenoptions.ExpireInMinutes),
                 signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256));

            GetLoginQueryResult response = new GetLoginQueryResult
            {
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                ExprationTime = dateTimeNow.AddMinutes(_jwttokenoptions.ExpireInMinutes),
            };

            return response;
        }
    }
}
