
namespace ZenBlog.Application.Features.Dashboard.Result
{
    public class GetDasboardWidgetQueryResult
    {
        public int BlogCount { get; set; }
        public int UsersCount { get; set; }
        public int UnReadMessageCount { get; set; }
        public int CategoryCount { get; set; }
    }
}
