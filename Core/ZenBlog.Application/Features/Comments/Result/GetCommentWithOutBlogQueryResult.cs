using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Features.Blogs.Result;
using ZenBlog.Application.Features.Users.Result;

namespace ZenBlog.Application.Features.Comments.Result
{
    public class GetCommentWithOutBlogQueryResult
    {
        public string UserId { get; set; }
        public GetUsersQueryResult User { get; set; }

        public string Body { get; set; }
        public DateTime CommentDate { get; set; }

        //public virtual IList<SubComment> SubComments { get; set; }
        public Guid BlogId { get; set; }
    }
}
