using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;

namespace Core.Aspects.Base
{

    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method,AllowMultiple = true,Inherited = true)]
    public abstract class MethodInterceptorsAttributeBase : Attribute,IInterceptor
    {
        private int priority { get; set; }
        public int Priority{ get {return priority;} set { value = priority;} }


        public virtual void Intercept(IInvocation invocation)
        {
            throw new NotImplementedException();
        }
    }
}
