using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaySpaceTaxCalculate.Core.Entities
{
    public class PostalCode
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int TaxCalculationTypeId { get; set; }

        public PostalCode(int id, string code, int taxCalculationTypeId)
        {
            Id = id;
            Code = code;
            TaxCalculationTypeId = taxCalculationTypeId;
        }
    }
}
