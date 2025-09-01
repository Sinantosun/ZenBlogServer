
using FluentValidation;
using ZenBlog.Application.Features.Comments.Commands;

namespace ZenBlog.Application.Features.Comments.Validators
{
    public class UpdateCommentValidator : AbstractValidator<UpdateCommentCommand>
    {
        public UpdateCommentValidator()
        {
            RuleFor(t => t.Id).NotEmpty().WithMessage("Yorum id bilgisi gereklidir..!");
            RuleFor(t => t.UserId).NotEmpty().WithMessage("Kullanıcı bilgisi gereklidir..!");
            RuleFor(t => t.BlogId).NotEmpty().WithMessage("Blog bilgisi gereklidir...!");
            RuleFor(t => t.Body).NotEmpty().WithMessage("Yorum içeriği gereklidir..!");
        }
    }
}
