using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySpaceTaxCalculate.Core.Entities
{
    public class LogCalculateTax
    {
        public int Id { get; set; }
        public string PostalCode { get; set; }
        public decimal AnnualSalary { get; set; }
        public decimal CalculateTaxValue { get; set; }
        public DateTime DateCalculate { get; set; }

        public LogCalculateTax(int id, string postalCode, decimal annualSalary, decimal calculateTaxValue,
            DateTime dateCalculate)
        {
            Id = id;
            PostalCode = postalCode;
            AnnualSalary = annualSalary;
            CalculateTaxValue = calculateTaxValue;
            DateCalculate = dateCalculate;
        }
    }
}
