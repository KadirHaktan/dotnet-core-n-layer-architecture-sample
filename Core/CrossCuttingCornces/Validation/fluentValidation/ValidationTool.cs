using System;
using System.Collections.Generic;
using System.Text;
using Core.Entity;
using FluentValidation;

namespace Core.CrossCuttingCornces.Validation.fluentValidation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);

            var result = validator.Validate(context);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
