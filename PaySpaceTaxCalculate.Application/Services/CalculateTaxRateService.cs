using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaySpaceTaxCalculate.Application.InputModels;

namespace PaySpaceTaxCalculate.Application.Services
{
    public class CalculateTaxRateService
    {
        public CalculateTaxRateService()
        { }

        public decimal Calculate(CalculateTaxRateInputModel calculateTaxRateInputModel)
        {
            return calculateTaxRateInputModel.AnnualIncome * (calculateTaxRateInputModel.Rate / 100);
        }
    }

}
