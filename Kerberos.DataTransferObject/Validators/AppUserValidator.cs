using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
namespace Kerberos.DataTransferObject.Validators
{
    public class AppUserValidator : AbstractValidator<AppUserDto>
    {
        public AppUserValidator()
        {
            RuleFor(a => a.Id).ExclusiveBetween(1, int.MaxValue);
            RuleFor(a => a.UserName).NotEmpty().WithMessage("Kullanıcı adı belirtilmelidir.");
            RuleFor(a => a.FullName).NotEmpty().WithMessage("Ad soyad belirtilmelidir.");
            RuleFor(a => a.Password).NotEmpty().WithMessage("Parola belirtilmelidir.");
        }
    }
}
