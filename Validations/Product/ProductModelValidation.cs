using FluentValidation;
using Models.Concerete.Product;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Validations.Product
{
    public class ProductModelValidation:AbstractValidator<ProductModel>
    {
        public ProductModelValidation()
        {
            RuleFor(p => p.Price).GreaterThanOrEqualTo(1);
            RuleFor(p => p.Name).NotNull();
            RuleFor(p => p.InnerBarcode).MinimumLength(5);
        }
    }
}
