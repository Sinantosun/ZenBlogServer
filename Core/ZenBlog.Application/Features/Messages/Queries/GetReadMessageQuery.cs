
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Messages.Result;

namespace ZenBlog.Application.Features.Messages.Queries
{
    public class GetReadMessageQuery : IRequest<BaseResult<List<GetReadMessageQueryResult>>>
    {
    }
}
