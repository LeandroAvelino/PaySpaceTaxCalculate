using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PaySpaceTaxCalculate.Application.Services;
using PaySpaceTaxCalculate.Core.Entities;

namespace PaySpaceTaxCalculate.API.Controllers
{
    [Route("api/[controller]")]
    public class LogCalculateTaxController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public LogCalculateTaxController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        public ObjectResult Post([FromBody] LogCalculateTax value)
        {
            value = new LogCalculateTaxService(_configuration).Insert(value);
            return Ok(value);
        }
    }
}
