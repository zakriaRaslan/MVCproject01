using WebMVC.Areas.Employees.Models;

namespace WebMVC.Repository.Base
{
    public interface IEmpRepo : IRepository<Employee>
    {
        void SetPayRoll(Employee employee);
        decimal GetSallary(Employee employee);
    }
}
