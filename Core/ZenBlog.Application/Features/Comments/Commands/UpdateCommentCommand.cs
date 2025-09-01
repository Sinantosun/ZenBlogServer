﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Comments.Commands
{
    public class UpdateCommentCommand :IRequest<BaseResult<object>>
    {
        public Guid Id  { get; set; }
        public string UserId { get; init; }
        public string Body { get; init; }

        public Guid BlogId { get; init; }
    }
}
