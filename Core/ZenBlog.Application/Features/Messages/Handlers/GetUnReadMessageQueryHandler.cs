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
    public class GetUnReadMessageQueryHandler(IRepository<Message> _repository, IMapper _mapper) : IRequestHandler<GetUnReadMessageQuery, BaseResult<List<GetUnReadMessageQueryResult>>>
    {
        public async Task<BaseResult<List<GetUnReadMessageQueryResult>>> Handle(GetUnReadMessageQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetMultipleAsync(t => t.IsRead == false);
            var mappedValues = _mapper.Map<List<GetUnReadMessageQueryResult>>(values);
            return BaseResult<List<GetUnReadMessageQueryResult>>.Success(mappedValues);
        }

    }
}
