using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.SubComments.Commands
{
    public class UpdateSubCommentCommand : IRequest<BaseResult<object>>
    {

        public Guid Id { get; set; }

        public string UserId { get; set; }

        public string Body { get; set; }

        [JsonIgnore]
        public DateTime CommentDate { get; set; } = DateTime.Now;

        public Guid CommentId { get; set; }
    }
}
