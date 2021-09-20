using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaySpaceTaxCalculate.Core.Entities
{
    public class TaxRate
    {
        public int Id { get; set; }
        public decimal MaxEarns { get; set; }
        public decimal TaxPercentage { get; set; }
        public int TaxCalculationTypeId { get; set; }

        public TaxRate(int id, decimal maxEarns, decimal taxPercentage, int taxCalculationTypeId)
        {
            Id = id;
            MaxEarns = maxEarns;
            TaxPercentage = taxPercentage;
            TaxCalculationTypeId = taxCalculationTypeId;
        }
    }
}
