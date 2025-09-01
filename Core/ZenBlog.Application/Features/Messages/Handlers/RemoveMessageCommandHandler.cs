using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Messages.Commands;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.Messages.Handlers
{
    public class RemoveMessageCommandHandler(IRepository<Message> _repository, IUnitOfWork _unitOfWork) : IRequestHandler<RemoveMessageCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveMessageCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.id);
            if (value is null)
            {
                return BaseResult<object>.NotFound();
            }
            _repository.Delete(value);
            await _unitOfWork.SaveChangeAsync();
            return BaseResult<object>.Success("Kayıt Silindi...!");
        }
    }
}
