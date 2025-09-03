using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.Categories.Commands;
using ZenBlog.Application.Features.Categories.Queries;

namespace ZenBlog.Application.Features.Categories.Endpoints
{
    public static class CategoryEndpoints
    {
        public static void AddCategoryEndpoints(this IEndpointRouteBuilder app)
        {
            var categories = app.MapGroup("/categories").WithTags("Categories");
            categories.MapGet(string.Empty, async (IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetCategoryQuery());
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            }).AllowAnonymous();

            categories.MapGet("{id}", async (Guid id, IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetCategoryByIdQuery(id));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            }).AllowAnonymous(); ;

            categories.MapGet("getCategoriesByPage/{page}", async (int page, IMediator _mediator) =>
            {
                if (page <= 0)
                {
                    page = 1;
                }
                var response = await _mediator.Send(new GetCategoryListByPageQuery(page));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            }).AllowAnonymous(); ;

            categories.MapPost(string.Empty, async (CreateCategoryCommand command, IMediator _mediator) =>
            {
                var response = await _mediator.Send(command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            categories.MapPut(string.Empty, async (UpdateCategoryCommand command, IMediator _mediator) =>
            {
                var response = await _mediator.Send(command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            categories.MapDelete("{id}", async (Guid id, IMediator _mediator) =>
            {
                var response = await _mediator.Send(new RemoveCategoryCommand(id));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
        }
    }
}
