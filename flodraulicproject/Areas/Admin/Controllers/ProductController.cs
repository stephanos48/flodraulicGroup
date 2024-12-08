using flodraulicproject.DataAccess.Data;
using flodraulicproject.DataAccess.Repository.IRepository;
using flodraulicproject.Models;
using flodraulicproject.Models.ViewModels;
using flodraulicproject.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace flodraulicproject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Captain)]
    public class ProductController : Controller
    {
        //private readonly ApplicationDbContext _db;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        //public CategoryController(ApplicationDbContext db)
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            //var objCategoryList = _db.Categories.ToList();
            var objProductList = _unitOfWork.Product.GetAll(includeProperties:"PartFamily").ToList();

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
            if (id == null || id == 0)
            {
                //create
                return View(productVM);
            }
            else
            {
                //update
                productVM.Product = _unitOfWork.Product.Get(u=>u.Id == id);
                return View(productVM);
            }

        }

        [HttpPost]
        public IActionResult Upsert(ProductVM productVM, IFormFile? file)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\product");

                    if (!string.IsNullOrEmpty(productVM.Product.ImageUrl))
                    {
                        //delete the old image
                        var oldImagePath = 
                            Path.Combine(wwwRootPath, productVM.Product.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    productVM.Product.ImageUrl = @"\images\product\" + fileName;
                }

                if(productVM.Product.Id == 0)
                {
                    _unitOfWork.Product.Add(productVM.Product);
                }
                else
                {
                    _unitOfWork.Product.Update(productVM.Product);
                }

                //_db.Categories.Add(c);
                //_unitOfWork.Product.Add(productVM.Product);
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
            if(id == null || id == 0)
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

        /*public IActionResult Delete(int? id)
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

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            //Category? c = _db.Categories.Find(id);
            Product? c = _unitOfWork.Product.Get(u => u.Id == id);
            if (c == null)
            {
                return NotFound();
            }
            //_db.Categories.Remove(c);
            _unitOfWork.Product.Remove(c);
            //_db.SaveChanges();
            _unitOfWork.Save();
            TempData["success"] = "Product deleted successfully";
            return RedirectToAction("Index", "Product");

        }*/

        #region API CALLS

            [HttpGet]
            public IActionResult GetAll()
            {
                List<Product> objProductList = _unitOfWork.Product.GetAll(includeProperties: "PartFamily").ToList();
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
