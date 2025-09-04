using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.ParentSubComments.Queries;
using ZenBlog.Application.Features.ParentSubComments.Result;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.ParentSubComments.Handlers
{
    public class GetParentSubCommentListQueryHandler(IMapper _mapper, IRepository<ParentSubComment> _repository) : IRequestHandler<GetParentSubCommentListQuery, BaseResult<List<GetParentSubCommentListQueryResult>>>
    {
        public async Task<BaseResult<List<GetParentSubCommentListQueryResult>>> Handle(GetParentSubCommentListQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            var mappedValues = _mapper.Map<List<GetParentSubCommentListQueryResult>>(values);
            return BaseResult<List<GetParentSubCommentListQueryResult>>.Success(mappedValues);  
        }
    }
}
