
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Users.Result;

namespace ZenBlog.Application.Features.Users.Queries
{
    public class GetRoleByIdQuery :IRequest<BaseResult<GetRoleByIdQueryResult>>
    {
        public string Id { get; set; }

        public GetRoleByIdQuery(string id)
        {
            Id = id;
        }
    }
}
