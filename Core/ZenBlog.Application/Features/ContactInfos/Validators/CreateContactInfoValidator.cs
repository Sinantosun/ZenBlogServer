using FluentValidation;
using ZenBlog.Application.Features.ContactInfos.Commands;

namespace ZenBlog.Application.Features.ContactInfos.Validators
{
    public class CreateContactInfoValidator : AbstractValidator<CreateContactInfoCommand>
    {
        public CreateContactInfoValidator()
        {
            RuleFor(t => t.Address).NotEmpty().WithMessage("Adress bilgisi gereklidir..!");

            RuleFor(t => t.Email).NotEmpty().WithMessage("Email bilgisi gereklidir..!");
            RuleFor(t => t.Email).EmailAddress().WithMessage("Geçersiz email adresi lütfen tekrar deneyin...!");

            RuleFor(t => t.Phone).NotEmpty().WithMessage("Telefon numarası gereklidir..!");
            RuleFor(t => t.MapURL).NotEmpty().WithMessage("Harita bilgisi gereklidir..!");
        }
    }
}
