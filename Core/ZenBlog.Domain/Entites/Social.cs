using ZenBlog.Domain.Entites.Common;

namespace ZenBlog.Domain.Entites;

public class Social : BaseEntity
{
    public string Title { get; set; }
    public string Url { get; set; }
    public string Icon { get; set; }
}
