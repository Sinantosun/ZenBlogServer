using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Domain.Entites.Common;

namespace ZenBlog.Domain.Entites
{
    public class ParentSubComment : BaseEntity
    {
        public string UserId { get; set; }
        public virtual AppUser User { get; set; }

        public string Body { get; set; }
        public DateTime CommentDate { get; set; }

        public Guid SubCommentId { get; set; }
        public virtual SubComment Comment { get; set; }
    }
}
