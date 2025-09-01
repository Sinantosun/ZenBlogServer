
using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Blogs.Queries;
using ZenBlog.Application.Features.Blogs.Result;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.Blogs.Handlers;

public class GetBlogsByCategoryIdQueryHandler(IRepository<Blog> _repository,IMapper _mapper) : IRequestHandler<GetBlogsByCategoryIdQuery, BaseResult<List<GetBlogsByCategoryIdQueryResult>>>
{
    public async Task<BaseResult<List<GetBlogsByCategoryIdQueryResult>>> Handle(GetBlogsByCategoryIdQuery request, CancellationToken cancellationToken)
    {
        var query = await _repository.GetMultipleAsync(t => t.CategoryId == request.id);
        var values =  _mapper.Map<List<GetBlogsByCategoryIdQueryResult>>(query);

        return BaseResult<List<GetBlogsByCategoryIdQueryResult>>.Success(values);
    }
}
