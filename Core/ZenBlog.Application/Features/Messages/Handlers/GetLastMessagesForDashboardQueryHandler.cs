using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class GetLastMessagesForDashboardQueryHandler(IRepository<Message> _repository, IMapper _mapper) : IRequestHandler<GetLastMessagesForDashboardQuery, BaseResult<List<GetLastMessagesForDashboardQueryResult>>>
    {
        public async Task<BaseResult<List<GetLastMessagesForDashboardQueryResult>>> Handle(GetLastMessagesForDashboardQuery request, CancellationToken cancellationToken)
        {
            var query = _repository.GetQuery();
            var values = await query.OrderByDescending(t => t.CreatedAt).Take(8).ToListAsync();
            var mappedValues = _mapper.Map<List<GetLastMessagesForDashboardQueryResult>>(values);
            return BaseResult<List<GetLastMessagesForDashboardQueryResult>>.Success(mappedValues);
        }
    }
}
