
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Comments.Result;

namespace ZenBlog.Application.Features.Comments.Queries
{
    public class GetTranslateToEnglishQuery : IRequest<BaseResult<GetTranslateToEnglishQueryResult>>
    {
        public string _text { get; set; }

        public GetTranslateToEnglishQuery(string text)
        {
            _text = text;
        }
    }
}
