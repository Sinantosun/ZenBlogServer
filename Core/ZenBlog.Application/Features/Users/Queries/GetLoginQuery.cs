
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Users.Result;

namespace ZenBlog.Application.Features.Users.Queries
{
    public class GetLoginQuery : IRequest<BaseResult<GetLoginQueryResult>>
    {
        public string userName { get; set; }
        public string password { get; set; }
    }
}
