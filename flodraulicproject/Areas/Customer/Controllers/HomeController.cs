
using flodraulicproject.DataAccess.Repository.IRepository;
using flodraulicproject.Models;
using flodraulicproject.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32.SafeHandles;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;
using flodraulicproject.DataAccess.Data;
using Stripe;
using flodraulicproject.Models.ViewModels;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace flodraulicproject.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment, ApplicationDbContext db)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
            _db = db;
        }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if(claim != null)
            {
                HttpContext.Session.SetInt32(SD.SessionCart,
                    _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == claim.Value).Count());
            }
            IEnumerable<Models.Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category");
            return View(productList);
        }

        public IActionResult LandingPage()
        {
            if (User.IsInRole("Admin"))
                return View("LandingPage");
            else //(User.IsInRole("Captain") || User.IsInRole("Company"))
                return View("LandingPageCryo");

        }

        public IActionResult LandingPageCryo()
        {
            return View();
        }

        public IActionResult LandingPageCryoAdmin()
        {
            return View();
        }

        public IActionResult Categories()
        {
            return View();
        }

        public IActionResult Engineering()
        {
            return View();
        }

        public IActionResult Ticket()
        {
            return View();
        }

        /*public IActionResult Products()
        {
            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category");
            return View(productList);
        }

        public IActionResult PumpsList()
        {
            var catId = 1;
            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category").Where(a => a.CategoryId == catId);
            return View(productList);
        }*/

        public IActionResult Details(int productId)
        {

            /*var query = from a in _db.Inventories
                        join r in _db.ShippedQtys on a.ProductId equals r.ProductId into g
                        where a.ProductId == productId
                        select new
                        {
                            Qoh = a.StartQoh - (int?)g.Select(x => x.QtyShipped).DefaultIfEmpty(0).Sum()
                        };
            */

            /*var locQoh = from a in _db.Inventories
                        join y in _db.ShippedQtys on a.FloLocationId equals y.FloLocationId
                        where a.ProductId == productId
                        select new
                        {
                            Location = a.FloLocation.LocationName,
                            StartQoh = a.StartQoh,
                            ShippedQty = y.QtyShipped
                        };
            */

            //Load data for dropdown FloLocationList
            IEnumerable<SelectListItem> FloLocationList = _unitOfWork.FloLocation
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.LocationName,
                    Value = u.FloLocationId.ToString()
                });

            ViewBag.FloLocationList = FloLocationList;

            //var querydistinct = locQoh.Distinct();
            var startQoh = _db.Inventories.Where(k => k.ProductId == productId).Sum(y => y.StartQoh);
            //var totalShipped = querydistinct.AsEnumerable().Sum(x => x.ShippedQty);
            var totalShipped = _db.ShippedQtys.Where(j => j.ProductId == productId).Sum(b => b.QtyShipped);
            var totalQoh = startQoh - totalShipped;

            /*var query1 = from a in _db.Inventories
                         join r in _db.ShippedQtys on a.FloLocationId equals r.FloLocationId into g
                         where a.ProductId == productId
                         select new
                         {
                             a.FloLocation.LocationName,
                             StartQoh = a.StartQoh,
                             Shipped = (int?)g.Select(x => x.QtyShipped).DefaultIfEmpty(0).Sum(),
                             Qoh = a.StartQoh - (int?)g.Select(x => x.QtyShipped).DefaultIfEmpty(0).Sum()
                         };

            var query1distinct = query1.Distinct();
            */
            //var qohByLocation = _db.Inventories.Where(x => x.ProductId == productId);

            var query2 = from a in _db.Inventories.Where(x => x.ProductId == productId)
                         join y in _db.ShippedQtys.Where(x => x.ProductId == productId) on a.FloLocationId equals y.FloLocationId into g
                         select new
                         {
                             a.Product.PartNumber,
                             a.FloLocation.LocationName,
                             a.StartQoh,
                             Shipped = g.Select(x=>x.QtyShipped).Sum(),
                             Qoh = a.StartQoh - g.Select(x => x.QtyShipped).Sum()
                         };

            List<QohListVM> listQoh = new List<QohListVM>();   

            foreach (var item in query2)
            {
                QohListVM qoh = new()
                {
                    LocationName = item.LocationName,
                    Qoh = item.Qoh
                };
                listQoh.Add(qoh);
            }

            ShoppingCart cart = new()
            {
                Product = _unitOfWork.Product.Get(u => u.Id == productId, includeProperties: "Category"),
                Count = 1,
                ProductId = productId
            };

            cart.Product.Qoh = totalQoh;

            CartVM shoppingCartVM = new CartVM()
            {
                ShoppingCart = new ShoppingCart(),
                FloLocationList = FloLocationList
            };

            shoppingCartVM.ShoppingCart = cart;
            shoppingCartVM.QohListVM = listQoh;

            return View(shoppingCartVM);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Details(CartVM shoppingCartVM)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            shoppingCartVM.ShoppingCart.ApplicationUserId = userId;

            ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.ApplicationUserId == userId && 
            u.ProductId==shoppingCartVM.ShoppingCart.ProductId);

            //cartFromDb.FloLocationId = shoppingCartVM.ShoppingCart.FloLocationId;

            if (cartFromDb != null)
            {
                //shopping cart exists
                cartFromDb.FloLocationId = shoppingCartVM.ShoppingCart.FloLocationId;
                cartFromDb.Count += shoppingCartVM.ShoppingCart.Count;
                _unitOfWork.ShoppingCart.Update(cartFromDb);
                _unitOfWork.Save();
            }
            else
            {
                //add cart record
                _unitOfWork.ShoppingCart.Add(shoppingCartVM.ShoppingCart);
                _unitOfWork.Save();
                HttpContext.Session.SetInt32(SD.SessionCart,
                    _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId).Count());
            }

            TempData["success"] = "Cart updated successfully";

            //return RedirectToAction(nameof(Index));
			return RedirectToAction("Index", "Cart", new { area = "Customer" });
		}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult PumpsList()
        {

            //var objCategoryList = _db.Categories.ToList();
            var objProductList = _unitOfWork.Product.GetAll(includeProperties: "PartFamily").ToList();

            return View(objProductList);
        }

        public IActionResult WorkInstruction()
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

            List<WorkInstruction> result = new List<WorkInstruction>();
            foreach (var pfep in query.ToList())
            {
                result.Add(new WorkInstruction
                {
                    Id = pfep.Id,
                    WIName = pfep.WIName,
                    WIType = pfep.WIType,
                    ImageUrl = pfep.ImageUrl
                });
            }

            return View("WorkInstruction", result);

        }

        public IActionResult WINotAdmin()
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

            List<WorkInstruction> result = new List<WorkInstruction>();
            foreach (var pfep in query.ToList())
            {
                result.Add(new WorkInstruction
                {
                    Id = pfep.Id,
                    WIName = pfep.WIName,
                    WIType = pfep.WIType,
                    ImageUrl = pfep.ImageUrl
                });
            }

            return View("WorkInstruction", result);
        }

        public IActionResult ServiceManual()
        {

            //var objCategoryList = _db.Categories.ToList();

            return View();
        }

        public IActionResult Reports()
        {

            //var objCategoryList = _db.Categories.ToList();

            return View();
        }

        public IActionResult SavingsReport()
        {

            //var objCategoryList = _db.Categories.ToList();

            return View();
        }

        public IActionResult Pumps()
        {
            //var objCategoryList = _db.Categories.ToList();
            var objProductList = _unitOfWork.Product.GetAll(includeProperties: "PartFamily").Where(u=>u.CategoryId == 1).ToList();

            return View(objProductList);
        }

        public IActionResult Valves()
        {
            //var objCategoryList = _db.Categories.ToList();
            var objProductList = _unitOfWork.Product.GetAll(includeProperties: "PartFamily").Where(u => u.CategoryId == 2).ToList();

            return View(objProductList);
        }

        public IActionResult Filters()
        {
            //var objCategoryList = _db.Categories.ToList();
            var objProductList = _unitOfWork.Product.GetAll(includeProperties: "PartFamily").Where(u => u.CategoryId == 3).ToList();

            return View(objProductList);
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll(string status)
        {
            IEnumerable<Models.Product> objProductList = _unitOfWork.Product.GetAll(includeProperties: "PartFamily").ToList();

            switch (status)
            {
                case "tractor":
                    objProductList = objProductList.Where(u => u.PartFamily.FamilyName == SD.Tractor);
                    break;
                case "trailer":
                    objProductList = objProductList.Where(u => u.PartFamily.FamilyName == SD.Trailer);
                    break;
                case "misc":
                    objProductList = objProductList.Where(u => u.PartFamily.FamilyName == SD.Misc);
                    break;
                default:
                    break;
            }

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
