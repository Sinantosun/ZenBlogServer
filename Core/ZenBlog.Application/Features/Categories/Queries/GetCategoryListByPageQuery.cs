using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Categories.Result;

namespace ZenBlog.Application.Features.Categories.Queries;

public class GetCategoryListByPageQuery : IRequest<BaseResult<GetCategoryListByPageQueryResult>>
{
    public GetCategoryListByPageQuery(int page = 1, int pageSize = 8)
    {
        _page = page;
        _pageSize = pageSize;
    }

    public int _page { get; set; }
    public int _pageSize { get; set; }
}
