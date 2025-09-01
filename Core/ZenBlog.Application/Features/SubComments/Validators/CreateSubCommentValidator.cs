
using FluentValidation;
using ZenBlog.Application.Features.SubComments.Commands;

namespace ZenBlog.Application.Features.SubComments.Validators
{
    public class CreateSubCommentValidator :AbstractValidator<CreateSubCommentCommand>
    {
        public CreateSubCommentValidator()
        {
            RuleFor(t => t.UserId).NotEmpty().WithMessage("Kullanıcı bilgisi gereklidir...!");
            RuleFor(t => t.CommentId).NotEmpty().WithMessage("Yorum Bilisi bilgisi gereklidir...!");
            RuleFor(t => t.Body).NotEmpty().WithMessage("Mesaj bilgisi gereklidir...!");

            RuleFor(t => t.Body).MaximumLength(200).WithMessage("Mesaj bilgisi en fazla maximum 200 karakter olabilir...!");
        }
    }
}
