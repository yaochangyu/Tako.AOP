using System;
using System.Linq.Expressions;
using Tako.AOP.Infrastructure;

namespace Tako.AOP.ExceptionExtension
{
    public class ExceptionNotity
    {
        public static void Invoke(object instance, Expression<Action> member, Exception e)
        {
            var attribute = DynamicMethod.GetCallbackCustomAttribute<ExceptionNotityAttribute>(instance, member);
            if (attribute != null)
            {
                attribute.CatchException(e);
            }
        }
    }
}