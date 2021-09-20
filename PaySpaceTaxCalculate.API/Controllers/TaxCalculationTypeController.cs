using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PaySpaceTaxCalculate.Application.Services;
using PaySpaceTaxCalculate.Core.Entities;

namespace PaySpaceTaxCalculate.API.Controllers
{
    [Route("api/[controller]")]
    public class TaxCalculationTypeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public TaxCalculationTypeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public IEnumerable<TaxCalculationType> Get()
        {
            return new TaxCalculationTypeService(_configuration).List();
            //return new PaySpaceTaxCalculateDbContext().PostalCodeDbContext(_configuration).List();
        }
        [HttpGet("{id}")]
        public TaxCalculationType Get(int id)
        {
            return new TaxCalculationTypeService(_configuration).Find(id);
        }
        [HttpPost]
        public ObjectResult Post([FromBody] TaxCalculationType value)
        {
            value = new TaxCalculationTypeService(_configuration).Insert(value);
            return Ok(value);
        }

        [HttpPut("{id}")]
        public ObjectResult Put(int id, [FromBody] TaxCalculationType value)
        {
            if (new TaxCalculationTypeService(_configuration).Edit(value))
            {
                return Ok(value);
            }
            return new NotFoundObjectResult(value);
        }

        [HttpDelete("{id}")]
        public ObjectResult Delete(int id)
        {
            if (new TaxCalculationTypeService(_configuration).Delete(id))
            {
                return Ok(new { Status = "Success", Id = id });
            }
            return new NotFoundObjectResult(new { Status = "NotFound", Id = id });
        }
    }
}
