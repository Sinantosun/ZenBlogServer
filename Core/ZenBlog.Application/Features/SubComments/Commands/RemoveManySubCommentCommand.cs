﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.SubComments.Commands;

public record RemoveManySubCommentCommand(Guid Id) : IRequest<BaseResult<object>>; 

