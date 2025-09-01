using ZenBlog.Domain.Entites.Common;

namespace ZenBlog.Domain.Entites
{
    public class Comment : BaseEntity
    {
        public string UserId { get; set; }
        public virtual AppUser User { get; set; }

        public string Body { get; set; }
        public DateTime CommentDate { get; set; }

        public virtual IList<SubComment> SubComments { get; set; }

        public Guid BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }
}
