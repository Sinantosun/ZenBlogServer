using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Dashboard.Result;
using ZenBlog.Domain.Entites;
using ZenBlog.Persistence.Context;

namespace ZenBlog.Persistence.Concrete
{
    public class DashboardService(AppDbContext _context, UserManager<AppUser> _userManager) : IDashboardService
    {
        public async Task<GetDasboardWidgetQueryResult> GetDashboardCountsAsync()
        {
            return new GetDasboardWidgetQueryResult
            {
                BlogCount = await _context.Blogs.CountAsync(),
                UsersCount = await _userManager.Users.CountAsync(),
                UnReadMessageCount = await _context.Messages.Where(t => t.IsRead == false).CountAsync(),
                CategoryCount = await _context.Categories.CountAsync(),
            };
        }
    }
}
