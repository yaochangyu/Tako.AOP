using System;
using Tako.AOP.ExceptionExtension;

namespace Tako.AOP.UnitTest
{
    public class BO
    {
        [ExceptionNotity(LineTo = "Ub93d3c87f472511a0c5944d606edb9d1")]
        public void SetMethod()
        {
            throw new Exception("哎呀出錯了");
        }

        [ExceptionNotity(LineTo = "Ub93d3c87f472511a0c5944d606edb9d1")]
        public void SetMethod(string name)
        {
            throw new Exception($"{name},哎呀出錯了");
        }

        [ExceptionNotity(LineTo = "Ub93d3c87f472511a0c5944d606edb9d1")]
        public void SetMethod(string name, string msg)
        {
            throw new Exception($"{name},{msg}");
        }

        public string GetMethod(string name)
        {
            return $"{name},可惡出錯了!";
        }

        public int GetSquare(int source)
        {
            var target = source * source;
            return target;
        }
    }
}