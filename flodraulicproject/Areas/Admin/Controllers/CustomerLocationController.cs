using flodraulicproject.DataAccess.Data;
using flodraulicproject.DataAccess.Repository.IRepository;
using flodraulicproject.Models;
using flodraulicproject.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace flodraulicproject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CustomerLocationController : Controller
    {
        //private readonly ApplicationDbContext _db;
        private readonly IUnitOfWork _unitOfWork;
        //public CustomerLocationController(ApplicationDbContext db)
        public CustomerLocationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            //var objCustomerLocationList = _db.Categories.ToList();
            var objCustomerLocationList = _unitOfWork.CustomerLocation.GetAll().ToList();
            return View(objCustomerLocationList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerLocation c) 
        {

            if (ModelState.IsValid)
            {
                //_db.Categories.Add(c);
                _unitOfWork.CustomerLocation.Add(c);
                //_db.SaveChanges();
                _unitOfWork.Save();
                TempData["success"] = "CustomerLocation created successfully";
                return RedirectToAction("Index", "CustomerLocation");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            //CustomerLocation? CustomerLocationFromDb = _db.Categories.Find(id);
            CustomerLocation? CustomerLocationFromDb = _unitOfWork.CustomerLocation.Get(u => u.CustomerLocationId == id);
            //CustomerLocation? CustomerLocationFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //CustomerLocation? CustomerLocationFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();
            if (CustomerLocationFromDb == null)
            {
                return NotFound();
            }
            return View(CustomerLocationFromDb);
        }

        [HttpPost]
        public IActionResult Edit(CustomerLocation c)
        {
            if (ModelState.IsValid)
            {
                //_db.Categories.Update(c);
                _unitOfWork.CustomerLocation.Update(c);
                //_db.SaveChanges();
                _unitOfWork.Save();
                TempData["success"] = "CustomerLocation updated successfully";
                return RedirectToAction("Index", "CustomerLocation");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //CustomerLocation? CustomerLocationFromDb = _db.Categories.Find(id);
            CustomerLocation? CustomerLocationFromDb = _unitOfWork.CustomerLocation.Get(u => u.CustomerLocationId == id);
            //CustomerLocation? CustomerLocationFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //CustomerLocation? CustomerLocationFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();
            if (CustomerLocationFromDb == null)
            {
                return NotFound();
            }
            return View(CustomerLocationFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            //CustomerLocation? c = _db.Categories.Find(id);
            CustomerLocation? c = _unitOfWork.CustomerLocation.Get(u => u.CustomerLocationId == id);
            if (c == null)
            {
                return NotFound();
            }
            //_db.Categories.Remove(c);
            _unitOfWork.CustomerLocation.Remove(c);
            //_db.SaveChanges();
            _unitOfWork.Save();
            TempData["success"] = "CustomerLocation deleted successfully";
            return RedirectToAction("Index", "CustomerLocation");

        }
    }
}
