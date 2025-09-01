using FluentValidation;
using ZenBlog.Application.Features.Blogs.Commands;

namespace ZenBlog.Application.Features.Blogs.Validators
{
    public class CreateBlogValidator : AbstractValidator<CreateBlogCommand>
    {
        public CreateBlogValidator()
        {
            RuleFor(t => t.Title).NotEmpty().WithMessage("Başlık bilgisi gereklidir.");
            RuleFor(t => t.Description).NotEmpty().WithMessage("Açıklama bilgisi gereklidir.");
            RuleFor(t => t.CoverImage).NotEmpty().WithMessage("Kapak Fotoğrafı bilgisi gereklidir.");
            RuleFor(t => t.BlogImage).NotEmpty().WithMessage("Blog Görsel bilgisi gereklidir.");
            RuleFor(t => t.CategoryId).NotEmpty().WithMessage("Kategori bilgisi gereklidir.");
            RuleFor(t => t.UserId).NotEmpty().WithMessage("Kullanıcı bilgisi gereklidir.");
        }
    }
}
