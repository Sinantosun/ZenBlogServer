
using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Categories.Queries;
using ZenBlog.Application.Features.Categories.Result;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.Categories.Handlers
{
    public class GetCategoryListByPageQueryHandler(IRepository<Category> _repository, IMapper _mapper) : IRequestHandler<GetCategoryListByPageQuery, BaseResult<GetCategoryListByPageQueryResult>>
    {
        public async Task<BaseResult<GetCategoryListByPageQueryResult>> Handle(GetCategoryListByPageQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetPagedAsync(request._page, request._pageSize);
            var mappedValues = _mapper.Map<List<CategoryListByPage>>(values.Data);

            return new BaseResult<GetCategoryListByPageQueryResult>
            {
                Data = new GetCategoryListByPageQueryResult
                {
                    TotalCount = values.TotalCount,
                    values = mappedValues
                }
            };

        }
    }
}
