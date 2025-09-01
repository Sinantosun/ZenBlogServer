using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Features.Blogs.Commands;

namespace ZenBlog.Application.Features.Blogs.Validators
{
    public class UpdateBlogValidator : AbstractValidator<UpdateBlogCommand>
    {
        public UpdateBlogValidator()
        {
            RuleFor(t => t.Id).NotEmpty().WithMessage("Id bilgisi gereklidir.");

            RuleFor(t => t.Title).NotEmpty().WithMessage("Başlık bilgisi gereklidir.");
            RuleFor(t => t.Description).NotEmpty().WithMessage("Açıklama bilgisi gereklidir.");
            RuleFor(t => t.CoverImage).NotEmpty().WithMessage("Kapak Fotoğrafı bilgisi gereklidir.");
            RuleFor(t => t.BlogImage).NotEmpty().WithMessage("Blog Görsel bilgisi gereklidir.");
            RuleFor(t => t.CategoryId).NotEmpty().WithMessage("Kategori bilgisi gereklidir.");
            RuleFor(t => t.UserId).NotEmpty().WithMessage("Kullanıcı bilgisi gereklidir.");
        }
    }
}
