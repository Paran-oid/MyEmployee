using Microsoft.EntityFrameworkCore;
using MyEmployee.Models.Main_Models;

namespace MyEmployee.Data.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly ApplicationDbContext _context;

        public EmployeeServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            var employees = _context.Employees;
            return employees;
        }

        public async Task AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }
    }
}
