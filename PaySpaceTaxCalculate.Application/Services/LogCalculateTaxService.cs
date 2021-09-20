using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using PaySpaceTaxCalculate.Core.Entities;
using PaySpaceTaxCalculate.Core.Interfaces.Repository;
using PaySpaceTaxCalculate.Infrastructure.Persistence;

namespace PaySpaceTaxCalculate.Application.Services
{
    public class LogCalculateTaxService : IDal<LogCalculateTax>
    {
        private readonly IConfiguration _configuration;
        public LogCalculateTaxService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public LogCalculateTax Insert(LogCalculateTax value)
        {
            return new PaySpaceTaxCalculateDbContext().LogCalculateTaxRepositoryDbContext(_configuration).Insert(value);
        }

        public bool Edit(LogCalculateTax value)
        {
            throw new NotImplementedException();
        }

        public bool Delete(LogCalculateTax value)
        {
            throw new NotImplementedException();
        }

        public bool Delete(object id)
        {
            throw new NotImplementedException();
        }

        public LogCalculateTax Find(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LogCalculateTax> List()
        {
            throw new NotImplementedException();
        }
    }
}
