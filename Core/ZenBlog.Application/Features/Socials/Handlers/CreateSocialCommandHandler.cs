using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Socials.Commands;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.Socials.Handlers
{
    public class CreateSocialCommandHandler(IRepository<Social> _repository, IMapper _mapper, IUnitOfWork _unitOfWork) : IRequestHandler<CreateSocialCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateSocialCommand request, CancellationToken cancellationToken)
        {
            var value = _mapper.Map<Social>(request);
            await _repository.CreateAsync(value);
            await _unitOfWork.SaveChangeAsync();
            return BaseResult<object>.Success("Kayıt Eklendi...!");
        }
    }
}
