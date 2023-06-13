using WebMVC.Areas.Employees.Models;
using WebMVC.Data;
using WebMVC.Repository.Base;

namespace WebMVC.Repository
{
    public class EmpRepo : MainRepository<Employee>, IEmpRepo
    {
        private readonly AppDbContext _context;

        public EmpRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public decimal GetSallary(Employee employee)
        {
            if (employee == null || employee.Id == null)
            {
                throw new ArgumentNullException();
            }
            if (employee.EmployeeSalary == null)
            {
                employee.EmployeeSalary = 0;
            }

            return (decimal)_context.Employees.SingleOrDefault(x => x.Id == employee.Id).EmployeeSalary;


        }

        public void SetPayRoll(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
