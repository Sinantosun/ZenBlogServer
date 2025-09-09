using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Categories.Result;
using ZenBlog.Application.Features.Comments.Result;
using ZenBlog.Application.Features.Users.Result;

namespace ZenBlog.Application.Features.Blogs.Result
{
    public class GetBlogsBySameCategoryQueryResult : BaseDto
    {
        public string Title { get; set; }
        public string CoverImage { get; set; }
        public string Description { get; set; }

        public Guid CategoryId { get; set; }
        public GetUsersQueryResult User { get; set; }
        public string UserId { get; set; }

        public virtual string SubDescription { get => Description.Length > 50 ? Description.Substring(0, Description.Substring(0, 50).LastIndexOf(" ")) + "..." : Description; }

    }
}
