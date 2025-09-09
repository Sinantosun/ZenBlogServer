﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Comments.Result;

namespace ZenBlog.Application.Features.Comments.Queries;

public class GetCommentAnalizeStatisticQuery : IRequest<BaseResult<GetCommentAnalizeStatisticQueryResult>>;

