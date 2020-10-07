using System;
using System.Collections.Generic;
using System.Text;
using Core.Entity;
using FluentValidation;

namespace Core.CrossCuttingCornces.Validation.fluentValidation
{
    public static class ValidationTool<T> where T:class,IEntity
    {
        public static void Validate(IValidator validator, T entity)
        {
            var context = new ValidationContext<T>(entity);

            var result = validator.Validate(context);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
