using System;
using System.Linq.Expressions;
using Tako.AOP.Infrastructure;

namespace Tako.AOP.LogExtension
{
    public class Logging
    {
        public static void Before(object sourceInstance, Expression<Action> sourceMember)
        {
            var attribute = DynamicMethod.GetCallbackCustomAttribute<LoggingAttribute>(sourceInstance, sourceMember);
            if (attribute != null)
            {
                var body = (MethodCallExpression) sourceMember.Body;
                var callbackMethod = body.Method;
                attribute.WriteBeforeLog(callbackMethod.Name);
            }
        }

        public static void After(object sourceInstance, Expression<Action> sourceMember)
        {
            var attribute = DynamicMethod.GetCallbackCustomAttribute<LoggingAttribute>(sourceInstance, sourceMember);
            if (attribute != null)
            {
                var body = (MethodCallExpression) sourceMember.Body;
                var callbackMethod = body.Method;
                attribute.WriteAfterLog(callbackMethod.Name);
            }
        }
    }
}