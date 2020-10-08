using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using Core.Aspects.Base;
using Core.CrossCuttingCornces.Validation.fluentValidation;
using FluentValidation;

namespace Core.Aspects.Validation
{
    public class ValidationAspect:MethodInterceptors
    {
        public Type Type;


        public ValidationAspect(Type type)
        {
            if (!typeof(IValidator).IsAssignableFrom(type))
            {
                throw new Exception();
            }

            this.Type = type;
        }

        public override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator) Activator.CreateInstance(Type);
            var entityType = Type.BaseType.GetGenericArguments()[0];

            var entities = invocation.Arguments.Where(e => e.GetType() == entityType);

            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator,entity);
            }
        }
    }
}
