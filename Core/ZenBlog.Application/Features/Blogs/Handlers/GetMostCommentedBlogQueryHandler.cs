using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Blogs.Queries;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.Blogs.Handlers
{
    public class GetMostCommentedBlogQueryHandler(IRepository<Blog> _blogs) : IRequestHandler<GetMostCommentedBlogQuery, BaseResult<string>>
    {
        public async Task<BaseResult<string>> Handle(GetMostCommentedBlogQuery request, CancellationToken cancellationToken)
        {
            var query = _blogs.GetQuery();
            var blogTitle = await query.OrderByDescending(t => t.Comments.Count).Select(t => t.Title).FirstOrDefaultAsync();
            return BaseResult<string>.Success(blogTitle);
        }
    }
}
