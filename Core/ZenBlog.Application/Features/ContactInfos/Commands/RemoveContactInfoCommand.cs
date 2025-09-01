
using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.ContactInfos.Commands;

public record RemoveContactInfoCommand(Guid id) : IRequest<BaseResult<object>>;

