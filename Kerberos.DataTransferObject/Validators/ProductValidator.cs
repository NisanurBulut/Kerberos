﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kerberos.DataTransferObject.Validators
{
    public class ProductValidator : AbstractValidator<ProductDto>
    {
        public ProductValidator()
        {
            RuleFor(a => a.Name).NotEmpty().WithMessage("Ürün adı belirtilmelidir.");
        }
    }
}