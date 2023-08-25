using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator: AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Yazar adı alanı boş geçilemez");
            RuleFor(x => x.Name).MaximumLength(2).WithMessage("Ad kısmı iki karakterden küçük olamaz");
            RuleFor(x => x.Email).NotEmpty().WithMessage("E-posta boş geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş geçilemez");
        }
    }
}
