using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;
using WebMVC.Repository.Base;

namespace WebMVC.Controllers
{
    [Authorize]

    public class CategoryController : Controller
    {
        // By Using Repository Pattern

        private readonly IUniteOfWork _myUnit;

        public CategoryController(IUniteOfWork myUnit)
        {
            _myUnit = myUnit;
        }

        /**  public IActionResult Index()
          {
              var Categories = _repository.GetAll();
              return View(Categories);
          } **/

        //Get
        public async Task<IActionResult> Index()
        {
            var oneCat = _myUnit.categories.SelectOne(x => x.CategoryName == "Computers");

            var allCat = await _myUnit.categories.GetAllAsync("Items");

            return View(allCat);
        }

        //Get 
        public IActionResult Create()
        {

            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _myUnit.categories.AddOne(category);
                TempData["SuccessDate"] = "The Category is Added Successfuly";
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }

        }

        //Get 
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0) { return NotFound(); }
            var category = _myUnit.categories.GetById(Id.Value);
            return View(category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _myUnit.categories.UpdateOne(category);
            }
            else
            {
                return View(category);
            }
            TempData["SuccessDate"] = "The Category Updated Successfuly";
            return RedirectToAction("Index");
        }

        //Get

        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
                return NotFound();
            var category = _myUnit.categories.GetById(Id.Value);
            if (category == null)
                return NotFound();
            return View(category);
        }

        [HttpPost,]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCategory(int? id)
        {
            if (id is null || id == 0)
                return NotFound();
            var item = _myUnit.categories.GetById(id.Value);
            if (item == null)
                return NotFound();
            _myUnit.categories.DeleteOne(item);
            TempData["successDate"] = "Item Has Been Deleted Successfuly";
            return RedirectToAction("Index");

        }
    }
}
