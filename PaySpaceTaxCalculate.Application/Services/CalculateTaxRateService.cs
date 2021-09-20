using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PaySpaceTaxCalculate.Application.InputModels;
using PaySpaceTaxCalculate.Infrastructure.Persistence.Repository;

namespace PaySpaceTaxCalculate.Application.Services
{
    public class CalculateTaxRateService
    {
        private readonly IConfiguration _configuration;

        public CalculateTaxRateService(IConfiguration configuration = null)
        {
            _configuration = configuration;
        }

        public decimal CalculateTaxRate(CalculateTaxRateInputModel calculateTaxRateInputModel)
        {
            var postalCodes =  new PostalCodeService(_configuration).List();
            var taxRates = new TaxRateService(_configuration).List();
            var taxRateCalculated = 0.0M;
            foreach (var postalCode in postalCodes)
            {
                if (!postalCode.Code.Trim().Equals(calculateTaxRateInputModel.PostalCode.Trim())) 
                    continue;
                foreach (var taxRate in taxRates)
                {

                    if (taxRate.TaxCalculationTypeId.Equals(postalCode.TaxCalculationTypeId) &&
                        (taxRate.MaxEarns >= calculateTaxRateInputModel.AnnualIncome))
                    {
                        taxRateCalculated = Calculate(new CalculateTaxRateInputModel()
                            { AnnualIncome = calculateTaxRateInputModel.AnnualIncome, Rate = taxRate.TaxPercentage });
                        break;
                    }

                }
            }

            return taxRateCalculated;

        }
        public decimal Calculate(CalculateTaxRateInputModel calculateTaxRateInputModel)
        {
            return calculateTaxRateInputModel.AnnualIncome * (calculateTaxRateInputModel.Rate / 100);
        }
    }

}
