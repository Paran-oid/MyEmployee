using Microsoft.AspNetCore.Mvc;
using MyEmployee.Data.Migrations;
using MyEmployee.Models.Admin_Management;

namespace MyEmployee.Data.Services
{
    public interface ILogServices
    {
        IEnumerable<ApplicationLog> GetAll();
        Task LogInformationAsync(string info, string username);
        Task LogWarningAsync(string info, string username);
        Task LogErrorAsync(string info, string username);
    }
}
