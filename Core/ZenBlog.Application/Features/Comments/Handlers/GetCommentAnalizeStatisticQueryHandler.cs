using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Enums;
using ZenBlog.Application.Features.Comments.Queries;
using ZenBlog.Application.Features.Comments.Result;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.Comments.Handlers
{
    public class GetCommentAnalizeStatisticQueryHandler(IRepository<Comment> _repository) : IRequestHandler<GetCommentAnalizeStatisticQuery, BaseResult<GetCommentAnalizeStatisticQueryResult>>
    {
        public async Task<BaseResult<GetCommentAnalizeStatisticQueryResult>> Handle(GetCommentAnalizeStatisticQuery request, CancellationToken cancellationToken)
        {
            var query = _repository.GetQuery().Where(t => t.CreatedAt.Month == DateTime.Now.Month && t.CreatedAt.Year == DateTime.Now.Year);

            int _neutralCommentCount = query.Where(t => t.CommentAnalysis == (byte)CommentAnalysisTypes.Neutral).Count();
            int _positiveCommentCount = query.Where(t => t.CommentAnalysis == (byte)CommentAnalysisTypes.Positive).Count();
            int _negativeCommentCount = query.Where(t => t.CommentAnalysis == (byte)CommentAnalysisTypes.Negative).Count();

            var result = new GetCommentAnalizeStatisticQueryResult
            {
                NegativeCommentCount = _neutralCommentCount,
                PositiveCommentCount = _positiveCommentCount,
                NeutralCommentCount = _negativeCommentCount
            };
            return BaseResult<GetCommentAnalizeStatisticQueryResult>.Success(result);
        }
    }
}
