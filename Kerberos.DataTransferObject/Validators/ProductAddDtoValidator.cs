using FluentValidation;
using Kerberos.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kerberos.DataTransferObject.Validators
{
    public class ProductAddDtoValidator : AbstractValidator<ProductAddDto>
    {
        public ProductAddDtoValidator()
        {
            RuleFor(I => I.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez");
        }
    }
}
