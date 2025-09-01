using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Socials.Commands;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.Socials.Handlers
{
    public class UpdateSocialCommandHandler(IRepository<Social> _repository, IMapper _mapper, IUnitOfWork _unitOfWork) : IRequestHandler<UpdateSocialCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateSocialCommand request, CancellationToken cancellationToken)
        {
            var value = _mapper.Map<Social>(request);
            _repository.Update(value);
            await _unitOfWork.SaveChangeAsync();
            return BaseResult<object>.Success("Kayıt Güncellendi...!");
        }
    }
}
