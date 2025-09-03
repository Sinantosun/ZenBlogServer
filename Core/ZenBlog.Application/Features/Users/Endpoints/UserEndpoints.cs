using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.Users.Commands;
using ZenBlog.Application.Features.Users.Queries;

namespace ZenBlog.Application.Features.Users.Endpoints
{
    public static class UserEndpoints
    {
        public static void AddUserEndpoints(this IEndpointRouteBuilder app)
        {
            var users = app.MapGroup("/users").WithTags("Users");

            users.MapPost("Register", async (IMediator _mediator, CreateUserCommand _command) =>
            {
                var response = await _mediator.Send(_command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            }).AllowAnonymous();

            users.MapPost("Login", async (IMediator _mediator, GetLoginQuery _command) =>
            {
                var response = await _mediator.Send(_command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            }).AllowAnonymous();

            users.MapPost("AddRole", async (IMediator _mediator, CreateRoleCommand _command) =>
            {
                var response = await _mediator.Send(_command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            users.MapGet("GetUsers", async (IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetUserListQuery());
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            users.MapDelete("RemoveRole/{id}", async (IMediator _mediator, string id) =>
            {
                var response = await _mediator.Send(new RemoveRoleCommand(id));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            users.MapPut("UpdateRole", async (IMediator _mediator, UpdateRoleCommand _command) =>
            {
                var response = await _mediator.Send(_command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            users.MapGet("GetUserAndRoles/{id}", async (IMediator _mediator, string id) =>
            {
                var response = await _mediator.Send(new GetInsertRoleToUserQuery(id));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            users.MapPost("AddRoleToUser", async (IMediator _mediator, AddRoleToUserCommand command) =>
            {
                var response = await _mediator.Send(command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });



            users.MapGet("GetRoles", async (IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetRolesQuery());
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            users.MapGet("GetRole/{id}", async (string id, IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetRoleByIdQuery(id));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
        }
    }
}
