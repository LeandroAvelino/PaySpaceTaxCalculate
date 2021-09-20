using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using PaySpaceTaxCalculate.Core.Entities;
using PaySpaceTaxCalculate.Core.Interfaces.Repository;
using PaySpaceTaxCalculate.Infrastructure.Persistence;

namespace PaySpaceTaxCalculate.Application.Services
{
    public class PostalCodeService : IDal<PostalCode>
    {
        private readonly IConfiguration _configuration;
        public PostalCodeService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<PostalCode> List()
        {
            return new PaySpaceTaxCalculateDbContext().PostalCodeDbContext(_configuration).List();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public PostalCode Insert(PostalCode value)
        {
            return new PaySpaceTaxCalculateDbContext().PostalCodeDbContext(_configuration).Insert(value);
        }

        public bool Edit(PostalCode value)
        {
            return new PaySpaceTaxCalculateDbContext().PostalCodeDbContext(_configuration).Edit(value);
        }

        public bool Delete(PostalCode value)
        {
            throw new NotImplementedException();
        }

        public bool Delete(object id)
        {
            return new PaySpaceTaxCalculateDbContext().PostalCodeDbContext(_configuration).Delete(id);
        }

        public PostalCode Find(object id)
        {
            return new PaySpaceTaxCalculateDbContext().PostalCodeDbContext(_configuration).Find(id);
        }

        
    }
}
