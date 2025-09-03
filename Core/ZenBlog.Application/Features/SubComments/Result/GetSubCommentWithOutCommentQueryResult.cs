using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Features.Comments.Result;
using ZenBlog.Application.Features.Users.Result;

namespace ZenBlog.Application.Features.SubComments.Result
{
    public class GetSubCommentWithOutCommentQueryResult
    {
        public string UserId { get; set; }
        public GetUsersQueryResult User { get; set; }

        public string Body { get; set; }
        public DateTime CommentDate { get; set; }

        public Guid CommentId { get; set; }
    }
}
