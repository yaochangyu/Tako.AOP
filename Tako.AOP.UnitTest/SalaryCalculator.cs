using System;
using Tako.AOP.ExceptionExtension;

namespace Tako.AOP.UnitTest
{
    public class SalaryCalculator
    {
        /// <summary>
        ///     計算薪資的公式物件
        /// </summary>
        private readonly ISalaryFormula _SalaryFormula;

        /// <summary>
        ///     建構子
        /// </summary>
        /// <param name="SalaryFormula"></param>
        public SalaryCalculator(ISalaryFormula SalaryFormula)
        {
            this._SalaryFormula = SalaryFormula;
        }

        /// <summary>
        ///     計算薪資
        /// </summary>
        /// <param name="WorkHours">工時</param>
        /// <param name="Hourly">時薪</param>
        /// <param name="PrivateDayOff">請假天數</param>
        /// <returns></returns>
        public float Calculate(float WorkHours, int Hourly, int PrivateDayOffHours)
        {
            float result = 0;
            result = (float) AOPLoader.Invoke(this._SalaryFormula,
                                              () => this._SalaryFormula.Execute(WorkHours, Hourly,
                                                                                PrivateDayOffHours));
            return result;
        }
    }

    public interface ISalaryFormula
    {
        /// <summary>
        ///     實際計算薪資
        /// </summary>
        /// <param name="WorkHours"></param>
        /// <param name="Hourly"></param>
        /// <param name="PrivateDayOffHours"></param>
        /// <returns></returns>
        float Execute(float WorkHours, int Hourly, int PrivateDayOffHours);
    }

    /// <summary>
    ///     計算薪資的公式的類別
    /// </summary>
    public class SalaryFormula : ISalaryFormula
    {
        /// <summary>
        ///     實際計算薪資
        /// </summary>
        /// <param name="WorkHours"></param>
        /// <param name="Hourly"></param>
        /// <param name="PrivateDayOffHours"></param>
        /// <returns></returns>
        [ExceptionNotity(LineTo = "Ub93d3c87f472511a0c5944d606edb9d1")]
        public float Execute(float WorkHours, int Hourly, int PrivateDayOffHours)
        {
            throw new Exception("薪水發不出來了");

            //薪資=工時*時薪-(事假時數*時薪)
            return WorkHours * Hourly - PrivateDayOffHours * Hourly;
        }
    }

    //老闆
    public class BossSalaryFormula : ISalaryFormula
    {
        public float Execute(float WorkHours, int Hourly, int PrivateDayOffHours)
        {
            //老闆請假不扣薪
            return WorkHours * Hourly - PrivateDayOffHours * Hourly * 0;
        }
    }
}