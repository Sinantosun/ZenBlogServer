
using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.SubComments.Commands;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.SubComments.Handlers
{
    public class UpdateSubCommentHandler(IRepository<SubComment> _repository, IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<UpdateSubCommentCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateSubCommentCommand request, CancellationToken cancellationToken)
        {
            var value = _mapper.Map<SubComment>(request);
            if (value is null)
            {
                return BaseResult<object>.NotFound("Kayıt Bulunamadı...!");
            }
            _repository.Update(value);
            await _unitOfWork.SaveChangeAsync();
            return BaseResult<object>.Success("Kayıt Güncellendi...!");
        }
    }
}
