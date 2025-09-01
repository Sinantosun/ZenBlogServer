using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Features.SubComments.Commands;

namespace ZenBlog.Application.Features.SubComments.Validators
{
    public class UpdateSubCommentValidator : AbstractValidator<UpdateSubCommentCommand>
    {
        public UpdateSubCommentValidator()
        {
            RuleFor(t => t.Id).NotEmpty().WithMessage("Id bilgisi gereklidir...!");

            RuleFor(t => t.UserId).NotEmpty().WithMessage("Kullanıcı bilgisi gereklidir...!");
            RuleFor(t => t.CommentId).NotEmpty().WithMessage("Yorum Bilisi bilgisi gereklidir...!");
            RuleFor(t => t.Body).NotEmpty().WithMessage("Mesaj bilgisi gereklidir...!");

            RuleFor(t => t.Body).MaximumLength(200).WithMessage("Mesaj bilgisi en fazla maximum 200 karakter olabilir...!");
        }
    }
}
