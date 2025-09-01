using Azure;
using FluentValidation;
using ZenBlog.Application.Base;

namespace ZenBlog.API.CustomMiddlewares
{
    public class CustomExeptionHandlingMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (ValidationException ex)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";

                var response = new BaseResult<object>()
                {
                    Errors = ex.Errors.GroupBy(t => t.PropertyName).Select(t => new Error
                    {
                        PropertyName = t.Key,
                        ErrorMessage = t.Select(u=>u.ErrorMessage).FirstOrDefault()
                    }).ToList()
                };

                await context.Response.WriteAsJsonAsync(response);
            }
            catch(Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsJsonAsync(BaseResult<object>.Fail());
            }
        }
    }
}
