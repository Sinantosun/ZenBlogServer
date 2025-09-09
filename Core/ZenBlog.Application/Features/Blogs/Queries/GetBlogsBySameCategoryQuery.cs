using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Blogs.Result;

namespace ZenBlog.Application.Features.Blogs.Queries
{
    public class GetBlogsBySameCategoryQuery : IRequest<BaseResult<List<GetBlogsBySameCategoryQueryResult>>>
    {
        public GetBlogsBySameCategoryQuery(Guid categoryId)
        {
            CategoryId = categoryId;
        }

        public Guid CategoryId { get; set; }
    }
}
