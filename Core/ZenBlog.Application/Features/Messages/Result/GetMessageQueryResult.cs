﻿using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Messages.Result
{
    public class GetMessageQueryResult : BaseDto
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string MessageBody { get; set; }
    }
}
