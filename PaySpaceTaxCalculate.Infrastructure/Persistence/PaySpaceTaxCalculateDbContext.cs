using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PaySpaceTaxCalculate.Infrastructure.Persistence.Repository;

namespace PaySpaceTaxCalculate.Infrastructure.Persistence
{
    public class PaySpaceTaxCalculateDbContext
    {
        public PostalCodeRepository PostalCodeDbContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("PaySpaceTaxCalculateDbConnectionString");
            return new PostalCodeRepository(new Connection(connectionString));
        }

        public TaxRateRepository TaxRateRepositoryDbContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("PaySpaceTaxCalculateDbConnectionString");
            return new TaxRateRepository(new Connection(connectionString));
        }

        public TaxCalculationTypeRepository TaxCalculationTypeRepositoryDbContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("PaySpaceTaxCalculateDbConnectionString");
            return new TaxCalculationTypeRepository(new Connection(connectionString));
        }

        public LogCalculateTaxRepository LogCalculateTaxRepositoryDbContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("PaySpaceTaxCalculateDbConnectionString");
            return new LogCalculateTaxRepository(new Connection(connectionString));
        }
    }
}
