
using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.ContactInfos.Commands;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.ContactInfos.Handlers
{
    public class UpdateContactInfoCommandHandler(IRepository<ContactInfo> _repository, IMapper _mapper, IUnitOfWork _uniotOfWork) : IRequestHandler<UpdateContactInfoCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateContactInfoCommand request, CancellationToken cancellationToken)
        {
            var contactInfo = _mapper.Map<ContactInfo>(request);
            _repository.Update(contactInfo);
            await _uniotOfWork.SaveChangeAsync();
            return BaseResult<object>.Success("Kayıt Güncellendi...!");
        }
    }
}
