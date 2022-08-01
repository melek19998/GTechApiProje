using GTechProje.API.Models;
using GTechProje.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace GTechProje.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        INumberService _numberService;
        public ValuesController(INumberService service)
        {
            _numberService = service;
        }

        private readonly IDatabase _cache;

        public ValuesController(IDatabase cache)
        {
            _cache = cache;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult SaveNumber(Number numberModel)
        {
            try
            {
                var model = _numberService.SaveNumber(numberModel);
                return Ok(model);                

            }
            catch (Exception)
            {
                return BadRequest();
            }

           
        }

        public void Post([FromBody] KeyValuePair<string, string> keyValue)
        {
            _cache.StringSet(keyValue.Key, keyValue.Value);
        }

    }
}
