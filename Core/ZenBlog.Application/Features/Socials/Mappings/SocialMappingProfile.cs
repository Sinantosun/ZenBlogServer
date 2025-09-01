
using AutoMapper;
using ZenBlog.Application.Features.Socials.Commands;
using ZenBlog.Application.Features.Socials.Queries;
using ZenBlog.Application.Features.Socials.Result;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.Socials.Mappings
{
    public class SocialMappingProfile : Profile
    {
        public SocialMappingProfile()
        {
            CreateMap<UpdateSocialCommand, Social>().ReverseMap();
            CreateMap<CreateSocialCommand, Social>().ReverseMap();
            CreateMap<GetSocialByIdQueryResult, Social>().ReverseMap();
            CreateMap<GetSocialQueryResult, Social>().ReverseMap();

        }
    }
}
