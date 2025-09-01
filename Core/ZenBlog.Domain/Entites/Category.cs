using ZenBlog.Domain.Entites.Common;

namespace ZenBlog.Domain.Entites;

public class Category : BaseEntity
{
    public string CategoryName { get; set; }

    public virtual IList<Blog> Blogs { get; set; }
}
