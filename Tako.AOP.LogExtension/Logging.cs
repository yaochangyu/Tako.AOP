using System;
using System.Linq.Expressions;
using Tako.AOP.Infrastructure;

namespace Tako.AOP.LogExtension
{
    public class Logging
    {
        public static void Before(Expression<Action> member)
        {
            var attribute = DynamicMethod.GetCallbackCustomAttribute<LoggingAttribute>(member);
            if (attribute != null)
            {
                var body = (MethodCallExpression) member.Body;
                var callbackMethod = body.Method;
                attribute.WriteBeforeLog(callbackMethod.Name);
            }
        }

        public static void After(Expression<Action> member)
        {
            var attribute = DynamicMethod.GetCallbackCustomAttribute<LoggingAttribute>(member);
            if (attribute != null)
            {
                var body = (MethodCallExpression) member.Body;
                var callbackMethod = body.Method;
                attribute.WriteAfterLog(callbackMethod.Name);
            }
        }
    }
}