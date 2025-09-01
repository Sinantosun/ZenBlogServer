
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Categories.Commands;
using ZenBlog.Application.Features.Comments.Commands;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.Comments.Handlers
{
    public class RemoveCommentCommandHandler(IRepository<Comment> _repository, IUnitOfWork _unitOfWork) : IRequestHandler<RemoveCommentCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveCommentCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.id);
            if (value is null)
            {
                return BaseResult<object>.NotFound("Kayıt Bulunamadı..!");
            }
            _repository.Delete(value);
            await _unitOfWork.SaveChangeAsync();
            return BaseResult<object>.Success("Kayıt Silindi...!");
        }
    }
}
