
namespace ZenBlog.Application.Features.Comments.Result
{
    public class GetCommentAnalizeStatisticQueryResult
    {
        public int PositiveCommentCount { get; set; }
        public int NegativeCommentCount { get; set; }
        public int NeutralCommentCount { get; set; }
    }
}
