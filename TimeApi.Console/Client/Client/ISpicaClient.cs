using TimeApi.Console.Client.DTO;

namespace TimeApi.Console.Client.Client
{
    public interface ISpicaClient
    {
        public bool setSession();
        public List<Employee> getAllEmployees();
        public List<Employee> getAllEmployeesByProperties(Employee employee);
        public bool AddNewEmployee(Employee employee);
        public List<Employee> getAllEmployeesByPresence(int orgUnit, bool showInactiveEmployees, DateTime dateTime);
    }
}