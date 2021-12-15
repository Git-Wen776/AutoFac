using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AutoFac.Models.EntityValidation
{
    public class RegexValidatonProperty<T> : PropertyValidator<T, string>
    {
        public override string Name => "RegexValidationProperty";

        private string regestr;

        public RegexValidatonProperty(string _regesStr)
        {
            regestr = _regesStr;
        }

        public override bool IsValid(ValidationContext<T> context, string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("value is not empty or null string");
            if (string.IsNullOrEmpty(regestr))
            {
                context.MessageFormatter.AppendArgument("RegesStr", regestr);
                throw new ArgumentException("regex string is empty or null");
            }
            Regex regex = new Regex(regestr);
            return regex.IsMatch(value);
        }
    }
}
