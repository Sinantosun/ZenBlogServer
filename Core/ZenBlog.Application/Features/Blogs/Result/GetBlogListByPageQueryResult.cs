
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Categories.Result;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.Blogs.Result
{
    public class GetBlogListByPageQueryResult 
    {
        public List<BlogListByPage> values { get; set; }
        public int TotalCount { get; set; }
    }

    public class BlogListByPage : BaseDto
    {
        public string Title { get; set; }
        public string CoverImage { get; set; }
        public string BlogImage { get; set; }
        public string Description { get; set; }

        public GetCategoryQueryResult Category { get; set; }

        public string UserId { get; set; }
    }
}
