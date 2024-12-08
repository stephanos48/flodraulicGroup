using flodraulicproject.DataAccess.Data;
using flodraulicproject.DataAccess.Repository.IRepository;
using flodraulicproject.Models.ViewModels;
using flodraulicproject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace flodraulicproject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SupplierController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        //private readonly ILogger<Home1Controller> _logger;
        //private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ApplicationDbContext _db;

        public SupplierController(ApplicationDbContext db, IUnitOfWork unitOfWork)
        {
            _db = db;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var results = _db.Suppliers.ToList();
            return View(results);
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
                var supplier = from a in _db.Suppliers
                           where a.Id == id
                           select new
                           {
                               a.Id,
                               a.SupplierName,
                               a.SupplierNo,
                               a.SupplierType,
                               a.City,
                               a.State,
                               a.Country,
                               a.Website,
                               a.Notes
                           };
                return View(supplier);
            }

        }

        [HttpPost]
        public IActionResult Upsert(Supplier supplier)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {

                if (supplier.Id == 0)
                {
                    _unitOfWork.Supplier.Add(supplier);
                }
                else
                {
                    _unitOfWork.Supplier.Update(supplier);
                }

                //_db.Categories.Add(c);
                //_unitOfWork.Product.Add(productVM.Product);
                //_db.SaveChanges();
                _unitOfWork.Save();
                TempData["success"] = "Supplier created successfully";
                return RedirectToAction("Index", "Supplier");
            }
            else
            {

                return View(supplier);

            }
        }
    }
}
