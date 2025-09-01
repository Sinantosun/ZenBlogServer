
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.SubComments.Commands;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.SubComments.Handlers
{
    public class RemoveSubCommentCommandHandler(IRepository<SubComment> _repository, IUnitOfWork _unitOfWork) : IRequestHandler<RemoveSubCommentCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveSubCommentCommand request, CancellationToken cancellationToken)
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
