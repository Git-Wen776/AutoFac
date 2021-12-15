using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFac.Models.EntityValidation
{
    public class UserValidation: AbstractValidator<User>
    {
        public UserValidation()
        {
            RuleFor(p => p.Name).NotNull();
            RuleFor(p => p.Email).EmailAddress().NotEmpty();
            RuleFor(p => p.BirthDate).Must(p => p < DateTime.Now);
        }
    }
}
