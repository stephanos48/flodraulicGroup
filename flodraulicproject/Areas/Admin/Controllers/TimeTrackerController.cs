using flodraulicproject.Areas.Customer.Controllers;
using flodraulicproject.DataAccess.Data;
using flodraulicproject.DataAccess.Repository.IRepository;
using flodraulicproject.Models;
using flodraulicproject.Models.ViewModels;
using flodraulicproject.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol;
using Stripe;
using Stripe.BillingPortal;
using Stripe.Checkout;
using Stripe.Climate;
using System.Diagnostics;
using System.Net;
using System.Security.Claims;
using Session = Stripe.Checkout.Session;
using SessionService = Stripe.Checkout.SessionService;

namespace flodraulicproject.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class TimeTrackerController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<Home1Controller> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public OrderVM OrderVM { get; set; }
        /*public OrderController(ILogger<HomeController> logger, IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
		{
            _logger = logger;
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }*/

        public TimeTrackerController(ApplicationDbContext db, IUnitOfWork unitOfWork)
        {
            _db = db;
			_unitOfWork = unitOfWork;
        }

        public IActionResult Index()
		{
            return View();
		}

 


        #region API CALLS

        [HttpGet]
		public IActionResult GetAll(string status)
		{
			IEnumerable<OrderHeader> objOrderHeaders;

			if(User.IsInRole(SD.Role_Admin) || User.IsInRole(SD.Role_Employee))
			{
				objOrderHeaders = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser").ToList();
			}
			else
			{
				var claimsIdentity = (ClaimsIdentity)User.Identity;
				var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

                objOrderHeaders = _unitOfWork.OrderHeader.GetAll(u => u.ApplicationUserId == userId,includeProperties: "ApplicationUser");
            }

			switch (status)
			{
				case "neworder":
					objOrderHeaders = objOrderHeaders.Where(u => u.Status.StatusName == SD.NewOrder);
					break;
				case "p21entered":
                    objOrderHeaders = objOrderHeaders.Where(u => u.Status.StatusName == SD.P21Entered);
                    break;
				case "shippedinvoiced":
                    objOrderHeaders = objOrderHeaders.Where(u => u.Status.StatusName == SD.ShippedInvoiced);
                    break;
				case "paid":
                    objOrderHeaders = objOrderHeaders.Where(u => u.Status.StatusName == SD.Paid);
                    break;
				default:
                    break;
			}

            return Json(new { data = objOrderHeaders });

		}

		#endregion
	}
}
