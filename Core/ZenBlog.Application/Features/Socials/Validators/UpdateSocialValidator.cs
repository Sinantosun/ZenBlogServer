
using FluentValidation;
using ZenBlog.Application.Features.Socials.Commands;

namespace ZenBlog.Application.Features.Socials.Validators
{
    public class UpdateSocialValidator : AbstractValidator<UpdateSocialCommand>
    {
        public UpdateSocialValidator()
        {

            RuleFor(t => t.Id).NotEmpty().WithMessage("Id bilgisi gereklidir ...!");
            RuleFor(t => t.Icon).NotEmpty().WithMessage("Ikon alanı boş geçilemez...!");
            RuleFor(t => t.Title).NotEmpty().WithMessage("Başlık alanı boş geçilemez...!");
            RuleFor(t => t.Url).NotEmpty().WithMessage("Link bilgisi gereklidir..!");
        }
    }
}
