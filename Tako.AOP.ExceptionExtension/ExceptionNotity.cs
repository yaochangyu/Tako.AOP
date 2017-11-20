using System;
using System.Linq.Expressions;
using Tako.AOP.Infrastructure;

namespace Tako.AOP.ExceptionExtension
{
    public class ExceptionNotity
    {
        public static void Invoke<TSource>(TSource instance, Expression<Action<TSource>> member, Exception e)
        {
            var attribute = DynamicMethod.GetCallbackCustomAttribute<TSource, ExceptionNotityAttribute>(member);
            if (attribute != null)
            {
                attribute.CatchException(e);
            }
        }
    }
}