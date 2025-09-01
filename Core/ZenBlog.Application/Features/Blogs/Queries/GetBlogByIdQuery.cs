
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Blogs.Result;

namespace ZenBlog.Application.Features.Blogs.Queries
{
    public record GetBlogByIdQuery(Guid id) : IRequest<BaseResult<GetBlogByIdQueryResult>>;

}
