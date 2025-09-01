using AutoMapper;
using ZenBlog.Application.Features.ContactInfos.Commands;
using ZenBlog.Application.Features.ContactInfos.Result;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.ContactInfos.Mappings
{
    public class ContactInfoMappingProfile : Profile
    {
        public ContactInfoMappingProfile()
        {
            CreateMap<ContactInfo, CreateContactInfoCommand>().ReverseMap();
            CreateMap<ContactInfo, UpdateContactInfoCommand>().ReverseMap();
            CreateMap<ContactInfo, GetContactInfoByIdQueryResult>().ReverseMap();
            CreateMap<ContactInfo, GetContactInfoQueryResult>().ReverseMap();

        }
    }
}
