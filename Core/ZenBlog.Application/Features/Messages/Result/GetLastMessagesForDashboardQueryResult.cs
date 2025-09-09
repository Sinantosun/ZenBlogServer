using System.Threading.Tasks;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Messages.Result
{
    public class GetLastMessagesForDashboardQueryResult : BaseDto
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string MessageBody { get; set; }
        public bool IsRead { get; set; }
        public virtual string MessageSubBody { get => MessageBody.Length > 100 ? MessageBody.Substring(0, MessageBody.Substring(0, 100).LastIndexOf(" ")) + "..." : MessageBody; }
    }
}
