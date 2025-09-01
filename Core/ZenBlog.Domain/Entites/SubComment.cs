using ZenBlog.Domain.Entites.Common;

namespace ZenBlog.Domain.Entites
{
    public class SubComment : BaseEntity
    {
        public string UserId { get; set; }
        public virtual AppUser User { get; set; }

        public string Body { get; set; }
        public DateTime CommentDate { get; set; }

        public Guid CommentId { get; set; }
        public virtual Comment Comment { get; set; }
    }
}
