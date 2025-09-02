using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Blogs.Queries;
using ZenBlog.Application.Features.Blogs.Result;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.Blogs.Handlers
{
    public class GetLast5BlogQueryHandler(IRepository<Blog> _repository, IMapper _mapper) : IRequestHandler<GetLast5BlogQuery, BaseResult<List<GetLast5BlogQueryResult>>>
    {
        public async Task<BaseResult<List<GetLast5BlogQueryResult>>> Handle(GetLast5BlogQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetQuery().OrderByDescending(t => t.Id).Take(5).ToList();
            var mappedValeus = _mapper.Map<List<GetLast5BlogQueryResult>>(values);  
            
            return BaseResult<List<GetLast5BlogQueryResult>>.Success(mappedValeus);
        }
    }
}
