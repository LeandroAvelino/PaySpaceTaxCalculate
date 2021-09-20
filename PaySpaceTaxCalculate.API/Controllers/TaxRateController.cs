using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PaySpaceTaxCalculate.Application.Services;
using PaySpaceTaxCalculate.Core.Entities;

namespace PaySpaceTaxCalculate.API.Controllers
{
    [Route("api/[controller]")]
    public class TaxRateController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public TaxRateController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public IEnumerable<TaxRate> Get()
        {
            return new TaxRateService(_configuration).List();
            //return new PaySpaceTaxCalculateDbContext().PostalCodeDbContext(_configuration).List();
        }
        [HttpGet("{id}")]
        public TaxRate Get(int id)
        {
            return new TaxRateService(_configuration).Find(id);
        }
        [HttpPost]
        public ObjectResult Post([FromBody] TaxRate value)
        {
            value = new TaxRateService(_configuration).Insert(value);
            return Ok(value);
        }

        [HttpPut("{id}")]
        public ObjectResult Put(int id, [FromBody] TaxRate value)
        {
            if (new TaxRateService(_configuration).Edit(value))
            {
                return Ok(value);
            }
            return new NotFoundObjectResult(value);
        }

        [HttpDelete("{id}")]
        public ObjectResult Delete(int id)
        {
            if (new TaxRateService(_configuration).Delete(id))
            {
                return Ok(new { Status = "Success", Id = id });
            }
            return new NotFoundObjectResult(new { Status = "NotFound", Id = id });
        }
    }
}
