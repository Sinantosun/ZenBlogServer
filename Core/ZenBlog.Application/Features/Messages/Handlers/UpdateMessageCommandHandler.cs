
using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Messages.Commands;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.Messages.Handlers
{
    public class UpdateMessageCommandHandler(IRepository<Message> _repository, IMapper _mapper, IUnitOfWork _unitofWork) : IRequestHandler<UpdateMessageCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateMessageCommand request, CancellationToken cancellationToken)
        {
            var value = _mapper.Map<Message>(request);
            _repository.Update(value);
            await _unitofWork.SaveChangeAsync();
            return BaseResult<object>.Success("Kayıt Güncellendi...!");
        }
    }
}
