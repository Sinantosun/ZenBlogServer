using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Messages.Queries;
using ZenBlog.Application.Features.Messages.Result;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.Messages.Handlers
{
    public class GetReadMessageQueryHandler(IRepository<Message> _repository, IMapper _mapper) : IRequestHandler<GetReadMessageQuery, BaseResult<List<GetReadMessageQueryResult>>>
    {
        public async Task<BaseResult<List<GetReadMessageQueryResult>>> Handle(GetReadMessageQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetMultipleAsync(t => t.IsRead == true);
            var mappedValues = _mapper.Map<List<GetReadMessageQueryResult>>(values);
            return BaseResult<List<GetReadMessageQueryResult>>.Success(mappedValues);
        }
    }
}
