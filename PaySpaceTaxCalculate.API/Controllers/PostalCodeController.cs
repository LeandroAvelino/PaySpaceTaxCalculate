using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PaySpaceTaxCalculate.Application.Services;
using PaySpaceTaxCalculate.Core.Entities;

namespace PaySpaceTaxCalculate.API.Controllers
{
    [Route("api/[controller]")]
    public class PostalCodeController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public PostalCodeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IEnumerable<PostalCode> Get()
        {
            return new PostalCodeService(_configuration).List();
            //return new PaySpaceTaxCalculateDbContext().PostalCodeDbContext(_configuration).List();
        }

        [HttpGet("{id}")]
        public PostalCode Get(int id)
        {
            return new PostalCodeService(_configuration).Find(id);
        }

        [HttpPost]
        public ObjectResult Post([FromBody] PostalCode value)
        {
            value = new PostalCodeService(_configuration).Insert(value);
            return Ok(value);
        }

        [HttpPut("{id}")]
        public ObjectResult Put(int id, [FromBody] PostalCode value)
        {
            if (new PostalCodeService(_configuration).Edit(value))
            {
                return Ok(value);
            }
            return new NotFoundObjectResult(value);
        }

        [HttpDelete("{id}")]
        public ObjectResult Delete(int id)
        {
            if (new PostalCodeService(_configuration).Delete(id))
            {
                return Ok(new { Status = "Success", Id = id });
            }
            return new NotFoundObjectResult(new { Status = "NotFound", Id = id });
        }
    }
}
