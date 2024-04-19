using MyEmployee.Models.Main_Models;

namespace MyEmployee.Data.Services
{
    public interface IEmployeeServices
    {
        IEnumerable<Employee> GetAll();
        Task AddEmployee(Employee employee);
        Task<Employee> GetEmployeeById(int Id);
        Task DeleteEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
    }
}
