using Scalar.AspNetCore;
using System.Text.Json.Serialization;
using ZenBlog.API.CustomMiddlewares;
using ZenBlog.API.Registiration;
using ZenBlog.Application.Extensions;
using ZenBlog.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceRegistrations(builder.Configuration);
builder.Services.AddApplicatonRegistrations(builder.Configuration);


builder.Services.AddCors(option =>
{
    option.AddPolicy("MyCorsPolicy", cors =>
    {
        cors.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});

builder.Services.ConfigureHttpJsonOptions(cfg =>
{
    cfg.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});


builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseMiddleware<CustomExeptionHandlingMiddleware>();

app.UseCors("MyCorsPolicy");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapGroup("/api").RegisterEndPoints();
app.Run();
