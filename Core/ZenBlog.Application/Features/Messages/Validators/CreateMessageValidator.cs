using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Features.Messages.Commands;

namespace ZenBlog.Application.Features.Messages.Validators
{
    public class CreateMessageValidator : AbstractValidator<CreateMessageCommand>
    {
        public CreateMessageValidator()
        {
            RuleFor(t => t.Email).NotEmpty().WithMessage("Email bilgisi gereklidir...!");
            RuleFor(t => t.Email).EmailAddress().WithMessage("Geçersiz bir email adresi girdiniz.");

            RuleFor(t => t.Subject).NotEmpty().WithMessage("Başlık bilgisi gereklidir...!");
            RuleFor(t => t.Subject).MaximumLength(20).WithMessage("Başlık bilgisi maximum 20 karakter olmalıdır...!");
            RuleFor(t => t.Subject).MinimumLength(3).WithMessage("Başlık bilgisi minimum 3 karakter olabilir...!");

            RuleFor(t => t.MessageBody).NotEmpty().WithMessage("Mesaj içerik bilgisi gereklidir...!");
            RuleFor(t => t.MessageBody).MaximumLength(350).WithMessage("Mesaj içerik bilgisi maximum 350 karakter içerebilir..!");
            RuleFor(t => t.MessageBody).MinimumLength(5).WithMessage("Mesaj içerik minumum 5 karakter içermelidir..!");

            RuleFor(t => t.NameSurname).NotEmpty().WithMessage("Ad Soyad bilgisi gereklidir...!");
        }
    }
}
