using System.ComponentModel.DataAnnotations;
using NUnit.Framework;
using PaySpaceTaxCalculate.Application.InputModels;
using PaySpaceTaxCalculate.Application.Services;

namespace PaySpaceTaxCalculate.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PaySpaceTaxCalculate_Text()
        {
            var value = new CalculateTaxRateInputModel
            {
                AnnualIncome = 14505.00M,
                Rate = 15M
            };
            Assert.AreEqual(2175.75M, new CalculateTaxRateService().Calculate(value));
        }
    }
}