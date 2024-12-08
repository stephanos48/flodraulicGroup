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
    [Authorize]
    public class TicketController : Controller
    {

        //private readonly ApplicationDbContext _db;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        //public CategoryController(ApplicationDbContext db)
        public TicketController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            //var objCategoryList = _db.Categories.ToList();
            var objTicketList = _unitOfWork.Ticket.GetAll(includeProperties:"TicketStatus").ToList();

            return View(objTicketList);
        }

        public IActionResult Upsert(int? id)
        {
            IEnumerable<SelectListItem> StatusList = _unitOfWork.TicketStatus
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.StatusName,
                    Value = u.TicketStatusId.ToString()
                });

            IEnumerable<SelectListItem> UserList = _unitOfWork.ApplicationUser
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });

            ViewBag.StatusList = StatusList;
            ViewBag.UserList = UserList;
            //ViewData["CategoryList"] = CategoryList;
            TicketVM ticketVM = new TicketVM()
            {
                StatusList = StatusList,
                UserList = UserList,
                Ticket = new Ticket()
            };
            if (id == null || id == 0)
            {
                //create
                return View(ticketVM);
            }
            else
            {
                //update
                ticketVM.Ticket = _unitOfWork.Ticket.Get(u => u.Id == id);
                return View(ticketVM);
            }

        }

        [HttpPost]
        public IActionResult Upsert(TicketVM ticketVM)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {

                if (ticketVM.Ticket.Id == 0)
                {
                    _unitOfWork.Ticket.Add(ticketVM.Ticket);
                }
                else
                {
                    _unitOfWork.Ticket.Update(ticketVM.Ticket);
                }

                //_db.Categories.Add(c);
                //_unitOfWork.Product.Add(productVM.Product);
                //_db.SaveChanges();
                _unitOfWork.Save();
                TempData["success"] = "Ticket created successfully";
                return RedirectToAction("Index", "Ticket");
            }
            else
            {
                ticketVM.StatusList = _unitOfWork.TicketStatus.GetAll().Select(u => new SelectListItem
                {
                    Text = u.StatusName,
                    Value = u.TicketStatusId.ToString()
                });

                ticketVM.UserList = _unitOfWork.ApplicationUser.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });

                return View(ticketVM);
            }
        }

        public IActionResult Create()
        {
            IEnumerable<SelectListItem> StatusList = _unitOfWork.TicketStatus
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.StatusName,
                    Value = u.TicketStatusId.ToString()
                });

            IEnumerable<SelectListItem> UserList = _unitOfWork.ApplicationUser
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });

            ViewBag.StatusList = StatusList;
            ViewBag.UserList = UserList;
            //ViewData["CategoryList"] = CategoryList;
            TicketVM ticketVM = new TicketVM()
            {
                StatusList = StatusList,
                UserList = UserList,
                Ticket = new Ticket()
            };
            return View(ticketVM);
        }

        [HttpPost]
        public IActionResult Create(TicketVM ticketVM)
        {

            if (ModelState.IsValid)
            {
                //_db.Categories.Add(c);
                _unitOfWork.Ticket.Add(ticketVM.Ticket);
                //_db.SaveChanges();
                _unitOfWork.Save();
                TempData["success"] = "Ticket created successfully";
                return RedirectToAction("Index", "Ticket");
            }
            else
            {
                ticketVM.StatusList = _unitOfWork.TicketStatus.GetAll().Select(u => new SelectListItem
                {
                    Text = u.StatusName,
                    Value = u.TicketStatusId.ToString()
                });

                ticketVM.UserList = _unitOfWork.ApplicationUser.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });

                return View(ticketVM);
            }
        }

        public IActionResult Edit(int? id)
        {
            IEnumerable<SelectListItem> StatusList = _unitOfWork.TicketStatus
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.StatusName,
                    Value = u.TicketStatusId.ToString()
                });

            IEnumerable<SelectListItem> UserList = _unitOfWork.ApplicationUser
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });

            ViewBag.StatusList = StatusList;
            ViewBag.UserList = UserList;
            //ViewData["CategoryList"] = CategoryList;
            TicketVM ticketVM = new TicketVM()
            {
                StatusList = StatusList,
                UserList = UserList,
                Ticket = new Ticket()
            };

            //update
            ticketVM.Ticket = _unitOfWork.Ticket.Get(u=>u.Id == id);
            return View(ticketVM);
            
        }

        [HttpPost]
        public IActionResult Edit(TicketVM ticketVM)
        {
            if (ModelState.IsValid)
            {
                //_db.Categories.Update(c);
                _unitOfWork.Ticket.Update(ticketVM.Ticket);
                //_db.SaveChanges();
                _unitOfWork.Save();
                TempData["success"] = "Ticket updated successfully";
                return RedirectToAction("Index", "Ticket");
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
            Ticket? ticketFromDb = _unitOfWork.Ticket.Get(u => u.Id == id);
            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //Category? categoryFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();
            if (ticketFromDb == null)
            {
                return NotFound();
            }
            return View(ticketFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            //Category? c = _db.Categories.Find(id);
            Ticket? c = _unitOfWork.Ticket.Get(u => u.Id == id);
            if (c == null)
            {
                return NotFound();
            }
            //_db.Categories.Remove(c);
            _unitOfWork.Ticket.Remove(c);
            //_db.SaveChanges();
            _unitOfWork.Save();
            TempData["success"] = "Ticket deleted successfully";
            return RedirectToAction("Index", "Ticket");

        }*/

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Ticket> objTicketList = _unitOfWork.Ticket.GetAll(includeProperties:"TicketStatus").ToList();
            return Json(new { data = objTicketList });
        }

        //[HttpDelete]
        public IActionResult Delete(int? id)
        {
            var ticketToBeDeleted = _unitOfWork.Ticket.Get(u => u.Id == id);
            if (ticketToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.Ticket.Remove(ticketToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Successful" });
        }

        #endregion
    }
}

