
using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Blogs.Queries;
using ZenBlog.Application.Features.Blogs.Result;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.Blogs.Handlers
{
    public class GetBlogListByPageQueryHandler(IRepository<Blog> _repository, IMapper _mapper) : IRequestHandler<GetBlogListByPageQuery, BaseResult<GetBlogListByPageQueryResult>>
    {
        public async Task<BaseResult<GetBlogListByPageQueryResult>> Handle(GetBlogListByPageQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetPagedAsync(request._page, request._pageSize);
            var mappedValues = _mapper.Map<List<BlogListByPage>>(values.Data);

            return new BaseResult<GetBlogListByPageQueryResult>
            {
                Data = new GetBlogListByPageQueryResult
                {
                    TotalCount = mappedValues.Count,
                    values = mappedValues
                },
            };



        }
    }
}
