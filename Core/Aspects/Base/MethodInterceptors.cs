using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;

namespace Core.Aspects.Base
{
    public abstract class MethodInterceptors:MethodInterceptorsAttributeBase
    {
        public virtual void OnBefore(IInvocation invocation){}

        public virtual void OnAfter(IInvocation invocation){}

        public virtual void OnSuccess(IInvocation invocation){}

        public virtual void OnException(IInvocation invocation,Exception e){}


        public override void Intercept(IInvocation invocation)
        {
            bool IsSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }

            catch (Exception e)
            {
                IsSuccess = false;
                OnException(invocation, e);
                throw;
            }

            finally
            {
                if (IsSuccess == true)
                {
                    OnSuccess(invocation);
                }
            }

            OnAfter(invocation);
        }
    }
}
