using Microsoft.AspNetCore.Mvc;

namespace TimeApi.Angular.Test1.Controllers
{
    [ApiController]
    //[Route("api/[controller]")]
    [Route("[controller]")]
    public class SpicaController : ControllerBase
    {
        // GET: <SpicaController>
        [HttpGet]

        public IEnumerable<Spica> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Spica
            {
                Value1 = "Jerry_" + Random.Shared.Next(0, 10),
                Value2 = "Temperature" + Random.Shared.Next(-25, 35),
            })
            .ToArray();
        }

        /*
        public IEnumerable<string> Get()
        {
            return new string[] { "vrednost123", "vrednost456" };
        }
        */
        // GET api/<SpicaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SpicaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SpicaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SpicaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
