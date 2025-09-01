using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.Blogs.Commands
{
    public class CreateBlogCommand : IRequest<BaseResult<bool>>
    {
        public string? Title { get; set; }
        public string? CoverImage { get; set; }
        public string? BlogImage { get; set; }
        public string? Description { get; set; }

        public string? CategoryId { get; set; }
        public string? UserId { get; set; }
    }
}
