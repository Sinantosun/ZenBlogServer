using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Enums;
using ZenBlog.Application.Features.Comments.Commands;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.Comments.Handlers
{
    public class CreateCommentCommandHandler(IHugginFaceService _hugginFaceService, IRepository<Comment> _repository, IMapper _mapper, IUnitOfWork _unitOfWork) : IRequestHandler<CreateCommentCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = _mapper.Map<Comment>(request);
            string translatedText = await _hugginFaceService.GetTranslatedText(request.Body);
            if (translatedText == "-1")
            {
                comment.CommentAnalysis = (byte)CommentAnalysisTypes.Unknown;
            }
            byte analizeResult = await _hugginFaceService.AnalizeComment(translatedText);
            comment.CommentAnalysis = analizeResult;
            await _repository.CreateAsync(comment);
            await _unitOfWork.SaveChangeAsync();
            return BaseResult<object>.Success("Kayıt Eklendi..");
        }
    }
}
