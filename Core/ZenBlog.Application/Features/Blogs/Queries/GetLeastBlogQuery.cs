using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Blogs.Queries
{
    public class GetLeastBlogQuery : IRequest<BaseResult<string>>
    {
    }
}
