﻿using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tako.AOP.UnitTest;

namespace Tako.AOP.Infrastructure.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void 算薪水()
        {
            var salaryFormula = new SalaryFormula();
            var test = new SalaryCalculator(salaryFormula);
            test.Calculate(10, 10, 0);
        }

        [TestMethod]
        public void 使用ExpressionTree_調用兩個參數的SetMethod方法_預期得到AOPException()
        {
            var bo = new BO();
            Action action = () => AOPLoader.Invoke(bo, () => bo.SetMethod("余小章", "可惡出錯了!"));
            action.ShouldThrow<AOPException>();
        }

        [TestMethod]
        public void 使用ExpressionTree_調用GetSquare方法_參數2_預期得到4()
        {
            var bo = new BO();
            var expected = 4;
            var actual = (int) AOPLoader.Invoke(bo, () => bo.GetSquare(2));
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