using MyEmployee.Models.Main_Models;

namespace MyEmployee.Data.Services.EmployeeRelated
{
    public class EmployeeHistoryServices : IEmployeeHistoryServices
    {
        private readonly ApplicationDbContext _context; 
        public EmployeeHistoryServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Log(EmployeeHistory log)
        {
            _context.EmployeeHistory.Add(log);
            await _context.SaveChangesAsync();
        }
    }
}
