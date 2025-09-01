
using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Categories.Queries;
using ZenBlog.Application.Features.Categories.Result;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.Categories.Handlers
{
    public class GetCategoryByIdQueryHandler(IRepository<Category> _category, IMapper _mapper) : IRequestHandler<GetCategoryByIdQuery, BaseResult<GetCategoryByIdQueryResult>>
    {
        public async Task<BaseResult<GetCategoryByIdQueryResult>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _category.GetByIdAsync(request.id);
            if (category is null)
            {
                return BaseResult<GetCategoryByIdQueryResult>.NotFound("Kategori Bulunamadı..");
            }
            var response = _mapper.Map<GetCategoryByIdQueryResult>(category);
            return  BaseResult<GetCategoryByIdQueryResult>.Success(response);
        }
    }
}
