using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using PaySpaceTaxCalculate.Core.Entities;
using PaySpaceTaxCalculate.Core.Interfaces.Repository;
using PaySpaceTaxCalculate.Infrastructure.Persistence;

namespace PaySpaceTaxCalculate.Application.Services
{
    public class TaxRateService : IDal<TaxRate>
    {
        private readonly IConfiguration _configuration;
        public TaxRateService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public TaxRate Insert(TaxRate value)
        {
            return new PaySpaceTaxCalculateDbContext().TaxRateRepositoryDbContext(_configuration).Insert(value);
        }

        public bool Edit(TaxRate value)
        {
            return new PaySpaceTaxCalculateDbContext().TaxRateRepositoryDbContext(_configuration).Edit(value);
        }

        public bool Delete(TaxRate value)
        {
            throw new NotImplementedException();
        }

        public bool Delete(object id)
        {
            return new PaySpaceTaxCalculateDbContext().TaxRateRepositoryDbContext(_configuration).Delete(id);
        }

        public TaxRate Find(object id)
        {
            return new PaySpaceTaxCalculateDbContext().TaxRateRepositoryDbContext(_configuration).Find(id);
        }

        public IEnumerable<TaxRate> List()
        {
            return new PaySpaceTaxCalculateDbContext().TaxRateRepositoryDbContext(_configuration).List();
        }
    }
}
