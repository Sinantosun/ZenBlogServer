using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Comments.Queries;
using ZenBlog.Application.Features.Comments.Result;

namespace ZenBlog.Application.Features.Comments.Handlers
{
    public class GetTranslateToEnglishQueryHandler(IHugginFaceService _hugginFaceService) : IRequestHandler<GetTranslateToEnglishQuery, BaseResult<GetTranslateToEnglishQueryResult>>
    {
        public async Task<BaseResult<GetTranslateToEnglishQueryResult>> Handle(GetTranslateToEnglishQuery request, CancellationToken cancellationToken)
        {
            var text = await _hugginFaceService.GetTranslatedText(request._text);
            var result = new GetTranslateToEnglishQueryResult
            {
                TranslatedText = text,
            };
            return BaseResult<GetTranslateToEnglishQueryResult>.Success(result);
        }
    }
}
