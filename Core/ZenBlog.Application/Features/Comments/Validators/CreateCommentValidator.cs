using FluentValidation;
using ZenBlog.Application.Features.Comments.Commands;

namespace ZenBlog.Application.Features.Comments.Validators
{
    public class CreateCommentValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentValidator()
        {
            RuleFor(t=>t.UserId).NotEmpty().WithMessage("Kullanıcı bilgisi gereklidir..!");
            RuleFor(t=>t.BlogId).NotEmpty().WithMessage("Blog bilgisi gereklidir...!");
            RuleFor(t=>t.Body).NotEmpty().WithMessage("Yorum içeriği gereklidir..!");

            RuleFor(t=>t.Body).MaximumLength(1000).WithMessage("Yorum içeriği maximum 1000 karakter olabilir..!");
            RuleFor(t=>t.Body).MinimumLength(5).WithMessage("Yorum minumum 5 karakter içermelidir..!");
        }
    }
}
