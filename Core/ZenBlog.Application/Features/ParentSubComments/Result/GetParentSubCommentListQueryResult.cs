using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Users.Result;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.ParentSubComments.Result
{
    public class GetParentSubCommentListQueryResult : BaseDto
    {
        public string UserId { get; set; }
        public GetUsersQueryResult User { get; set; }

        public string Body { get; set; }
        public DateTime CommentDate { get; set; }
        public Guid SubCommentId { get; set; }
    }
}
