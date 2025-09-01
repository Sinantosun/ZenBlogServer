
using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.SubComments.Commands;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.SubComments.Handlers
{
    public class CreateSubCommentCommandHandler(IRepository<SubComment> _repository, IMapper _Mapper,IUnitOfWork _unitOfWork) : IRequestHandler<CreateSubCommentCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateSubCommentCommand request, CancellationToken cancellationToken)
        {
            var subComment = _Mapper.Map<SubComment>(request);
            await _repository.CreateAsync(subComment);
            await _unitOfWork.SaveChangeAsync();

            return BaseResult<object>.Success("Alt Yorum Kaydı Eklendi...!");
        }
    }
}
