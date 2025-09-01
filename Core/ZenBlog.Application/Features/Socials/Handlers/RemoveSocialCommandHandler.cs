using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Socials.Commands;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.Socials.Handlers;

public class RemoveSocialCommandHandler(IRepository<Social> _repository, IUnitOfWork _unitofWork) : IRequestHandler<RemoveSocialCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(RemoveSocialCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        if (value is null)
        {
            return BaseResult<object>.NotFound();
        }
        _repository.Delete(value);
        await _unitofWork.SaveChangeAsync();
        return BaseResult<object>.Success("Kayıt Silindi...!");
    }
}
