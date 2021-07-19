using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
   public  class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı Boş Geçilemez");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Boş Geçilemez");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj Boş Geçilemez");
            RuleFor(x => x.ReceiverMail).EmailAddress().WithMessage("Lütfen Geçerli Mail Adresi Giriniz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("En Az 3 Karakter Giriniz");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("En Fazla 50 Karakter Yazabilirsiniz");
        }
    }
}
