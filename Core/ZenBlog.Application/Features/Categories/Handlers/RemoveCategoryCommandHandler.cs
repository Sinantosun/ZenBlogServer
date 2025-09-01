
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Categories.Commands;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.Categories.Handlers
{
    public class RemoveCategoryCommandHandler(IRepository<Category> _repository, IUnitOfWork UnitOfWork) : IRequestHandler<RemoveCategoryCommand, BaseResult<bool>>
    {
        public async Task<BaseResult<bool>> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(request.Id);
            if (category is null)
            {
                return BaseResult<bool>.NotFound("Kategori bulunamadı...!");
            }

            _repository.Delete(category);
           var response = await UnitOfWork.SaveChangeAsync();

            return response ? BaseResult<bool>.Success(response) : BaseResult<bool>.Fail();
        }
    }
}
