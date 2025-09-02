
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Blogs.Result;

namespace ZenBlog.Application.Features.Blogs.Queries;

public record GetLast5BlogQuery : IRequest<BaseResult<List<GetLast5BlogQueryResult>>>;
