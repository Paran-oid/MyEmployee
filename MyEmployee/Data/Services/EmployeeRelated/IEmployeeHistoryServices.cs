using MyEmployee.Models.Main_Models;
namespace MyEmployee.Data.Services.EmployeeRelated
{
    public interface IEmployeeHistoryServices
    {
        Task Log(EmployeeHistory log);
    }
}
