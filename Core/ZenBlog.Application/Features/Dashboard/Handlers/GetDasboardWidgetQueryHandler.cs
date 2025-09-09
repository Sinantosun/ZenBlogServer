using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Dashboard.Queries;
using ZenBlog.Application.Features.Dashboard.Result;

namespace ZenBlog.Application.Features.Dashboard.Handlers
{
    public class GetDasboardWidgetQueryHandler(IDashboardService _dashboardService) : IRequestHandler<GetDasboardWidgetQuery, BaseResult<GetDasboardWidgetQueryResult>>
    {
        public async Task<BaseResult<GetDasboardWidgetQueryResult>> Handle(GetDasboardWidgetQuery request, CancellationToken cancellationToken)
        {
            var value = await _dashboardService.GetDashboardCountsAsync();
            return BaseResult<GetDasboardWidgetQueryResult>.Success(value);
        }
    }
}
