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

    public class ServiceManualController : Controller
    {

        //private readonly ApplicationDbContext _db;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        //public CategoryController(ApplicationDbContext db)
        public ServiceManualController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            
            //var objCategoryList = _db.Categories.ToList();
            var objProductList = _unitOfWork.ServiceManual.GetAll().ToList();
            return View(objProductList);
           
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
                var serviceManual = new Models.ServiceManual();
                return View(serviceManual);
            }
            else
            {
                //update
                var serviceManual = _unitOfWork.ServiceManual.Get(u => u.Id == id);
                return View(serviceManual);
            }

        }

        [HttpPost]
        public IActionResult Upsert(ServiceManual serviceManual, IFormFile? file)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\servicemanual");

                    if (!string.IsNullOrEmpty(serviceManual.ImageUrl))
                    {
                        //delete the old image
                        var oldImagePath =
                            Path.Combine(wwwRootPath, serviceManual.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    serviceManual.ImageUrl = @"\images\servicemanual\" + fileName;
                }

                if (serviceManual.Id == 0)
                {
                    _unitOfWork.ServiceManual.Add(serviceManual);
                }
                else
                {
                    _unitOfWork.ServiceManual.Update(serviceManual);
                }

                //_db.Categories.Add(c);
                //_unitOfWork.Product.Add(productVM.Product);
                //_db.SaveChanges();
                _unitOfWork.Save();
                TempData["success"] = "Manual created successfully";
                return RedirectToAction("Index", "ServiceManual");
            }
            else
            {
                return View(serviceManual);
            }
        }

        public IActionResult Download(int? id)
        {
            //string wwwRootPath = _webHostEnvironment.WebRootPath;

            //string productPath = Path.Combine(wwwRootPath, @"images\workinstruction");

            //byte[] bytes = Encoding.UTF8.GetBytes("WI");
            //return File(bytes, productPath, "fileName");

            var sm = _unitOfWork.ServiceManual.Get(u => u.Id == id);
            var fileName = sm.ImageUrl.Split(new[] { '\\' }).Last();

            var filepath = Path.Combine(_webHostEnvironment.WebRootPath, "images/servicemanual", fileName);
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
            List<ServiceManual> objProductList = _unitOfWork.ServiceManual.GetAll().ToList();
            return Json(new { data = objProductList });
        }

        //[HttpDelete]
        public IActionResult Delete(int? id)
        {
            var manualToBeDeleted = _unitOfWork.ServiceManual.Get(u => u.Id == id);
            if (manualToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            var oldImagePath =
                            Path.Combine(_webHostEnvironment.WebRootPath,
                            manualToBeDeleted.ImageUrl.TrimStart('\\'));

            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.ServiceManual.Remove(manualToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Successful" });
        }

        #endregion
    }
}
