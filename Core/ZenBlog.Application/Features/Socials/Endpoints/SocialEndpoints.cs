using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.Socials.Commands;
using ZenBlog.Application.Features.Socials.Queries;

namespace ZenBlog.Application.Features.Socials.Endpoints
{
    public static class SocialEndpoints
    {
        public static void AddSocialEndpoints(this IEndpointRouteBuilder app)
        {
            var socials = app.MapGroup("/socials").WithTags("socials");

            socials.MapGet(string.Empty, async (IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetSocialQuery());
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            socials.MapGet("{id}", async (Guid id, IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetSocialByIdQuery(id));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            }).AllowAnonymous();

            socials.MapPost(string.Empty, async (CreateSocialCommand Social, IMediator _mediator) =>
            {
                var response = await _mediator.Send(Social);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            socials.MapPut(string.Empty, async (UpdateSocialCommand Social, IMediator _mediator) =>
            {
                var response = await _mediator.Send(Social);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            socials.MapDelete("{id}", async (Guid Id, IMediator _mediator) =>
            {
                var response = await _mediator.Send(new RemoveSocialCommand(Id));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
        }


    }
}
