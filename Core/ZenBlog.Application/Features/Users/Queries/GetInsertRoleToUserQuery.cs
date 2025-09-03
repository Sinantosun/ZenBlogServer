using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Users.Result;

namespace ZenBlog.Application.Features.Users.Queries
{
    public class GetInsertRoleToUserQuery : IRequest<BaseResult<List<GetInsertRoleToUserQueryResult>>>
    {
        public string _userId { get; set; }

        public GetInsertRoleToUserQuery(string userId)
        {
           _userId = userId;
        }
    }
}
