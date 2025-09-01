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
        }
    }
}
