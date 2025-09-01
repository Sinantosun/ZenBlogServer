using ZenBlog.Domain.Entites.Common;

namespace ZenBlog.Domain.Entites;

public class ContactInfo : BaseEntity
{
    public string Address { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string MapURL { get; set; }
}
