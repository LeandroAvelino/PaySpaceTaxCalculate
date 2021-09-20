using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using PaySpaceTaxCalculate.Core.Entities;
using PaySpaceTaxCalculate.Core.Interfaces.Repository;
using PaySpaceTaxCalculate.Infrastructure.Persistence;

namespace PaySpaceTaxCalculate.Application.Services
{
    public class TaxCalculationTypeService : IDal<TaxCalculationType>
    {
        private readonly IConfiguration _configuration;
        public TaxCalculationTypeService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public TaxCalculationType Insert(TaxCalculationType value)
        {
            return new PaySpaceTaxCalculateDbContext().TaxCalculationTypeRepositoryDbContext(_configuration).Insert(value);
        }

        public bool Edit(TaxCalculationType value)
        {
            return new PaySpaceTaxCalculateDbContext().TaxCalculationTypeRepositoryDbContext(_configuration).Edit(value);
        }

        public bool Delete(TaxCalculationType value)
        {
            throw new NotImplementedException();
        }

        public bool Delete(object id)
        {
            return new PaySpaceTaxCalculateDbContext().TaxCalculationTypeRepositoryDbContext(_configuration).Delete(id);
        }

        public TaxCalculationType Find(object id)
        {
            return new PaySpaceTaxCalculateDbContext().TaxCalculationTypeRepositoryDbContext(_configuration).Find(id);
        }

        public IEnumerable<TaxCalculationType> List()
        {
            return new PaySpaceTaxCalculateDbContext().TaxCalculationTypeRepositoryDbContext(_configuration).List();
        }
    }
}
