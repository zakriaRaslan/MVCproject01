using System.ComponentModel.DataAnnotations;

namespace WebMVC.Areas.Employees.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string EmployeePhone { get; set; }
        public string? EmployeeEmail { get; set; }
        public byte? EmployeeAge { get; set; }
        public int? EmployeeSalary { get; set; }

    }
}
