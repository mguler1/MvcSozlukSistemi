using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class CategoryValidator :AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adı Boş Geçilemez");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("En az 3 karakter girişi yapınız");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("En Fazla 50 karakter yazabilirsiniz");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklama Boş Geçilemez");
            RuleFor(x => x.CategoryDescription).MaximumLength(200).WithMessage("En Fazla 200 karakter yazabilirsiniz");
        }
    }
}
