using MediatR;
using System.Text.Json.Serialization;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Users.Result;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.Comments.Commands
{
    public record class CreateCommentCommand : IRequest<BaseResult<object>>
    {
        public string UserId { get; init; }
        public string Body { get; init; }

        [JsonIgnore]
        public DateTime CommentDate { get; init; } = DateTime.Now;

        public Guid BlogId { get; init; }
    }
}
