using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.Messages.Commands;
using ZenBlog.Application.Features.Messages.Queries;

namespace ZenBlog.Application.Features.Messages.Endpoints
{
    public static class MessageEndpoints
    {
        public static void AddMessageEndpoints(this IEndpointRouteBuilder app)
        {
            var Message = app.MapGroup("/messages").WithTags("Messages");


            Message.MapPost(string.Empty, async (CreateMessageCommand command, IMediator _mediator) =>
            {
                var response = await _mediator.Send(command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            Message.MapPut(string.Empty, async (UpdateMessageCommand command, IMediator _mediator) =>
            {
                var response = await _mediator.Send(command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            Message.MapGet(string.Empty, async (IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetMessageQuery());
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            Message.MapDelete("{id}", async (Guid id, IMediator _mediator) =>
            {
                var response = await _mediator.Send(new RemoveMessageCommand(id));

                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            Message.MapGet("{id}", async (Guid id, IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetMessageByIdQuery(id));

                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
        }
    }
}
