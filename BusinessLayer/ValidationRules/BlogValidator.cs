using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("BLog Title can not empty");
            RuleFor(x => x.Content).NotEmpty().WithMessage("BLog Content can not empty");
            RuleFor(x => x.Image).NotEmpty().WithMessage("BLog Image can not empty");
        }
    }
}
