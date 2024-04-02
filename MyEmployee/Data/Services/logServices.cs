
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyEmployee.Data.Migrations;
using MyEmployee.Models.Admin_Management;

namespace MyEmployee.Data.Services
{
    public class LogServices : ILogServices
    {
        private readonly ApplicationDbContext _context;
        
        public LogServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ApplicationLog> GetAll()
        {
            var res = _context.ApplicationLogs.OrderByDescending(l => l.TimeStamp);
            return res;
        }

        public async Task LogErrorAsync(string info, string username)
        {
            ApplicationLog log = new ApplicationLog
            {
                Action = info,
                Username = username,
                TimeStamp = DateTimeOffset.Now,
                Level = "Error"
            };
             _context.ApplicationLogs.Add(log);
             await _context.SaveChangesAsync();
        }

        public async Task LogInformationAsync(string info, string username)
        {
            ApplicationLog log = new ApplicationLog
            {
                Action = info,
                Username = username,
                TimeStamp = DateTimeOffset.Now,
                Level = "Information"
            };
            _context.ApplicationLogs.Add(log);
            await _context.SaveChangesAsync();
        }

        public async Task LogWarningAsync(string info, string username)
        {
            ApplicationLog log = new ApplicationLog
            {
                Action = info,
                Username = username,
                TimeStamp = DateTimeOffset.Now,
                Level = "Warning"
            };
            _context.ApplicationLogs.Add(log);
            await _context.SaveChangesAsync();
        }
    }
}
