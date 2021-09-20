using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PaySpaceTaxCalculate.Application.InputModels;
using PaySpaceTaxCalculate.Application.Services;
using PaySpaceTaxCalculate.Core.Entities;

namespace PaySpaceTaxCalculate.API.Controllers
{
    [Route("api/[controller]")]
    public class CalculateTaxRateController
    {
        private readonly IConfiguration _configuration;

        public CalculateTaxRateController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //[HttpGet("{annualIncome}, {rate}")]
        //public decimal Get(decimal annualIncome, decimal rate)
        //{
        //    var value = new CalculateTaxRateInputModel
        //    {
        //        AnnualIncome = annualIncome,
        //        Rate = rate
        //    };

        //    return new CalculateTaxRateService().Calculate(value);
        //}

        [HttpGet("{annualIncome}, {postalCode}")]
        public decimal Get(decimal annualIncome, string postalCode)
        {
            var value = new CalculateTaxRateInputModel
            {
                AnnualIncome = annualIncome,
                PostalCode = postalCode
            };

            return new CalculateTaxRateService(_configuration).CalculateTaxRate(value);
        }
    }
}
