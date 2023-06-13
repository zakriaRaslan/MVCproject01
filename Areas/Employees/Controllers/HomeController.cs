using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;

namespace WebMVC.Areas.Employees.Controllers
{
    [Area("Employees"), Authorize(Roles = clsRole.AdminRole)]
    public class HomeController : Controller
    {
        [Authorize]

        public IActionResult Index()
        {
            return View();
        }
    }
}
