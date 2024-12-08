using flodraulicproject.DataAccess.Data;
using flodraulicproject.DataAccess.Repository.IRepository;
using flodraulicproject.Models;
using flodraulicproject.Models.ViewModels;
using flodraulicproject.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using System;
using System.IO;
using System.Net;
using System.Net.Mime;
using System.Text;

namespace flodraulicproject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize()]

    public class WorkInstructionController : Controller
    {

        //private readonly ApplicationDbContext _db;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ApplicationDbContext _db;

        public WorkInstructionController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment, ApplicationDbContext db)
        {
            _db = db;
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            //var objCategoryList = _db.Categories.ToList();
            var objProductList = _unitOfWork.WorkInstruction.GetAll().ToList();

            return View(objProductList);
        }

        public IActionResult GetAllNotAdmin()
        {
            var query = from a in _db.WorkInstructions
                        where a.Id != 2 || a.Id != 5 || a.Id != 6
                        select new
                        {
                            a.Id,
                            a.WIName,
                            a.WIType,
                            a.ImageUrl
                        };
            return View(query);
        }

        public IActionResult Create()
        {
            IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });

            IEnumerable<SelectListItem> PartFamilyList = _unitOfWork.PartFamily
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.FamilyName,
                    Value = u.Id.ToString()
                });

            ViewBag.CategoryList = CategoryList;
            ViewBag.PartFamilyList = PartFamilyList;
            //ViewData["CategoryList"] = CategoryList;
            ProductVM productVM = new ProductVM()
            {
                CategoryList = CategoryList,
                PartFamilyList = PartFamilyList,
                Product = new Product()
            };
            return View(productVM);
        }

        public IActionResult Upsert(int? id)
        {

            if (id == null || id == 0)
            {
                //create
                var workInstruction = new Models.WorkInstruction();
                return View(workInstruction);
            }
            else
            {
                //update
                var workInstruction = _unitOfWork.WorkInstruction.Get(u => u.Id == id);
                return View(workInstruction);
            }

        }

        [HttpPost]
        public IActionResult Upsert(Models.WorkInstruction workInstruction, IFormFile? file)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\workinstruction");

                    if (!string.IsNullOrEmpty(workInstruction.ImageUrl))
                    {
                        //delete the old image
                        var oldImagePath =
                            Path.Combine(wwwRootPath, workInstruction.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    workInstruction.ImageUrl = @"\images\workinstruction\" + fileName;
                }

                if (workInstruction.Id == 0)
                {
                    _unitOfWork.WorkInstruction.Add(workInstruction);
                }
                else
                {
                    _unitOfWork.WorkInstruction.Update(workInstruction);
                }

                //_db.Categories.Add(c);
                //_unitOfWork.Product.Add(productVM.Product);
                //_db.SaveChanges();
                _unitOfWork.Save();
                TempData["success"] = "Instruction created successfully";
                return RedirectToAction("Index", "WorkInstruction");
            }
            else
            {
                return View(workInstruction);
            }
        }

        public IActionResult Download(int? id)
        {
            //string wwwRootPath = _webHostEnvironment.WebRootPath;

            //string productPath = Path.Combine(wwwRootPath, @"images\workinstruction");

            //byte[] bytes = Encoding.UTF8.GetBytes("WI");
            //return File(bytes, productPath, "fileName");

            var wi = _unitOfWork.WorkInstruction.Get(u => u.Id == id);
            var fileName = wi.ImageUrl.Split(new[] { '\\' }).Last();

            var filepath = Path.Combine(_webHostEnvironment.WebRootPath, "images/workinstruction", fileName);
            return File(System.IO.File.ReadAllBytes(filepath), "APPLICATION/octet-stream", System.IO.Path.GetFileName(filepath));

        }

        [HttpPost]
        public IActionResult Create(ProductVM productVM)
        {

            if (ModelState.IsValid)
            {
                //_db.Categories.Add(c);
                _unitOfWork.Product.Add(productVM.Product);
                //_db.SaveChanges();
                _unitOfWork.Save();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index", "Product");
            }
            else
            {
                productVM.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });

                productVM.PartFamilyList = _unitOfWork.PartFamily.GetAll().Select(u => new SelectListItem
                {
                    Text = u.FamilyName,
                    Value = u.Id.ToString()
                });

                return View(productVM);
            }
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //Category? categoryFromDb = _db.Categories.Find(id);
            Product? productFromDb = _unitOfWork.Product.Get(u => u.Id == id);
            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //Category? categoryFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Product c)
        {
            if (ModelState.IsValid)
            {
                //_db.Categories.Update(c);
                _unitOfWork.Product.Update(c);
                //_db.SaveChanges();
                _unitOfWork.Save();
                TempData["success"] = "Product updated successfully";
                return RedirectToAction("Index", "Product");
            }
            return View();
        }



        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Models.WorkInstruction> objProductList = _unitOfWork.WorkInstruction.GetAll().Where(a => a.Id != 2 || a.Id != 5 || a.Id != 6).ToList();
            return Json(new { data = objProductList });
        }

        [HttpGet]
        public IActionResult GetAllAdmin()
        {
            List<Models.WorkInstruction> objProductList = _unitOfWork.WorkInstruction.GetAll().ToList();
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
