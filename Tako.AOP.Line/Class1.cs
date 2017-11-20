using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using isRock.LineBot;
using Tako.AOP.Infrastructure;

namespace Tako.AOP.Line
{
    [AttributeUsage(AttributeTargets.Field |
                     AttributeTargets.Property |
                     AttributeTargets.Method,
         AllowMultiple = true, Inherited = false)]
    public class ExceptionNotityAttribute : Attribute
    {
        public string MailTo { get; set; }

        public string LineTo { get; set; }

        public void CatchException(Exception e)
        {
            var token =
                @"tNAnpORrM1l0X1uXesIhY/U1UWFuDoAW6mNB2TU+WUIzeloZy8wFFwqm25UkrXGsEezeNqTbN7dhvztt00YK9wapXE3Q+RSff/JDZ1f9yHFaPpqcvb8l3gJzCIKDP96iOU2HsWlCoXhuPYH3sTIr2QdB04t89/1O/w1cDnyilFU=";

            var lineId = this.LineTo;
            if (!string.IsNullOrWhiteSpace(lineId))
            {
                var bot = new Bot(token);
                bot.PushMessage(lineId, e.Message);
            }
        }

        public void Invoke(string methodName)
        {
            var sourceType = this.GetType();
            var methodInfo = sourceType.GetMethod(methodName);

           
            var attribute = methodInfo.GetCustomAttribute<ExceptionNotityAttribute>();
            try
            {
                methodInfo.Invoke(this, null);
            }
            catch (Exception e)

            {
                if (attribute != null)
                {
                    var token =
                        @"tNAnpORrM1l0X1uXesIhY/U1UWFuDoAW6mNB2TU+WUIzeloZy8wFFwqm25UkrXGsEezeNqTbN7dhvztt00YK9wapXE3Q+RSff/JDZ1f9yHFaPpqcvb8l3gJzCIKDP96iOU2HsWlCoXhuPYH3sTIr2QdB04t89/1O/w1cDnyilFU=";

                    var lineId = attribute.LineTo;
                    if (!string.IsNullOrWhiteSpace(lineId))
                    {
                        var bot = new Bot(token);
                        bot.PushMessage(lineId, e.InnerException.Message);
                    }
                }

                throw new AOPException("AOP Exception", e);
            }
        }
    }
}
