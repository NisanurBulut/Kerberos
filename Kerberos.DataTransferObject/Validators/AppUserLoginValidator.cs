using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
namespace Kerberos.DataTransferObject.Validators
{
    public class AppUserValidator : AbstractValidator<AppUserLoginDto>
    {
        public AppUserValidator()
        {
            RuleFor(a => a.UserName).NotEmpty().WithMessage("Kullanıcı adı belirtilmelidir.");
            RuleFor(a => a.Password).NotEmpty().WithMessage("Parola belirtilmelidir.");
        }
    }
}
