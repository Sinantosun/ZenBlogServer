using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Categories.Result
{
    public class GetCategoryListByPageQueryResult 
    {
        public List<CategoryListByPage> values { get; set; }
        public int TotalCount { get; set; }

    }

    public class CategoryListByPage : BaseDto
    {
        public string CategoryName { get; set; }
    }
}
