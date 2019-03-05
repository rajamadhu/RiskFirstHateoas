using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RiskFirst.Hateoas;
using SampleLink.Model;

namespace SampleLink.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILinksService _linksService;
        public ValuesController(ILinksService linksService )
        {
            _linksService = linksService;
        }
        // GET api/values
        //[Links]
        [HttpGet("~/v2/location/{id:int}", Name = "LocationV2")]
        [HttpGet("~/location/{id:int}", Name = "Location")]
        public async Task<ActionResult<Location>> GetAsync(int id)
        {
            try
            {
                Location location = new Location();
                location.Id = id;
                await _linksService.AddLinksAsync(location);
                return location;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
