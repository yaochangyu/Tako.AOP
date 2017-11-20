using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tako.AOP.UnitTest;

namespace Tako.AOP.Infrastructure.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void 使用ExpressionTree_調用兩個參數的SetMethod方法_預期得到AOPException()
        {
            var bo = new BO();

            Action action = () => AOPLoader.Invoke(bo, p => p.SetMethod("余小章", "可惡出錯了!"));
            action.ShouldThrow<AOPException>();
        }

        [TestMethod]
        public void 使用ExpressionTree_調用兩個參數的GetMethod方法_預期得到AOPException()
        {
            var bo = new BO();
            var expected = $"余小章,可惡出錯了!";
            var actual = AOPLoader.Invoke(bo, p => p.GetMethod("余小章"));
            Assert.AreEqual(expected, actual);
        }

        //[TestMethod]
        //public void 使用反射_調用兩個參數的SetMethod方法_預期得到AOPException()
        //{
        //    var bo = new BO();
        //    Action action = () => AOP.Invoke(bo, "SetMethod", null);
        //    action.ShouldThrow<AOPException>();
        //}
    }
}