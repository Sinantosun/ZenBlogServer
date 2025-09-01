
using FluentValidation;
using ZenBlog.Application.Features.Users.Commands;

namespace ZenBlog.Application.Features.Users.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(t => t.FirstName).NotEmpty().WithMessage("Ad bilgisi gereklidir.");
            RuleFor(t => t.LastName).NotEmpty().WithMessage("Soyad bilgisi gereklidir.");

            RuleFor(t => t.UserName).NotEmpty().WithMessage("Kullanıcı adı bilgisi gereklidir.");

            RuleFor(t => t.Email).NotEmpty().WithMessage("Email bilgisi gereklidir.");
            RuleFor(t => t.Email).EmailAddress().WithMessage("Geçerli bir email adresi giriniz.");

            RuleFor(t => t.Password).NotEmpty().WithMessage("Şifre bilgisi gereklidir.");

        }
    }
}
