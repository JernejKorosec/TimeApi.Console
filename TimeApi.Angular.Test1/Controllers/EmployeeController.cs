using Microsoft.AspNetCore.Mvc;
using TimeApi.Console.Client.DTO;

namespace TimeApi.Angular.Test1.Controllers
{
    [ApiController]
    //[Route("api/[controller]")]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private TimeApi.Console.Client.Client.SpicaClient cs = new TimeApi.Console.Client.Client.SpicaClient();
        /*
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
        */

        // GET: <SpicaController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            // Get All Employees
            List<Employee> listOfEmployees = cs.getAllEmployees();

            // Get only active employees
            /*
            int orgUnit = 10000000;
            bool showInactiveEmployees = false;
            List<Employee> listOfEmployeesCurrentlyPresent = cs.getAllEmployeesByPresence(orgUnit, showInactiveEmployees, DateTime.Now);
            */
            return listOfEmployees.ToArray();
            
        }




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
