using ZenBlog.Domain.Entites.Common;

namespace ZenBlog.Domain.Entites;

public class Blog : BaseEntity
{
    public string Title { get; set; }
    public string CoverImage { get; set; }
    public string BlogImage { get; set; }
    public string Description { get; set; }

    public Guid CategoryId { get; set; }
    public virtual Category Category { get; set; }

    public string UserId { get; set; }
    public virtual AppUser User { get; set; }

    public virtual IList<Comment> Comments { get; set; }
}
