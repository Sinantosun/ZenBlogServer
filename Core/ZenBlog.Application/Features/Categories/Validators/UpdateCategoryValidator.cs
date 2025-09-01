using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Features.Categories.Commands;

namespace ZenBlog.Application.Features.Categories.Validators
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryValidator()
        {

            RuleFor(t => t.Id).NotEmpty().WithMessage("Kategori id gereklidir..!");

            RuleFor(t => t.CategoryName).NotEmpty().WithMessage("Kategori adı gereklidir.")
                .MinimumLength(3).WithMessage("Kategori adı en az 3 karakter olmalıdır.");

        }
    }
}
