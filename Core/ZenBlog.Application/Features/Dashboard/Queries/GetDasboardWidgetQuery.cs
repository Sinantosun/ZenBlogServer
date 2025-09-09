
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Dashboard.Result;

namespace ZenBlog.Application.Features.Dashboard.Queries
{
    public class GetDasboardWidgetQuery : IRequest<BaseResult<GetDasboardWidgetQueryResult>>
    {
    }
}
