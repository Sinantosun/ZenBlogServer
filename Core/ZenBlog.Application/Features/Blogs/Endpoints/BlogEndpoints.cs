using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.Blogs.Commands;
using ZenBlog.Application.Features.Blogs.Queries;
using ZenBlog.Application.Features.Categories.Queries;

namespace ZenBlog.Application.Features.Blogs.Endpoints
{
    public static class BlogEndpoints
    {
        public static void AddBlogEndpoints(this IEndpointRouteBuilder app)
        {
            var blogs = app.MapGroup("/blogs").WithTags("Blogs");

            blogs.MapGet(string.Empty, async (IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetBlogsQuery());

                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            blogs.MapGet("{id}", async (Guid id, IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetBlogByIdQuery(id));

                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            blogs.MapGet("getBlogByPage/{page}", async (int page, IMediator _mediator) =>
            {
                if (page <= 0)
                {
                    page = 1;
                }
                var response = await _mediator.Send(new GetBlogListByPageQuery(page));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            blogs.MapGet("GetBlogsByCategoryId/{id}", async (Guid id, IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetBlogsByCategoryIdQuery(id));

                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            blogs.MapPost(string.Empty, async (CreateBlogCommand command, IMediator _mediator) =>
            {
                var response = await _mediator.Send(command);

                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            blogs.MapPut(string.Empty, async (UpdateBlogCommand command, IMediator _mediator) =>
            {
                var response = await _mediator.Send(command);

                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            blogs.MapDelete("{id}", async (Guid id, IMediator _mediator) =>
            {
                var response = await _mediator.Send(new RemoveBlogCommand(id));

                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });




        }
    }
}
