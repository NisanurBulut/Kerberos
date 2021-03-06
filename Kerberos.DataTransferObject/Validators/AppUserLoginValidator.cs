﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
namespace Kerberos.DataTransferObject.Validators
{
    public class AppUserLoginValidator : AbstractValidator<AppUserLoginDto>
    {
        public AppUserLoginValidator()
        {
            RuleFor(a => a.UserName).NotEmpty().WithMessage("Kullanıcı adı belirtilmelidir.");
            RuleFor(a => a.Password).NotEmpty().WithMessage("Parola belirtilmelidir.");
        }
    }
}
