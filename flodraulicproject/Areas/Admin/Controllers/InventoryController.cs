using flodraulicproject.DataAccess.Data;
using flodraulicproject.DataAccess.Repository.IRepository;
using flodraulicproject.Models;
using flodraulicproject.Models.ViewModels;
using flodraulicproject.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace flodraulicproject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class InventoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IUnitOfWork _unitOfWork;
        public InventoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        /*public InventoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }*/

    public IActionResult Index()
        {

            List<InventoryVM> newInv = new List<InventoryVM> { new InventoryVM() };

            var query = from a in _db.Inventories
                        join y in _db.Products on a.ProductId equals y.Id
                        join r in _db.FloLocations on a.FloLocationId equals r.FloLocationId
                        select a;

            return View("Index", query.ToList());

            /*var inventories = _db.Inventories.ToList();
            var products = _db.Products.ToList();
            var floLocations = _db.FloLocations.ToList();

            var viewModel = new InventoryVM()
            {
                Inventories = inventories,
                Products = products,
                FloLocations = floLocations,
            };
            //var objCategoryList = _unitOfWork.Inventory.GetAll().ToList();
            return View("Index", viewModel);*/
        }

        public IActionResult Create()
        {

            var products = _db.Products.ToList();
            var floLocations = _db.FloLocations.ToList();

            InventoryVM inventoryVM = new InventoryVM()
            {
                Products = products,
                FloLocations = floLocations,
                Inventory = new Inventory()
            };

            //var objCategoryList = _unitOfWork.Inventory.GetAll().ToList();
            return View(inventoryVM);

            /*IEnumerable<SelectListItem> FloLocationList = _unitOfWork.FloLocation
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.LocationName,
                    Value = u.FloLocationId.ToString()
                });

            IEnumerable<SelectListItem> ProductList = _unitOfWork.Product
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.PartNumber,
                    Value = u.Id.ToString()
                });

            ViewBag.FloLocationList = FloLocationList;
            ViewBag.ProductList = ProductList;
            //ViewData["CategoryList"] = CategoryList;
            InventoryVM inventoryVM = new InventoryVM()
            {
                FloLocationList = FloLocationList,
                ProductList = ProductList,
                Inventory = new Inventory()
            };

            return View(inventoryVM);*/
        }

        [HttpPost]
        public IActionResult Create(InventoryVM inventoryVM)
        {
            var locationId = inventoryVM.Inventory.FloLocationId;
            var productId1 = inventoryVM.Inventory.ProductId;

            var location = _db.FloLocations.Where(a => a.FloLocationId == locationId).FirstOrDefault();
            var locationName = location.LocationName;

            var product = _db.Products.Where(a => a.Id == productId1).FirstOrDefault();
            var partNumber = product.PartNumber;

            inventoryVM.Inventory.LocationName = locationName;
            inventoryVM.Inventory.PartNumber = partNumber;

            if (ModelState.IsValid)
            {
                _db.Inventories.Add(inventoryVM.Inventory);
            //_unitOfWork.Inventory.Add(inventoryVM.Inventory);
                _db.SaveChanges();
                //_unitOfWork.Save();
                TempData["success"] = "Inventory created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                /*inventoryVM.FloLocationList = _unitOfWork.FloLocation.GetAll().Select(u => new SelectListItem
                {
                    Text = u.LocationName,
                    Value = u.FloLocationId.ToString()
                });

                inventoryVM.ProductList = _unitOfWork.Product.GetAll().Select(u => new SelectListItem
                {
                    Text = u.PartNumber,
                    Value = u.Id.ToString()
                });*/
            }
            return View("Index");

        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var products = _db.Products.ToList();
            var floLocations = _db.FloLocations.ToList();

            InventoryVM inventoryVM = new InventoryVM()
            {
                Products = products,
                FloLocations = floLocations,
                Inventory = new Inventory()
            };

            //Inventory? categoryFromDb = _db.Inventories.Find(id);
            //Inventory? inventoryFromDb = _unitOfWork.Inventory.Get(u => u.Id == id);
            Inventory? inventoryFromDb = _db.Inventories.FirstOrDefault(u=>u.Id==id);
            //Category? categoryFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();

            inventoryVM.Inventory = inventoryFromDb;

            if (inventoryFromDb == null)
            {
                return NotFound();
            }

            return View(inventoryVM);
        }

        [HttpPost]
        public IActionResult Edit(InventoryVM inventoryVM)
        {

            var locationId = inventoryVM.Inventory.FloLocationId;
            var productId1 = inventoryVM.Inventory.ProductId;

            var location = _db.FloLocations.Where(a => a.FloLocationId == locationId).FirstOrDefault();
            var locationName1 = location.LocationName;

            var product = _db.Products.Where(a => a.Id == productId1).FirstOrDefault();
            var partNumber1 = product.PartNumber;

            inventoryVM.Inventory.LocationName = locationName1;
            inventoryVM.Inventory.PartNumber = partNumber1;

            if (ModelState.IsValid)
            {
                _db.Inventories.Update(inventoryVM.Inventory);
                //_unitOfWork.Inventory.Update(c);
                _db.SaveChanges();
                //_unitOfWork.Save();
                TempData["success"] = "Inventory updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //Category? categoryFromDb = _db.Categories.Find(id);
            Inventory? inventoryFromDb = _unitOfWork.Inventory.Get(u => u.Id == id);
            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //Category? categoryFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();
            if (inventoryFromDb == null)
            {
                return NotFound();
            }
            return View(inventoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            //Category? c = _db.Categories.Find(id);
            Inventory? c = _unitOfWork.Inventory.Get(u => u.Id == id);
            if (c == null)
            {
                return NotFound();
            }
            //_db.Categories.Remove(c);
            _unitOfWork.Inventory.Remove(c);
            //_db.SaveChanges();
            _unitOfWork.Save();
            TempData["success"] = "Inventory deleted successfully";
            return RedirectToAction("Index", "Inventory");

        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Inventory> objInvList = _unitOfWork.Inventory.GetAll(includeProperties: "Product, FloLocation").ToList();
            return Json(new { data = objInvList });
        }

        /*
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
        }*/

        #endregion
    }
}
