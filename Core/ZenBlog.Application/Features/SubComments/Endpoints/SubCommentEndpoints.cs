
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.SubComments.Commands;
using ZenBlog.Application.Features.SubComments.Queries;

namespace ZenBlog.Application.Features.SubComments.Endpoints
{
    public static class SubCommentEndpoints
    {
        public static void AddSubCommentEndpoints(this IEndpointRouteBuilder app)
        {
            var subComment = app.MapGroup("/subcomments").WithTags("SubComments").AllowAnonymous();

            subComment.MapPost(string.Empty, async (IMediator _mediator, CreateSubCommentCommand command) =>
            {
                var response = await _mediator.Send(command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            subComment.MapGet(string.Empty, async (IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetSubCommentsQuery());
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            subComment.MapGet("{id}", async (Guid id,IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetSubCommentByIdQuery(id));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            subComment.MapPut(string.Empty, async (UpdateSubCommentCommand command, IMediator _mediator) =>
            {
                var response = await _mediator.Send(command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            subComment.MapDelete("{id}", async (Guid id, IMediator _mediator) =>
            {
                var response = await _mediator.Send(new RemoveSubCommentCommand(id));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
        }
    }
}
