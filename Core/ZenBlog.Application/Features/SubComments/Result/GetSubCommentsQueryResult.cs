using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Comments.Result;
using ZenBlog.Application.Features.Users.Result;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.SubComments.Result
{
    public class GetSubCommentsQueryResult : BaseDto
    {
        public string UserId { get; set; }
        public GetUsersQueryResult User { get; set; }

        public string Body { get; set; }
        public DateTime CommentDate { get; set; }

        public Guid CommentId { get; set; }
        public GetCommentsQueryResult Comment { get; set; }
    }
}
