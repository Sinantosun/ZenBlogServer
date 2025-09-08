using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.ParentSubComments.Commands;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.ParentSubComments.Handlers
{
    public class RemoveParentSubCommentCommandHandler(IRepository<ParentSubComment> _repsitory, IUnitOfWork _unitOfWork) : IRequestHandler<RemoveParentSubCommentCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveParentSubCommentCommand request, CancellationToken cancellationToken)
        {
            var value = await _repsitory.GetByIdAsync(request.Id);
            _repsitory.Delete(value);
            await _unitOfWork.SaveChangeAsync();
            return BaseResult<object>.Success("Kayıt Silindi...!");

        }
    }
}
