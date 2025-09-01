using FluentValidation;
using ZenBlog.Application.Features.Categories.Commands;

namespace ZenBlog.Application.Features.Categories.Validators
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryValidator()
        {
            RuleFor(t => t.CategoryName).NotEmpty().WithMessage("Kategori adı gereklidir.")
                .MinimumLength(3).WithMessage("Kategori adı en az 3 karakter olmalıdır.");

        }
    }
}
