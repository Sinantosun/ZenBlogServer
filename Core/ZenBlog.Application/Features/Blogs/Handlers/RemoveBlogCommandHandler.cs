
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Blogs.Commands;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.Blogs.Handlers
{
    public class RemoveBlogCommandHandler(IRepository<Blog> _repository,IUnitOfWork _unitOfWork) : IRequestHandler<RemoveBlogCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = await _repository.GetByIdAsync(request.id);

            if (blog is null)
            {
                return BaseResult<object>.Fail("Blog Kaydı Bulunamadı...!");
            }

            _repository.Delete(blog);

            await _unitOfWork.SaveChangeAsync();

            return BaseResult<object>.Success("Blog Kaydı Silindi..!");
        }
    }
}
