using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Blogs.Result;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.Categories.Result
{
    public class GetCategoryQueryResult : BaseDto
    {
        public string CategoryName { get; set; }
        public List<GetBlogsQueryResult> Blogs { get; set; }
    }
}
