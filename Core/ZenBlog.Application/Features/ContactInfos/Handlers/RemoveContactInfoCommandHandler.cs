

using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.ContactInfos.Commands;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.ContactInfos.Handlers
{
    public class RemoveContactInfoCommandHandler(IRepository<ContactInfo> _repository, IUnitOfWork _unitOfWork) : IRequestHandler<RemoveContactInfoCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveContactInfoCommand request, CancellationToken cancellationToken)
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
