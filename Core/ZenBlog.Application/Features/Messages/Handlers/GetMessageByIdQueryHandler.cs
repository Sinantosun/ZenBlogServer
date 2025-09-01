using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Messages.Queries;
using ZenBlog.Application.Features.Messages.Result;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.Messages.Handlers
{
    public class GetMessageByIdQueryHandler(IRepository<Message> _repository, IMapper _mapper) : IRequestHandler<GetMessageByIdQuery, BaseResult<GetMessageByIdQueryResult>>
    {
        public async Task<BaseResult<GetMessageByIdQueryResult>> Handle(GetMessageByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            if (value is null)
            {
                return BaseResult<GetMessageByIdQueryResult>.NotFound();
            }
            var message = _mapper.Map<GetMessageByIdQueryResult>(value);
            return BaseResult<GetMessageByIdQueryResult>.Success(message);
        }
    }
}
