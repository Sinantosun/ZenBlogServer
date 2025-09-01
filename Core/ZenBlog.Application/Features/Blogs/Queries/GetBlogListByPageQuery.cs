
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Blogs.Result;

namespace ZenBlog.Application.Features.Blogs.Queries
{
    public class GetBlogListByPageQuery : IRequest<BaseResult<GetBlogListByPageQueryResult>>
    {
        public GetBlogListByPageQuery(int page = 1, int pageSize = 8)
        {
            _page = page;
            _pageSize = pageSize;
        }

        public int _page { get; set; }
        public int _pageSize { get; set; }
    }
}
