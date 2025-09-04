
using AutoMapper;
using ZenBlog.Application.Features.ParentSubComments.Commands;
using ZenBlog.Application.Features.ParentSubComments.Result;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.ParentSubComments.Mappings
{
    public class ParentSubCommentMappingProfile : Profile
    {
        public ParentSubCommentMappingProfile()
        {
            CreateMap<CreateParentSubCommentCommand, ParentSubComment>().ReverseMap();
            CreateMap<GetParentSubCommentListQueryResult, ParentSubComment>().ReverseMap();
        }
    }
}
