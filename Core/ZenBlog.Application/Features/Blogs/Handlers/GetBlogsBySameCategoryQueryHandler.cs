using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Blogs.Queries;
using ZenBlog.Application.Features.Blogs.Result;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.Blogs.Handlers
{
    public class GetBlogsBySameCategoryQueryHandler(IMapper _mapper, IRepository<Blog> _repository) : IRequestHandler<GetBlogsBySameCategoryQuery, BaseResult<List<GetBlogsBySameCategoryQueryResult>>>
    {
        public async Task<BaseResult<List<GetBlogsBySameCategoryQueryResult>>> Handle(GetBlogsBySameCategoryQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetMultipleAsync(t => t.CategoryId == request.CategoryId);
            var mappedValues = _mapper.Map<List<GetBlogsBySameCategoryQueryResult>>(values);
            return BaseResult<List<GetBlogsBySameCategoryQueryResult>>.Success(mappedValues);
        }
    }
}
