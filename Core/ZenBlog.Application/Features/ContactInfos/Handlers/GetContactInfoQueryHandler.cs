

using AutoMapper;
using MediatR;
using System.Collections.Generic;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.ContactInfos.Queries;
using ZenBlog.Application.Features.ContactInfos.Result;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.ContactInfos.Handlers
{
    public class GetContactInfoQueryHandler(IRepository<ContactInfo> _repository, IMapper _mapper) : IRequestHandler<GetContactInfoQuery, BaseResult<List<GetContactInfoQueryResult>>>
    {
        public async Task<BaseResult<List<GetContactInfoQueryResult>>> Handle(GetContactInfoQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            var conactInfos = _mapper.Map<List<GetContactInfoQueryResult>>(values);

            return BaseResult<List<GetContactInfoQueryResult>>.Success(conactInfos);
        }
    }
}
