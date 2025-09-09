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
    public class GetLeastBlogQueryHandler(IRepository<Blog> _repository) : IRequestHandler<GetLeastBlogQuery, BaseResult<string>>
    {
        public async Task<BaseResult<string>> Handle(GetLeastBlogQuery request, CancellationToken cancellationToken)
        {
            var query = _repository.GetQuery();
            var minCommentCount = query.Min(b => b.Comments.Count);
            string title = await query.Where(t => t.Comments.Count == minCommentCount).Select(u => u.Title).FirstOrDefaultAsync();
            return BaseResult<string>.Success(title);
        }
    }
}
