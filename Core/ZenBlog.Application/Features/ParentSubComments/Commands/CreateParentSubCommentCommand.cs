using MediatR;
using System.Text.Json.Serialization;
using ZenBlog.Application.Base;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.ParentSubComments.Commands;

public class CreateParentSubCommentCommand : IRequest<BaseResult<object>>
{
    public string UserId { get; set; }
    public string Body { get; set; }
    [JsonIgnore]
    public DateTime CommentDate { get; set; } = DateTime.Now;

    public Guid SubCommentId { get; set; }
}
