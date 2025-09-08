using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenBlog.Application.Features.Messages.Result
{
    public class GetReadMessageQueryResult
    {
        public string Id { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public bool IsRead { get; set; }
        public string MessageBody { get; set; }
        public virtual string MessageSubBody { get => MessageBody.Length > 50 ? MessageBody.Substring(0, MessageBody.Substring(0, 50).LastIndexOf(" ")) + "..." : MessageBody; }
    }
}
