using AutoMapper;
using ZenBlog.Application.Features.Messages.Commands;
using ZenBlog.Application.Features.Messages.Queries;
using ZenBlog.Application.Features.Messages.Result;
using ZenBlog.Domain.Entites;

namespace ZenBlog.Application.Features.Messages.Mappings
{
    public class MessageMappingProfile : Profile
    {
        public MessageMappingProfile()
        {
            CreateMap<Message, CreateMessageCommand>().ReverseMap();
            CreateMap<Message, UpdateMessageCommand>().ReverseMap();
            CreateMap<Message, GetMessageByIdQueryResult>().ReverseMap();
            CreateMap<Message, GetMessageQueryResult>().ReverseMap();
            CreateMap<Message, GetUnReadMessageQueryResult>().ReverseMap();
            CreateMap<Message, GetReadMessageQueryResult>().ReverseMap();
            CreateMap<Message, GetLastMessagesForDashboardQueryResult>().ReverseMap();
        }
    }
}
