using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Features.Dashboard.Queries;

namespace ZenBlog.Application.Features.Dashboard.Endpoints
{
    public static class DashboardEndpoints
    {
        public static void AddDashboardEndpoints(this IEndpointRouteBuilder app)
        {
            var dashboard = app.MapGroup("/dashboard").WithTags("Dashboard");
            dashboard.MapGet(string.Empty, async (IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetDasboardWidgetQuery());
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response); 
            });
        }
    }
}
