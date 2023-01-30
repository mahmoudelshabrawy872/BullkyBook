using BallkyBook.DataAccess.Repository;
using BallkyBook.DataAccess.Repository.IRepository;
using BallkyBook.Modles;
using Microsoft.AspNetCore.Mvc;

namespace BullkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        private  readonly IUniteOfWork _uniteOfWork;
        public CoverTypeController( IUniteOfWork uniteOfWork)
        {
            _uniteOfWork= uniteOfWork;
        }
      
        public IActionResult Index()
        {
            IEnumerable<CoverType> objcovertype =_uniteOfWork.CoverType.GetAll();
            return View(objcovertype);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType coverType)
        {
            if (ModelState.IsValid)
            {
                _uniteOfWork.CoverType.Add(coverType);
                _uniteOfWork.Save();
                return RedirectToAction("Index");   
            }
            return View(coverType);
        }
        public IActionResult Edit(int id)
        {
            if (id<=0)
            {
                return NotFound();
            }
            var SelectedCoverTypr = _uniteOfWork.CoverType.GetFristOrDefault(a => a.Id == id);
            if (SelectedCoverTypr == null)
            {
                return NotFound();
            }
            return View(SelectedCoverTypr);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType coverType )
        {
            if (ModelState.IsValid)
            {
                _uniteOfWork.CoverType.Update(coverType);
                _uniteOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(coverType);
        }
        public IActionResult Delete(int id)
        {
            if (id<=0)
            {
                return NotFound();
            }
            var SelectedCoverType=_uniteOfWork.CoverType.GetFristOrDefault(a=>a.Id== id);
            if (SelectedCoverType == null)
            {
                return NotFound();
            }
            _uniteOfWork.CoverType.Delete(SelectedCoverType);
            _uniteOfWork.Save();
            return RedirectToAction("Index");
        }

        
    }
}
