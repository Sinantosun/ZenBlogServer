using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Threading;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Comments.Commands;
using ZenBlog.Application.Features.Comments.Queries;
using ZenBlog.Application.Features.SubComments.Commands;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.Comments.Endpoints
{
    public static class CommentEndpoints
    {
        public static void AddCommentEndpoints(this IEndpointRouteBuilder app)
        {
            var comments = app.MapGroup("/comments").WithTags("Comments").AllowAnonymous();

            comments.MapGet(string.Empty, async (IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetCommentsQuery());
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            comments.MapGet("GetBlogCommentAnalisyts", async (IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetCommentAnalizeStatisticQuery());
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            comments.MapGet("GetCommentTranslatedText/{text}", async (string text,IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetTranslateToEnglishQuery(text));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            }).AllowAnonymous(); 

            comments.MapGet("{id}", async (Guid id, IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetCommentByIdQuery(id));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            comments.MapPost(string.Empty, async (CreateCommentCommand comment, IMediator _mediator) =>
            {
                var response = await _mediator.Send(comment);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            comments.MapPut(string.Empty, async (UpdateCommentCommand comment, IMediator _mediator) =>
            {
                var response = await _mediator.Send(comment);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            comments.MapDelete("{id}", async (Guid Id, IMediator _mediator) =>
            {
                var response = await _mediator.Send(new RemoveCommentCommand(Id));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });


            comments.MapDelete("DeleteCommentAndSubComments/{id}", async (IMediator _mediator, Guid Id) =>
            {
                await _mediator.Send(new RemoveManySubCommentCommand(Id));
                var response = await _mediator.Send(new RemoveCommentCommand(Id));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
        }


    }
}
