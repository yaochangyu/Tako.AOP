using System;
using System.Runtime.Serialization;

namespace Tako.AOP.Infrastructure
{
    [Serializable]
    public class AOPException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public AOPException()
        {
        }

        public AOPException(string message) : base(message)
        {
        }

        public AOPException(string message, Exception inner) : base(message, inner)
        {
        }

        protected AOPException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}