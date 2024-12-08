using flodraulicproject.Models.ViewModels;
using flodraulicproject.Models;
using Microsoft.AspNetCore.Mvc;
using flodraulicproject.DataAccess.Data;
using flodraulicproject.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace flodraulicproject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EngineerController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EngineerController(ApplicationDbContext db, IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var objProductList = _unitOfWork.Engineer.GetAll().ToList();

            return View(objProductList);
        }

        public IActionResult Upsert(int? id)
        {

            if (id == null || id == 0)
            {
                //create
                return View();
            }
            else
            {
                //update
                var engineer = _unitOfWork.Engineer.Get(u => u.Id == id);
                return View(engineer);
            }

        }

        [HttpPost]
        public IActionResult Upsert(Engineer engineer, IFormFile? file)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\engineer");

                    if (!string.IsNullOrEmpty(engineer.ImageUrl))
                    {
                        //delete the old image
                        var oldImagePath =
                            Path.Combine(wwwRootPath, engineer.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    engineer.ImageUrl = @"\images\engineer\" + fileName;
                }

                if (engineer.Id == 0)
                {
                    _unitOfWork.Engineer.Add(engineer);
                }
                else
                {
                    _unitOfWork.Engineer.Update(engineer);
                }

                //_db.Categories.Add(c);
                //_unitOfWork.Product.Add(productVM.Product);
                //_db.SaveChanges();
                _unitOfWork.Save();
                TempData["success"] = "Engineer created successfully";
                return RedirectToAction("Index", "Engineer");
            }
            else
            {
                return View(engineer);
            }
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Engineer> objProductList = _unitOfWork.Engineer.GetAll().ToList();
            return Json(new { data = objProductList });
        }

        //[HttpDelete]
        public IActionResult Delete(int? id)
        {
            var productToBeDeleted = _unitOfWork.Product.Get(u => u.Id == id);
            if (productToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            var oldImagePath =
                            Path.Combine(_webHostEnvironment.WebRootPath,
                            productToBeDeleted.ImageUrl.TrimStart('\\'));

            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.Product.Remove(productToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Successful" });
        }

        #endregion

    }
}
