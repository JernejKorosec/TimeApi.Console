using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using TimeApi.Console.Client;
using TimeApi.Console.Client.DTO;
using TimeApi.Console.Client.Client;

namespace TimeApi.Console
{
    class Program
    {
        static void Main(String[] args)
        {
            SpicaClient cs = new SpicaClient();
            
            // Set Session
            cs.setSession();

            // Get All Employees
            List<Employee> listOfEmployees = cs.getAllEmployees();

            
            // Search by firstname and lastname
            Employee CheapIndieWhoCantWriteCode = new Employee
            {
                FirstName = "Consalve",
                LastName = "McPhate"
            };

            List<Employee> listOfEmployeesByProperties = cs.getAllEmployeesByProperties(CheapIndieWhoCantWriteCode);
            var cheapIndieToFire = listOfEmployeesByProperties.First();

            // Adding new employee
            Employee DriftMaster = new Employee
            {
                FirstName = "Jernej",
                LastName = "Korosec",
                Email = "programerskopodjetje@gmail.com",
                AdditionalField1 = "86261169"       // Matična številka med propertiji ne obstaja, dodal sem jo v additional field

            };

            Employee TestJoe = new Employee
            {
                FirstName = "Joe1",
                LastName = "Mo1e",
                Email = "noemail@emailat.email",
                AdditionalField1 = "11223344"       

            };

            bool employeeAdded = cs.AddNewEmployee(TestJoe);


            //29.1.2022 18:43:00

            int orgUnit = 10000000;
            bool showInactiveEmployees = false;
            bool showActiveEmployees = true;

            DateTime localDate = DateTime.Now; // Del apija mi je crknil. Nekdo je izklopil demo api okoli 22ih, verjetno se kej updatea

            List<Employee> listOfEmployeesCurrentlyPresent = cs.getAllEmployeesByPresence(orgUnit,showInactiveEmployees,localDate);

            int BreakPoint = 0;
        }
    }
}