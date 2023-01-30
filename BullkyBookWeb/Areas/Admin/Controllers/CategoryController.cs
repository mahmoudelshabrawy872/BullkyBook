using BallkyBook.DataAccess;
using BallkyBook.DataAccess.Repository.IRepository;
using BallkyBook.Modles;

using Microsoft.AspNetCore.Mvc;

namespace BullkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUniteOfWork _uniteOfWork;
        public CategoryController(IUniteOfWork uniteOfWork)
        {
            _uniteOfWork = uniteOfWork;
        }


        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _uniteOfWork.Category.GetAll();
            return View(objCategoryList);
        }


        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {

                _uniteOfWork.Category.Add(obj);
                _uniteOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }
            var CategoryFromDb = _uniteOfWork.Category.GetFristOrDefault(a => a.id == id);
            if (CategoryFromDb == null)
            {
                return NotFound();
            }

            return View(CategoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _uniteOfWork.Category.Update(obj);
                _uniteOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(obj);

        }


        //GET
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            var CategoryFromDb = _uniteOfWork.Category.GetFristOrDefault(a => a.id == id);
            if (CategoryFromDb == null)
            {
                return NotFound();
            }

            return View(CategoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int id)
        {
            var obj = _uniteOfWork.Category.GetFristOrDefault(a => a.id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _uniteOfWork.Category.Delete(obj);
            _uniteOfWork.Save();
            return RedirectToAction("Index");

        }


    }
}
