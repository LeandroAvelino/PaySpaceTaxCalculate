using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySpaceTaxCalculate.Application.InputModels
{
    public class CalculateTaxRateInputModel
    {
        public decimal AnnualIncome { get; set; }
        public decimal Rate { get; set; }
    }
}
