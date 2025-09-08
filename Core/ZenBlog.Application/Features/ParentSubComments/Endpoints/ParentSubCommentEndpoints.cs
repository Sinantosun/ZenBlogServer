
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.ParentSubComments.Commands;
using ZenBlog.Application.Features.ParentSubComments.Queries;

namespace ZenBlog.Application.Features.ParentSubComments.Endpoints
{
    public static class ParentSubCommentEndpoints
    {
        public static void AddParentSubCommentEndpoints(this IEndpointRouteBuilder app)
        {
            var parentSubComment = app.MapGroup("/parentSubComments").WithTags("ParentSubComment").AllowAnonymous();

            parentSubComment.MapPost(string.Empty, async (CreateParentSubCommentCommand command,IMediator _mediator) =>
            {
                var response = await _mediator.Send(command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            parentSubComment.MapGet(string.Empty, async (IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetParentSubCommentListQuery());
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            parentSubComment.MapDelete("{id}", async (Guid id,IMediator _mediator) =>
            {
                var response = await _mediator.Send(new RemoveParentSubCommentCommand(id));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });



        }
    }
}
