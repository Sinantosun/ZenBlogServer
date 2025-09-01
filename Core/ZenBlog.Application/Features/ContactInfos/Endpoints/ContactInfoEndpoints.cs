using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.ContactInfos.Commands;
using ZenBlog.Application.Features.ContactInfos.Queries;

namespace ZenBlog.Application.Features.ContactInfos.Endpoints
{
    public static class ContactInfoEndpoints
    {
        public static void AddContactInfoEndpoints(this IEndpointRouteBuilder app)
        {
            var contactInfo = app.MapGroup("/contactinfos").WithTags("ContactInfos");


            contactInfo.MapPost(string.Empty, async (CreateContactInfoCommand command, IMediator _mediator) =>
            {
                var response = await _mediator.Send(command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            contactInfo.MapPut(string.Empty, async (UpdateContactInfoCommand command, IMediator _mediator) =>
            {
                var response = await _mediator.Send(command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            contactInfo.MapGet(string.Empty, async (IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetContactInfoQuery());
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            contactInfo.MapDelete("{id}", async (Guid id, IMediator _mediator) =>
            {
                var response = await _mediator.Send(new RemoveContactInfoCommand(id));

                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            contactInfo.MapGet("{id}", async (Guid id, IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetContactInfoByIdQuery(id));

                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
        }
    }
}
