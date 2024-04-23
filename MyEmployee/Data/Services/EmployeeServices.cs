using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyEmployee.Data.Migrations;
using MyEmployee.Models;
using MyEmployee.Models.Main_Models;
using System.Security.Claims;

namespace MyEmployee.Data.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public EmployeeServices(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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

        public async Task<Employee> GetEmployeeById(int Id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == Id);
            return employee;
        }

        public async Task DeleteEmployee(Employee employee)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Employee> GetEmployees(string managerId)
        {
            var employees = _context.Employees
            .Where(e => e.ManagerId == managerId);
            return employees;
        }
    }
}
