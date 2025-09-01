using ZenBlog.Application.Features.Blogs.Endpoints;
using ZenBlog.Application.Features.Categories.Endpoints;
using ZenBlog.Application.Features.Comments.Endpoints;
using ZenBlog.Application.Features.ContactInfos.Endpoints;
using ZenBlog.Application.Features.Messages.Endpoints;
using ZenBlog.Application.Features.Socials.Endpoints;
using ZenBlog.Application.Features.SubComments.Endpoints;
using ZenBlog.Application.Features.Users.Endpoints;

namespace ZenBlog.API.Registiration
{
    public static class EndPointRegistirations
    {
        public static void RegisterEndPoints(this IEndpointRouteBuilder app)
        {
            app.AddCategoryEndpoints();
            app.AddBlogEndpoints();
            app.AddUserEndpoints();
            app.AddCommentEndpoints();
            app.AddSubCommentEndpoints();
            app.AddContactInfoEndpoints();
            app.AddMessageEndpoints();
            app.AddSocialEndpoints();

        }
    }
}
