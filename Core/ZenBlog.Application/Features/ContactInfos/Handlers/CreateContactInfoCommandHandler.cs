
using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.ContactInfos.Commands;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.ContactInfos.Handlers
{
    public class CreateContactInfoCommandHandler(IRepository<ContactInfo> _repository, IMapper _mapper, IUnitOfWork _unitofwork) : IRequestHandler<CreateContactInfoCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateContactInfoCommand request, CancellationToken cancellationToken)
        {
            var value = _mapper.Map<ContactInfo>(request);
            await _repository.CreateAsync(value);
            await _unitofwork.SaveChangeAsync();
            return BaseResult<object>.Success("Kayıt Eklendi...!");
        }
    }
}
