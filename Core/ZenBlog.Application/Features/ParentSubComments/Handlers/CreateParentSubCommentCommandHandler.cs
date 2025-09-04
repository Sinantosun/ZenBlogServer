
using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.ParentSubComments.Commands;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.ParentSubComments.Handlers
{
    public class CreateParentSubCommentCommandHandler(IMapper _mapper, IUnitOfWork _unitofWork, IRepository<ParentSubComment> _repository) : IRequestHandler<CreateParentSubCommentCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateParentSubCommentCommand request, CancellationToken cancellationToken)
        {
            var mappedValue = _mapper.Map<ParentSubComment>(request);
            await _repository.CreateAsync(mappedValue);
            await _unitofWork.SaveChangeAsync();

            return BaseResult<object>.Success("Yorum eklendi...!");


        }
    }
}
