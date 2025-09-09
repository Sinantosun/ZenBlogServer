using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Features.Dashboard.Result;

namespace ZenBlog.Application.Contracts.Persistence
{
    public interface IDashboardService
    {
        Task<GetDasboardWidgetQueryResult> GetDashboardCountsAsync();
    }
}
