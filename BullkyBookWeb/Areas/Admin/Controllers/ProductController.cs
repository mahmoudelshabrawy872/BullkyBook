using BallkyBook.DataAccess.Repository.IRepository;
using BallkyBook.Modles.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BullkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IWebHostEnvironment   _hostEnvironment;
        
        public ProductController(IUniteOfWork uniteOfWork,IWebHostEnvironment hostEnvironment)
        {
            _uniteOfWork = uniteOfWork;
            _hostEnvironment= hostEnvironment;
        }


        public IActionResult Index()
        {
            return View();
        }



        //GET
        public IActionResult Upsert(int? id)
        {
            ProductVM productVM = new()
            {
                Product = new(),
                CategoryList = _uniteOfWork.Category.GetAll().Select(a => new SelectListItem
                {
                    Text = a.name,
                    Value = a.id.ToString(),

                }),
                CoverTypeList=_uniteOfWork.CoverType.GetAll().Select(a => new SelectListItem
                {
                    Text=a.Name,
                    Value=a.Id.ToString(),
                })
            };


            if (id == null || id == 0)
            {
             return View(productVM);
            }
            else
            {
                productVM.Product = _uniteOfWork.Product.GetFristOrDefault(a=>a.Id==id);
                 return View(productVM);
            }
        }
        
       //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProductVM obj,IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (file!=null)
                {
                    string fileName=Guid.NewGuid().ToString();
                    var uplouds=Path.Combine(wwwRootPath, @"images\products");
                    var extension = Path.GetExtension(file.FileName);
                    if (obj.Product.ImageUrl!=null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, obj.Product.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStreams = new FileStream(Path.Combine(uplouds, fileName + extension), FileMode.Create)) 
                    {
                        file.CopyTo(fileStreams);
                    }
                    obj.Product.ImageUrl = @"\images\products\" + fileName + extension;
                }
                if (obj.Product.Id==0)
                {
                _uniteOfWork.Product.Add(obj.Product);
                }
                else
                {
                    _uniteOfWork.Product.Update(obj.Product);
                }
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
            var productFromDb = _uniteOfWork.Product.GetFristOrDefault(a => a.Id == id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, productFromDb.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            _uniteOfWork.Product.Delete(productFromDb);
            _uniteOfWork.Save();
            return RedirectToAction("Index");
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
        [HttpGet]
        public IActionResult GetAll()
        {
            var ProdcutList = _uniteOfWork.Product.GetAll(includeProperties:"Category,CoverType");
            return Json(new { data = ProdcutList });
        }

    }

}
