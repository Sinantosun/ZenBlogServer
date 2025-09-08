using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Messages.Commands;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.Messages.Handlers
{
    public class ChangeMessageReadStatusCommandHandler(IRepository<Message> _repository, IUnitOfWork _unitofWork) : IRequestHandler<ChangeMessageReadStatusCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(ChangeMessageReadStatusCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.MessageId);
            if (value is null)
            {
                return BaseResult<object>.Fail("Mesaj bulunamadı...!");
            }
            value.IsRead = !value.IsRead;
            await _unitofWork.SaveChangeAsync();
            return BaseResult<object>.Success("Durum Güncellendi.");   

        }
    }
}
