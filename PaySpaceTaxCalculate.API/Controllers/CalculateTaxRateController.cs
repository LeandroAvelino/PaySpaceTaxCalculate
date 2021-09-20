using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaySpaceTaxCalculate.Application.InputModels;
using PaySpaceTaxCalculate.Application.Services;
using PaySpaceTaxCalculate.Core.Entities;

namespace PaySpaceTaxCalculate.API.Controllers
{
    [Route("api/[controller]")]
    public class CalculateTaxRateController
    {
        public CalculateTaxRateController()
        { }
        [HttpGet("{annualIncome}, {rate}")]
        public decimal Get(decimal annualIncome, decimal rate)
        {
            var value = new CalculateTaxRateInputModel
            {
                AnnualIncome = annualIncome,
                Rate = rate
            };

            return new CalculateTaxRateService().Calculate(value);
        }
    }
}
