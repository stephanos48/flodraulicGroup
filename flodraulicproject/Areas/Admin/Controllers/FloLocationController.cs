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
    public class FloLocationController : Controller
    {
        //private readonly ApplicationDbContext _db;
        private readonly IUnitOfWork _unitOfWork;
        //public CustomerLocationController(ApplicationDbContext db)
        public FloLocationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            //var objCustomerLocationList = _db.Categories.ToList();
            var objFloLocationList = _unitOfWork.FloLocation.GetAll().ToList();
            return View(objFloLocationList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(FloLocation c) 
        {

            if (ModelState.IsValid)
            {
                //_db.Categories.Add(c);
                _unitOfWork.FloLocation.Add(c);
                //_db.SaveChanges();
                _unitOfWork.Save();
                TempData["success"] = "FloLocation created successfully";
                return RedirectToAction("Index", "FloLocation");
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
            FloLocation? FloLocationFromDb = _unitOfWork.FloLocation.Get(u => u.FloLocationId == id);
            //CustomerLocation? CustomerLocationFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //CustomerLocation? CustomerLocationFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();
            if (FloLocationFromDb == null)
            {
                return NotFound();
            }
            return View(FloLocationFromDb);
        }

        [HttpPost]
        public IActionResult Edit(FloLocation c)
        {
            if (ModelState.IsValid)
            {
                //_db.Categories.Update(c);
                _unitOfWork.FloLocation.Update(c);
                //_db.SaveChanges();
                _unitOfWork.Save();
                TempData["success"] = "FloLocation updated successfully";
                return RedirectToAction("Index", "FloLocation");
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
            FloLocation? FloLocationFromDb = _unitOfWork.FloLocation.Get(u => u.FloLocationId == id);
            //CustomerLocation? CustomerLocationFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //CustomerLocation? CustomerLocationFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();
            if (FloLocationFromDb == null)
            {
                return NotFound();
            }
            return View(FloLocationFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            //CustomerLocation? c = _db.Categories.Find(id);
            FloLocation? c = _unitOfWork.FloLocation.Get(u => u.FloLocationId == id);
            if (c == null)
            {
                return NotFound();
            }
            //_db.Categories.Remove(c);
            _unitOfWork.FloLocation.Remove(c);
            //_db.SaveChanges();
            _unitOfWork.Save();
            TempData["success"] = "FloLocation deleted successfully";
            return RedirectToAction("Index", "FloLocation");

        }
    }
}
