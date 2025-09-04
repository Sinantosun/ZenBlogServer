using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.ParentSubComments.Result;

namespace ZenBlog.Application.Features.ParentSubComments.Queries;

public record GetParentSubCommentListQuery : IRequest<BaseResult<List<GetParentSubCommentListQueryResult>>>;

