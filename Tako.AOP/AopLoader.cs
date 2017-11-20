using System;
using System.Linq.Expressions;
using Tako.AOP.ExceptionExtension;
using Tako.AOP.Infrastructure;
using Tako.AOP.LogExtension;

namespace Tako.AOP
{
    public class AOPLoader
    {
        public static object Invoke(object instance,
                                    Expression<Action> member)
        {
            Logging.Before(instance,member);
            object result = null;
            try
            {
                result = DynamicMethod.Execute(instance, member);
            }
            catch (Exception e)
            {
                ExceptionNotity.Invoke(instance, member, e);
                throw new AOPException("AOP Exception", e);
            }
            finally
            {
                Logging.After(instance,member);
            }

            return result;
        }

        //public static void Invoke<TSource>(TSource sourceInstance, string methodName, object[] parameters)
        //{
        //    var sourceType = sourceInstance.GetType();
        //    var sourceMethods = sourceType.GetMethods();
        //    MethodInfo sourceMethodInfo = null;
        //    foreach (var sourceMethod in sourceMethods)
        //    {
        //        var sourceParameters = sourceMethod.GetParameters();

        //        if (sourceParameters.Length == 0 & parameters == null)
        //        {
        //            sourceMethodInfo = sourceMethod;
        //            break;
        //        }

        //        if (sourceParameters.Length != parameters.Length)
        //        {
        //            continue;
        //        }

        //        //TODO:比對條件不夠，可能會找到錯誤的方法
        //        sourceMethodInfo = sourceMethod;
        //    }

        //    try
        //    {
        //        sourceMethodInfo.Invoke(sourceInstance, parameters);
        //    }
        //    catch (Exception e)
        //    {
        //        var attribute = sourceMethodInfo.GetCustomAttribute<ExceptionNotityAttribute>();
        //        if (attribute != null)
        //        {
        //            attribute.CatchException(e);
        //        }

        //        //TODO:重新引發例外，拜託不要寫throw e;
        //        throw new AOPException("AOP Exception", e);
        //    }
        //}
    }
}