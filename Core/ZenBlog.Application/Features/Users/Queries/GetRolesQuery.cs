using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Users.Result;

namespace ZenBlog.Application.Features.Users.Queries;

public class GetRolesQuery : IRequest<BaseResult<List<GetRolesQueryResult>>>;

