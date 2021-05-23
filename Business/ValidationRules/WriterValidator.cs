using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı Boş Geçilemez");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar SoyAdı Boş Geçilemez");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("En Fazla 50 karakter yazabilirsiniz");
            RuleFor(x => x.WriterSurName).MaximumLength(50).WithMessage("En Fazla 50 karakter yazabilirsiniz");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında Alanı Boş Geçilemez");
        }
    }
}


