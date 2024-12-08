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
	public class OrderController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
        //private readonly ILogger<Home1Controller> _logger;
        //private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public OrderVM OrderVM { get; set; }
        /*public OrderController(ILogger<HomeController> logger, IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
		{
            _logger = logger;
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }*/

        public OrderController(ApplicationDbContext db, IUnitOfWork unitOfWork)
        {
            _db = db;
			_unitOfWork = unitOfWork;
        }

        public IActionResult Index()
		{
            return View();
		}

        public IActionResult OrderList()
        {
			//var objCategoryList = _db.Categories.ToList();
			//IEnumerable<OrderHeader> orderHeaderList = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser");
			//return View(orderHeaderList);

			var query = from a in _db.OrderHeaders
                        join e in _db.ApplicationUsers on a.ApplicationUserId equals e.Id
                        join co in _db.Statuses on a.StatusId equals co.StatusId
						select new
						{
							a.Id,
							a.Name,
							a.PhoneNumber,
							a.ApplicationUser.Email,
							co.StatusName,
							a.OrderTotal
						};

            List<OrderVM_Lite> result = new List<OrderVM_Lite>();
            foreach (var pfep in query.ToList())
            {
                result.Add(new OrderVM_Lite
                {
                    Id = pfep.Id,
                    Name = pfep.Name,
                    PhoneNumber = pfep.PhoneNumber,
                    Email = pfep.Email,
                    StatusName = pfep.StatusName,
                    OrderTotal = pfep.OrderTotal
                });
            }


            return View("OrderList", result);

            //return View("Index", query.ToList());
        }

        public IActionResult OrderListBasic()
        {
            //var objCategoryList = _db.Categories.ToList();
            //IEnumerable<OrderHeader> orderHeaderList = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser");
            //return View(orderHeaderList);

            var query = from a in _db.OrderHeaders
                        join e in _db.ApplicationUsers on a.ApplicationUserId equals e.Id
                        join co in _db.Statuses on a.StatusId equals co.StatusId
                        select new
                        {
                            a.Id,
                            a.Name,
                            a.PhoneNumber,
                            a.ApplicationUser.Email,
                            co.StatusName,
                            a.OrderTotal
                        };

            List<OrderVM_Lite> result = new List<OrderVM_Lite>();
            foreach (var pfep in query.ToList())
            {
                result.Add(new OrderVM_Lite
                {
                    Id = pfep.Id,
                    Name = pfep.Name,
                    PhoneNumber = pfep.PhoneNumber,
                    Email = pfep.Email,
                    StatusName = pfep.StatusName,
                    OrderTotal = pfep.OrderTotal
                });
            }


            return View("OrderListBasic", result);

            //return View("Index", query.ToList());
        }

        public IActionResult OrderListNew()
        {
            //var objCategoryList = _db.Categories.ToList();
            //IEnumerable<OrderHeader> orderHeaderList = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser");
            //return View(orderHeaderList);

            var query = from a in _db.OrderHeaders
                        join e in _db.ApplicationUsers on a.ApplicationUserId equals e.Id
                        join co in _db.Statuses on a.StatusId equals co.StatusId
                        where co.StatusName == "NewOrder"
                        select new
                        {
                            a.Id,
                            a.Name,
                            a.PhoneNumber,
                            a.ApplicationUser.Email,
                            co.StatusName,
                            a.OrderTotal
                        };

            List<OrderVM_Lite> result = new List<OrderVM_Lite>();
            foreach (var pfep in query.ToList())
            {
                result.Add(new OrderVM_Lite
                {
                    Id = pfep.Id,
                    Name = pfep.Name,
                    PhoneNumber = pfep.PhoneNumber,
                    Email = pfep.Email,
                    StatusName = pfep.StatusName,
                    OrderTotal = pfep.OrderTotal
                });
            }


            return View("OrderList", result);

            //return View("Index", query.ToList());
        }

        public IActionResult OrderListP21Entered()
        {
            //var objCategoryList = _db.Categories.ToList();
            //IEnumerable<OrderHeader> orderHeaderList = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser");
            //return View(orderHeaderList);

            var query = from a in _db.OrderHeaders
                        join co in _db.Statuses on a.StatusId equals co.StatusId
                        where co.StatusName == "P21Entered"
                        select new
                        {
                            a.Id,
                            a.Name,
                            a.PhoneNumber,
                            a.ApplicationUser.Email,
                            co.StatusName,
                            a.OrderTotal
                        };

            List<OrderVM_Lite> result = new List<OrderVM_Lite>();
            foreach (var pfep in query.ToList())
            {
                result.Add(new OrderVM_Lite
                {
                    Id = pfep.Id,
                    Name = pfep.Name,
                    PhoneNumber = pfep.PhoneNumber,
                    Email = pfep.Email,
                    StatusName = pfep.StatusName,
                    OrderTotal = pfep.OrderTotal
                });
            }


            return View("OrderList", result);

            //return View("Index", query.ToList());
        }

        public IActionResult OrderListShippedInvoiced()
        {
            //var objCategoryList = _db.Categories.ToList();
            //IEnumerable<OrderHeader> orderHeaderList = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser");
            //return View(orderHeaderList);

            var query = from a in _db.OrderHeaders
                        join co in _db.Statuses on a.StatusId equals co.StatusId
                        where co.StatusName == "ShippedInvoiced"
                        select new
                        {
                            a.Id,
                            a.Name,
                            a.PhoneNumber,
                            a.ApplicationUser.Email,
                            co.StatusName,
                            a.OrderTotal
                        };

            List<OrderVM_Lite> result = new List<OrderVM_Lite>();
            foreach (var pfep in query.ToList())
            {
                result.Add(new OrderVM_Lite
                {
                    Id = pfep.Id,
                    Name = pfep.Name,
                    PhoneNumber = pfep.PhoneNumber,
                    Email = pfep.Email,
                    StatusName = pfep.StatusName,
                    OrderTotal = pfep.OrderTotal
                });
            }


            return View("OrderList", result);

            //return View("Index", query.ToList());
        }

        public IActionResult OrderListPaid()
        {
            //var objCategoryList = _db.Categories.ToList();
            //IEnumerable<OrderHeader> orderHeaderList = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser");
            //return View(orderHeaderList);

            var query = from a in _db.OrderHeaders
                        join co in _db.Statuses on a.StatusId equals co.StatusId
                        where co.StatusName == "Paid"
                        select new
                        {
                            a.Id,
                            a.Name,
                            a.PhoneNumber,
                            a.ApplicationUser.Email,
                            co.StatusName,
                            a.OrderTotal
                        };

            List<OrderVM_Lite> result = new List<OrderVM_Lite>();
            foreach (var pfep in query.ToList())
            {
                result.Add(new OrderVM_Lite
                {
                    Id = pfep.Id,
                    Name = pfep.Name,
                    PhoneNumber = pfep.PhoneNumber,
                    Email = pfep.Email,
                    StatusName = pfep.StatusName,
                    OrderTotal = pfep.OrderTotal
                });
            }


            return View("OrderList", result);

            //return View("Index", query.ToList());
        }

        public IActionResult OrderListReport()
        {

            return View("OrderListReport");

        }

        [HttpPost]
        public IActionResult OrderListReport(OrderVM_Lite orderVM)
        {
            //var objCategoryList = _db.Categories.ToList();
            //IEnumerable<OrderHeader> orderHeaderList = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser");
            //return View(orderHeaderList);

            var fromDate = orderVM.FromDate.ToDateTime(TimeOnly.Parse("12:00 AM"));
            var toDate = orderVM.ToDate.ToDateTime(TimeOnly.Parse("12:00 AM"));
            

            var query = from a in _db.OrderDetails
                        join b in _db.Products on a.ProductId equals b.Id
                        join c in _db.OrderHeaders on a.OrderHeaderId equals c.Id
                        join d in _db.FloLocations on a.FloLocationId equals d.FloLocationId
                        where c.OrderDate >= fromDate && c.OrderDate <= toDate 
                        select new
                        {
                            a.Id,
                            d.LocationName,
                            c.OrderDate,
                            c.PurchaseOrderNo,
                            c.Name,
                            b.PartNumber,
                            b.ListPrice,
                            b.DiscountPrice,
                            a.Count
                        };

            List<OrderVM_Lite> result = new List<OrderVM_Lite>();
            foreach (var pfep in query.ToList())
            {
                result.Add(new OrderVM_Lite
                {
                    Id = pfep.Id,
                    LocationName = pfep.LocationName,
                    OrderDate = pfep.OrderDate,
                    PurchaseOrderNo = pfep.PurchaseOrderNo,
                    Name = pfep.Name,
                    PartNumber = pfep.PartNumber,
                    ListPrice = pfep.ListPrice.ToString("c"),
                    Price = pfep.DiscountPrice.ToString("c"),
                    Count = pfep.Count,
                    Savings = ((pfep.ListPrice - pfep.DiscountPrice)*(pfep.Count)).ToString("c")
                });
            }


            return View("OrderListReport1", result);

            //return View("Index", query.ToList());
        }

        public IActionResult OpenOrderReport()
        {
            //var objCategoryList = _db.Categories.ToList();
            //IEnumerable<OrderHeader> orderHeaderList = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser");
            //return View(orderHeaderList);

            var query = from a in _db.OrderHeaders
                        where a.StatusId != 5 || a.StatusId != 4
                        select new
                        {
                            a.Id,
                            a.OrderDate,
                            a.PurchaseOrderNo,
                            a.ApplicationUser.Email,
                            a.ListOrderTotal,
                            a.OrderTotal,
                            a.Status.StatusName
                        };

            List<OrderVM_Lite> result = new List<OrderVM_Lite>();
            foreach (var pfep in query.ToList())
            {
                result.Add(new OrderVM_Lite
                {
                    Id = pfep.Id,
                    OrderDate = pfep.OrderDate,
                    PurchaseOrderNo = pfep.PurchaseOrderNo,
                    Email = pfep.Email,
                    ListOrderTotal = pfep.ListOrderTotal,
                    OrderTotal = pfep.OrderTotal,
                    StatusName = pfep.StatusName
                });
            }


            return View("OpenOrders", result);

            //return View("Index", query.ToList());
        }

        public IActionResult ClosedOrderReport()
        {
            //var objCategoryList = _db.Categories.ToList();
            //IEnumerable<OrderHeader> orderHeaderList = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser");
            //return View(orderHeaderList);

            var query = from a in _db.OrderHeaders
                        where a.StatusId == 5 || a.StatusId == 4
                        select new
                        {
                            a.Id,
                            a.OrderDate,
                            a.PurchaseOrderNo,
                            a.ApplicationUser.Email,
                            a.ListOrderTotal,
                            a.OrderTotal,
                            a.Status.StatusName
                        };

            List<OrderVM_Lite> result = new List<OrderVM_Lite>();
            foreach (var pfep in query.ToList())
            {
                result.Add(new OrderVM_Lite
                {
                    Id = pfep.Id,
                    OrderDate = pfep.OrderDate,
                    PurchaseOrderNo = pfep.PurchaseOrderNo,
                    Email = pfep.Email,
                    ListOrderTotal = pfep.ListOrderTotal,
                    OrderTotal = pfep.OrderTotal,
                    StatusName = pfep.StatusName
                });
            }


            return View("ClosedOrders", result);

            //return View("Index", query.ToList());
        }

        public IActionResult DetailsBasic(int orderId)
        {

            var applicationUsers = _db.ApplicationUsers.ToList();
            var products = _db.Products.ToList();

            IEnumerable<SelectListItem> StatusList = _unitOfWork.Status
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.StatusName,
                    Value = u.StatusId.ToString()
                });

            IEnumerable<SelectListItem> UserList = _unitOfWork.ApplicationUser
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });

            ViewBag.StatusList = StatusList;
            ViewBag.UserList = UserList;
            var orderDetails = _db.OrderDetails.ToList().Where(b => b.OrderHeaderId == orderId);

            OrderVM orderVM = new OrderVM()
            {
                OrderDetails = orderDetails,
                UserList = UserList,
                StatusList = StatusList,
                OrderHeader = new OrderHeader()
            };

            var query = from a in _db.OrderHeaders
                        join u in _db.ApplicationUsers on a.ApplicationUserId equals u.Id
                        join co in _db.Statuses on a.StatusId equals co.StatusId
                        select a;

            orderVM.OrderHeader = query.SingleOrDefault(h => h.Id == orderId);

            if (orderVM.OrderHeader.ShippingDate == DateTime.MinValue)
            {
                orderVM.OrderHeader.ShippingDate = null;
            }

            //orderVM.OrderHeader.ShippingDate = null;

            //orderVM.OrderHeader = orderHeader;
            return View("DetailsBasic", orderVM);

            //OrderHeader orderHeader = _db.OrderHeaders.Find(orderId);

            //return View("Details", viewModel);

            /*OrderVM orderVM = new()
            {
                //OrderHeader = _unitOfWork.OrderHeader.Get(u => u.Id == orderId, includeProperties: "ApplicationUser"),
                OrderHeader = query.SingleOrDefault(a => a.Id == orderId),
                OrderDetail = _unitOfWork.OrderDetail.GetAll(u => u.OrderHeaderId == orderId, includeProperties: "Product"),
                Status = _unitOfWork.Status.GetAll()
			};

            //orderVM.OrderHeader.ApplicationUser.Email = email;

			return View(orderVM);*/
        }

        public IActionResult Details(int orderId)
        {

            var applicationUsers = _db.ApplicationUsers.ToList();
            var products = _db.Products.ToList();

            IEnumerable<SelectListItem> StatusList = _unitOfWork.Status
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.StatusName,
                    Value = u.StatusId.ToString()
                });

            IEnumerable<SelectListItem> UserList = _unitOfWork.ApplicationUser
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
            
            ViewBag.StatusList = StatusList;
            ViewBag.UserList = UserList;
            var orderDetails = _db.OrderDetails.ToList().Where(b => b.OrderHeaderId == orderId);

            OrderVM orderVM = new OrderVM()
            {
                OrderDetails = orderDetails,
                UserList = UserList,
                StatusList = StatusList,
                OrderHeader = new OrderHeader()
            };

            var query = from a in _db.OrderHeaders
                        join u in _db.ApplicationUsers on a.ApplicationUserId equals u.Id
                        join co in _db.Statuses on a.StatusId equals co.StatusId
                        select a;

            orderVM.OrderHeader = query.SingleOrDefault(h => h.Id == orderId);

if (orderVM.OrderHeader.ShippingDate == DateTime.MinValue)
            {
                orderVM.OrderHeader.ShippingDate = null;
            }

            //orderVM.OrderHeader.ShippingDate = null;

            //orderVM.OrderHeader = orderHeader;
            return View("Details", orderVM);

            //OrderHeader orderHeader = _db.OrderHeaders.Find(orderId);

            //return View("Details", viewModel);

            /*OrderVM orderVM = new()
            {
                //OrderHeader = _unitOfWork.OrderHeader.Get(u => u.Id == orderId, includeProperties: "ApplicationUser"),
                OrderHeader = query.SingleOrDefault(a => a.Id == orderId),
                OrderDetail = _unitOfWork.OrderDetail.GetAll(u => u.OrderHeaderId == orderId, includeProperties: "Product"),
                Status = _unitOfWork.Status.GetAll()
			};

            //orderVM.OrderHeader.ApplicationUser.Email = email;

			return View(orderVM);*/
        }

        [HttpPost]
        public IActionResult UpdateOrderDetails(OrderVM orderVM)
        {

            if (ModelState.IsValid)
            {
                //_db.OrderHeaders.Update(orderVM.OrderHeader);
                _unitOfWork.OrderHeader.Update(orderVM.OrderHeader);
                //_db.SaveChanges();
                _unitOfWork.Save();
                TempData["success"] = "Order updated successfully";
                return RedirectToAction("OrderList");
            }

            return View("OrderList");
        }

        [HttpPost]
        [Route("")]
        [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Employee)]
        public IActionResult UpdateOrderDetail() {

            IEnumerable<SelectListItem> StatusList = _unitOfWork.Status
			.GetAll().Select(u => new SelectListItem
			{
				Text = u.StatusName,
				Value = u.StatusId.ToString()
			});

            ViewBag.StatusList = StatusList;

            var orderHeaderFromDb = _unitOfWork.OrderHeader.Get(u => u.Id == OrderVM.OrderHeader.Id);
			orderHeaderFromDb.Name = OrderVM.OrderHeader.Name;
            orderHeaderFromDb.PhoneNumber = OrderVM.OrderHeader.PhoneNumber;
            orderHeaderFromDb.StreetAddress = OrderVM.OrderHeader.StreetAddress;
            orderHeaderFromDb.City = OrderVM.OrderHeader.City;
            orderHeaderFromDb.State = OrderVM.OrderHeader.State;
            orderHeaderFromDb.PostalCode = OrderVM.OrderHeader.PostalCode;
orderHeaderFromDb.ShippingDate = OrderVM.OrderHeader.ShippingDate;
            orderHeaderFromDb.StatusId = OrderVM.OrderHeader.StatusId;
            if (!string.IsNullOrEmpty(OrderVM.OrderHeader.PurchaseOrderNo))
            {
                orderHeaderFromDb.PurchaseOrderNo = OrderVM.OrderHeader.PurchaseOrderNo;
            }
			if (!string.IsNullOrEmpty(OrderVM.OrderHeader.Carrier))
			{
				orderHeaderFromDb.Carrier = OrderVM.OrderHeader.Carrier;
			}
            if (!string.IsNullOrEmpty(OrderVM.OrderHeader.TrackingNumber))
            {
                orderHeaderFromDb.TrackingNumber = OrderVM.OrderHeader.TrackingNumber;
            }
			_unitOfWork.OrderHeader.Update(orderHeaderFromDb);
			_unitOfWork.Save();

			TempData["Success"] = "Order Details Updated Successfully.";

            return RedirectToAction(nameof(Details), new {orderId = orderHeaderFromDb.Id });
		}

        [HttpPost]
        [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Employee)]
        public IActionResult StartProcessing() {
			_unitOfWork.OrderHeader.UpdateStatus(OrderVM.OrderHeader.Id, SD.StatusInProcess);
			_unitOfWork.Save();
            TempData["Success"] = "Order Details Updated Successfully.";

            return RedirectToAction(nameof(Details), new { orderId = OrderVM.OrderHeader.Id });
        }

        [HttpPost]
        [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Employee)]
        public IActionResult ShipOrder()
        {
			var orderHeader = _unitOfWork.OrderHeader.Get(u => u.Id == OrderVM.OrderHeader.Id);
			orderHeader.TrackingNumber = OrderVM.OrderHeader.TrackingNumber;
			orderHeader.Carrier = OrderVM.OrderHeader.Carrier;
			orderHeader.Status.StatusName = SD.StatusShipped;
orderHeader.ShippingDate = DateTime.Now;
			if (orderHeader.PaymentStatus == SD.PaymentStatusDelayedPayment)
			{
				orderHeader.PaymentDueDate = DateOnly.FromDateTime(DateTime.Now.AddDays(30));
			}

			_unitOfWork.OrderHeader.Update(orderHeader);
			_unitOfWork.Save();
            //_unitOfWork.OrderHeader.UpdateStatus(OrderVM.OrderHeader.Id, SD.StatusShipped);
            //_unitOfWork.Save();
            TempData["Success"] = "Order Shipped Successfully.";
            return RedirectToAction(nameof(Details), new { orderId = OrderVM.OrderHeader.Id });
        }

		[HttpPost]
		[Authorize(Roles = SD.Role_Admin + "," + SD.Role_Employee)]
		public IActionResult CancelOrder()
		{
            var orderHeader = _unitOfWork.OrderHeader.Get(u => u.Id == OrderVM.OrderHeader.Id);

			if (orderHeader.PaymentStatus == SD.PaymentStatusApproved)
			{
				var options = new RefundCreateOptions
				{
					Reason = RefundReasons.RequestedByCustomer,
					PaymentIntent = orderHeader.PaymentIntentId
				};

				var service = new RefundService();
				Refund refund = service.Create(options);

				_unitOfWork.OrderHeader.UpdateStatus(orderHeader.Id, SD.StatusCancelled, SD.StatusRefunded);
			}
			else
			{
                _unitOfWork.OrderHeader.UpdateStatus(orderHeader.Id, SD.StatusCancelled, SD.StatusCancelled);
            }
			_unitOfWork.Save();
			TempData["Success"] = "Order Cancelled Successfully.";
			return RedirectToAction(nameof(Details), new { orderId = OrderVM.OrderHeader.Id });
        }

		[ActionName("Details")]
		[HttpPost]
		public IActionResult Details_PAY_NOW() 
		{

			OrderVM.OrderHeader = _unitOfWork.OrderHeader
				.Get(u => u.Id == OrderVM.OrderHeader.Id, includeProperties: "ApplicationUser");
            OrderVM.OrderDetails = _unitOfWork.OrderDetail
				.GetAll(u => u.OrderHeaderId == OrderVM.OrderHeader.Id, includeProperties: "Product");

			//strip logic
			//var domain = "https://localhost:7169/";
            var domain = Request.Scheme + "://" + Request.Host.Value + "/";
            var options = new Stripe.Checkout.SessionCreateOptions
			{
				SuccessUrl = domain + $"admin/order/PaymentConfirmation?orderHeaderId={OrderVM.OrderHeader.Id}",
				CancelUrl = domain + $"admin/order/details?orderId={OrderVM.OrderHeader.Id}",
				LineItems = new List<SessionLineItemOptions>(),
				Mode = "payment",
			};

			foreach (var item in OrderVM.OrderDetails)
			{
				var sessionLineItem = new SessionLineItemOptions
				{
					PriceData = new SessionLineItemPriceDataOptions
					{
						UnitAmount = (long)(item.Price * 100), // $20.50 => 2050
						Currency = "usd",
						ProductData = new SessionLineItemPriceDataProductDataOptions
						{
							Name = item.Product.PartNumber
						}
					},
					Quantity = item.Count
				};
				options.LineItems.Add(sessionLineItem);
			}

			var service = new SessionService();
			Session session = service.Create(options);
			_unitOfWork.OrderHeader.UpdateStripePaymentID(OrderVM.OrderHeader.Id, session.Id, session.PaymentIntentId);
			Response.Headers.Add("Location", session.Url);
			return new StatusCodeResult(303);

            //return RedirectToAction(nameof(Details), new { orderId = OrderVM.OrderHeader.Id });
        }

        public IActionResult PaymentConfirmation(int orderHeaderId)
        {
            OrderHeader orderHeader = _unitOfWork.OrderHeader.Get(u => u.Id == orderHeaderId);
            if (orderHeader.PaymentStatus == SD.PaymentStatusDelayedPayment)
            {
                //this is an order by a customer
                var service = new SessionService();
                Session session = service.Get(orderHeader.SessionId);

                if (session.PaymentStatus.ToLower() == "paid")
                {
                    _unitOfWork.OrderHeader.UpdateStripePaymentID(orderHeaderId, session.Id, session.PaymentIntentId);
                    _unitOfWork.OrderHeader.UpdateStatus(orderHeaderId, orderHeader.Status.StatusName, SD.PaymentStatusApproved);
                    _unitOfWork.Save();
                }
            }

            return View(orderHeaderId);
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
