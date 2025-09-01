using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Blogs.Commands;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.Blogs.Handlers
{
    public class CreateBlogCommandHandler(IRepository<Blog> _repository,IMapper _mapper, IUnitOfWork _unitOfWork) : IRequestHandler<CreateBlogCommand, BaseResult<bool>>
    {
        public async Task<BaseResult<bool>> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = _mapper.Map<Blog>(request);
            await _repository.CreateAsync(blog);

            await _unitOfWork.SaveChangeAsync();
            return BaseResult<bool>.Success(true);
        }
    }
}
