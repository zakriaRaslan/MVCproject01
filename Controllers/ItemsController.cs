using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebMVC.Data;
using WebMVC.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace WebMVC.Controllers
{
    [Authorize]
    public class ItemsController : Controller
    {
        //Without Using Repository Pattern

        private readonly AppDbContext _context;
        private readonly IHostingEnvironment _Host;


        public ItemsController(AppDbContext context, IHostingEnvironment Host)
        {
            _context = context;
            _Host = Host;
        }

        public IActionResult Index()
        {
            IEnumerable<Item> ItemsList = _context.Items.Include(x => x.Category).ToList();
            return View(ItemsList);
        }

        //Get
        public IActionResult Create()
        {
            Categorylist();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item item)
        {
            if (ModelState.IsValid)
            {

                string filename = string.Empty;

                if (item.ClientFile != null)
                {
                    string MyUpload = Path.Combine(_Host.WebRootPath, "Images");
                    filename = item.ClientFile.Name;
                    string fullpath = Path.Combine(MyUpload, filename);
                    item.ClientFile.CopyTo(new FileStream(fullpath, FileMode.Create));
                    item.ImgPath = filename;
                }
                _context.Items.Add(item);
                _context.SaveChanges();
                TempData["successDate"] = "Item Has Been Added Successfuly";

                return RedirectToAction("Index");
            }
            else
            {
                return View(item);
            }

        }

        //Get
        public IActionResult Edit(int id)
        {
            var item = _context.Items.SingleOrDefault(x => x.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            Categorylist(item.CategoryId);

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Items.Update(item);
                _context.SaveChanges();
            }
            else
            {
                return View(item);
            }
            TempData["successDate"] = "Item Has Been Edited Successfuly";

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id is null || id == 0)
                return NotFound();

            var item = _context.Items.SingleOrDefault(x => x.Id == id);
            if (item == null)
                return NotFound();

            Categorylist(item.CategoryId);
            return View(item);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteItem(int? id)
        {
            if (id is null || id == 0)
                return NotFound();
            var item = _context.Items.FirstOrDefault(x => x.Id == id);
            if (item == null)
                return NotFound();
            _context.Items.Remove(item);
            _context.SaveChanges();
            TempData["successDate"] = "Item Has Been Deleted Successfuly";
            return RedirectToAction("Index");
        }

        public void Categorylist(int Selected = 1)
        {
            List<Category> categories = _context.Categories.ToList();

            SelectList ListItems = new SelectList(categories, "Id", "CategoryName", Selected);
            ViewBag.CategoryList = ListItems;
        }
    }
}
