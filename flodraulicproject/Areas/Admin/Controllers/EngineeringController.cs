using flodraulicproject.DataAccess.Data;
using flodraulicproject.DataAccess.Repository.IRepository;
using flodraulicproject.Models;
using flodraulicproject.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Frameworks;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;

namespace flodraulicproject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EngineeringController : Controller
    { 

		private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EngineeringController(ApplicationDbContext db, IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TimeTrackerReports()
        {
            return View();
        }

        public IActionResult LandingPageEngAdmin()
        {
            return View();
        }

        public IActionResult EngOverviewReport()
        {
            
            EngOverviewVM engVM = new EngOverviewVM();

            var openA = _db.EngineeringLogs.Where(r => r.LogStatusId == 1).Count();
            engVM.openA = openA;

            var openB = _db.EngineeringLogs.Where(r => r.LogStatusId == 2).Count();
            engVM.openB = openB;

            var openC = _db.EngineeringLogs.Where(r => r.LogStatusId == 3).Count();
            engVM.openC = openC;

            var openD = _db.EngineeringLogs.Where(r => r.LogStatusId == 4).Count();
            engVM.openD = openD;

            var openE = _db.EngineeringLogs.Where(r => r.LogStatusId == 5).Count();
            engVM.openE = openE;

            var openF = _db.EngineeringLogs.Where(r => r.LogStatusId == 6).Count();
            engVM.openF = openF;

            var openG = _db.EngineeringLogs.Where(r => r.LogStatusId == 7).Count();
            engVM.openG = openG;

            var openH = _db.EngineeringLogs.Where(r => r.LogStatusId == 8).Count();
            engVM.openH = openH;

            var openI = _db.EngineeringLogs.Where(r => r.LogStatusId == 9).Count();
            engVM.openI = openI;

            var openJ = _db.EngineeringLogs.Where(r => r.LogStatusId == 10).Count();
            engVM.openJ = openJ;

            var openK = _db.EngineeringLogs.Where(r => r.LogStatusId == 11).Count();
            engVM.openK = openK;

            var openL = _db.EngineeringLogs.Where(r => r.LogStatusId == 12).Count();
            engVM.openL = openL;

            var openM = _db.EngineeringLogs.Where(r => r.LogStatusId == 13).Count();
            engVM.openM = openM;

            var openN = _db.EngineeringLogs.Where(r => r.LogStatusId == 14).Count();
            engVM.openN = openN;

            var openO = _db.EngineeringLogs.Where(r => r.LogStatusId == 15).Count();
            engVM.openO = openO;

            var openP = _db.EngineeringLogs.Where(r => r.LogStatusId == 16).Count();
            engVM.openP = openP;

            var openQ = _db.EngineeringLogs.Where(r => r.LogStatusId == 17).Count();
            engVM.openQ = openQ;

            var openR = _db.EngineeringLogs.Where(r => r.LogStatusId == 18).Count();
            engVM.openR = openR;

            return View(engVM);
        }

        public IActionResult EngTimeOverviewReport()
        {

            EngTimeOverviewVM engVM = new EngTimeOverviewVM();

            var aBizonTotal = _db.TimeTrackers.Where(t => t.EngineerId == 1).Sum(y => y.HrsWorked);
            engVM.aBizonTotal = aBizonTotal;

            var aBizonEng = _db.TimeTrackers.Where(t => t.EngineerId == 1).Where(h => h.LaborCodeId == 1 || h.LaborCodeId == 2 || h.LaborCodeId == 3 || h.LaborCodeId == 4 || h.LaborCodeId == 5 || h.LaborCodeId == 6).Sum(y => y.HrsWorked);
            engVM.aBizonEng = aBizonEng;

            var aBizonQuote = _db.TimeTrackers.Where(t => t.EngineerId == 1).Where(h => h.LaborCodeId == 11).Sum(y => y.HrsWorked);
            engVM.aBizonQuote = aBizonQuote;

            var aBizonManual = _db.TimeTrackers.Where(t => t.EngineerId == 1).Where(h => h.LaborCodeId == 9).Sum(y => y.HrsWorked);
            engVM.aBizonManual = aBizonManual;

            var aBizonPTO = _db.TimeTrackers.Where(t => t.EngineerId == 1).Where(h => h.LaborCodeId == 7).Sum(y => y.HrsWorked);
            engVM.aBizonPTO = aBizonPTO;

            var aBizonNVH = _db.TimeTrackers.Where(t => t.EngineerId == 1).Where(h => h.LaborCodeId == 8).Sum(y => y.HrsWorked);
            engVM.aBizonNVH = aBizonNVH;

            var aBizonEff = (((aBizonTotal - aBizonNVH - aBizonPTO)/(aBizonTotal - aBizonPTO))*100M);
            engVM.aBizonEff = Decimal.Round(aBizonEff.Value, 2);


            var pBrownTotal = _db.TimeTrackers.Where(t => t.EngineerId == 12).Sum(y => y.HrsWorked);
            engVM.pBrownTotal = pBrownTotal;

            var pBrownEng = _db.TimeTrackers.Where(t => t.EngineerId == 12).Where(h => h.LaborCodeId == 1 || h.LaborCodeId == 2 || h.LaborCodeId == 3 || h.LaborCodeId == 4 || h.LaborCodeId == 5 || h.LaborCodeId == 6).Sum(y => y.HrsWorked);
            engVM.pBrownEng = pBrownEng;

            var pBrownQuote = _db.TimeTrackers.Where(t => t.EngineerId == 12).Where(h => h.LaborCodeId == 11).Sum(y => y.HrsWorked);
            engVM.pBrownQuote = pBrownQuote;

            var pBrownManual = _db.TimeTrackers.Where(t => t.EngineerId == 12).Where(h => h.LaborCodeId == 9).Sum(y => y.HrsWorked);
            engVM.pBrownManual = pBrownManual;

            var pBrownPTO = _db.TimeTrackers.Where(t => t.EngineerId == 12).Where(h => h.LaborCodeId == 7).Sum(y => y.HrsWorked);
            engVM.pBrownPTO = pBrownPTO;

            var pBrownNVH = _db.TimeTrackers.Where(t => t.EngineerId == 12).Where(h => h.LaborCodeId == 8).Sum(y => y.HrsWorked);
            engVM.pBrownNVH = pBrownNVH;

            var pBrownEff = (((pBrownTotal - pBrownNVH - pBrownPTO) / (pBrownTotal - pBrownPTO)) * 100M);
            engVM.pBrownEff = Decimal.Round(pBrownEff.Value, 2);


            var dZielkeTotal = _db.TimeTrackers.Where(t => t.EngineerId == 6).Sum(y => y.HrsWorked);
            engVM.dZielkeTotal = dZielkeTotal;

            var dZielkeEng = _db.TimeTrackers.Where(t => t.EngineerId == 6).Where(h => h.LaborCodeId == 1 || h.LaborCodeId == 2 || h.LaborCodeId == 3 || h.LaborCodeId == 4 || h.LaborCodeId == 5 || h.LaborCodeId == 6).Sum(y => y.HrsWorked);
            engVM.dZielkeEng = dZielkeEng;

            var dZielkeQuote = _db.TimeTrackers.Where(t => t.EngineerId == 6).Where(h => h.LaborCodeId == 11).Sum(y => y.HrsWorked);
            engVM.dZielkeQuote = dZielkeQuote;

            var dZielkeManual = _db.TimeTrackers.Where(t => t.EngineerId == 6).Where(h => h.LaborCodeId == 9).Sum(y => y.HrsWorked);
            engVM.dZielkeManual = dZielkeManual;

            var dZielkePTO = _db.TimeTrackers.Where(t => t.EngineerId == 6).Where(h => h.LaborCodeId == 7).Sum(y => y.HrsWorked);
            engVM.dZielkePTO = dZielkePTO;

            var dZielkeNVH = _db.TimeTrackers.Where(t => t.EngineerId == 6).Where(h => h.LaborCodeId == 8).Sum(y => y.HrsWorked);
            engVM.dZielkeNVH = dZielkeNVH;

            var dZielkeEff = (((dZielkeTotal - dZielkeNVH - dZielkePTO) / (dZielkeTotal - dZielkePTO)) * 100M);
            engVM.dZielkeEff = Decimal.Round(dZielkeEff.Value, 2);


            var kSwindlehurstTotal = _db.TimeTrackers.Where(t => t.EngineerId == 11).Sum(y => y.HrsWorked);
            engVM.kSwindlehurstTotal = kSwindlehurstTotal;

            var kSwindlehurstEng = _db.TimeTrackers.Where(t => t.EngineerId == 11).Where(h => h.LaborCodeId == 1 || h.LaborCodeId == 2 || h.LaborCodeId == 3 || h.LaborCodeId == 4 || h.LaborCodeId == 5 || h.LaborCodeId == 6).Sum(y => y.HrsWorked);
            engVM.kSwindlehurstEng = kSwindlehurstEng;

            var kSwindlehurstQuote = _db.TimeTrackers.Where(t => t.EngineerId == 11).Where(h => h.LaborCodeId == 11).Sum(y => y.HrsWorked);
            engVM.kSwindlehurstQuote = kSwindlehurstQuote;

            var kSwindlehurstManual = _db.TimeTrackers.Where(t => t.EngineerId == 11).Where(h => h.LaborCodeId == 9).Sum(y => y.HrsWorked);
            engVM.kSwindlehurstManual = kSwindlehurstManual;

            var kSwindlehurstPTO = _db.TimeTrackers.Where(t => t.EngineerId == 11).Where(h => h.LaborCodeId == 7).Sum(y => y.HrsWorked);
            engVM.kSwindlehurstPTO = kSwindlehurstPTO;

            var kSwindlehurstNVH = _db.TimeTrackers.Where(t => t.EngineerId == 11).Where(h => h.LaborCodeId == 8).Sum(y => y.HrsWorked);
            engVM.kSwindlehurstNVH = kSwindlehurstNVH;

            var kSwindlehurstEff = (((kSwindlehurstTotal - kSwindlehurstNVH - kSwindlehurstPTO) / (kSwindlehurstTotal - kSwindlehurstPTO)) * 100M);
            engVM.kSwindlehurstEff = Decimal.Round(kSwindlehurstEff.Value, 2);


            var sTidwellTotal = _db.TimeTrackers.Where(t => t.EngineerId == 15).Sum(y => y.HrsWorked);
            engVM.sTidwellTotal = sTidwellTotal;

            var sTidwellEng = _db.TimeTrackers.Where(t => t.EngineerId == 15).Where(h => h.LaborCodeId == 1 || h.LaborCodeId == 2 || h.LaborCodeId == 3 || h.LaborCodeId == 4 || h.LaborCodeId == 5 || h.LaborCodeId == 6).Sum(y => y.HrsWorked);
            engVM.sTidwellEng = sTidwellEng;

            var sTidwellQuote = _db.TimeTrackers.Where(t => t.EngineerId == 15).Where(h => h.LaborCodeId == 11).Sum(y => y.HrsWorked);
            engVM.sTidwellQuote = sTidwellQuote;

            var sTidwellManual = _db.TimeTrackers.Where(t => t.EngineerId == 15).Where(h => h.LaborCodeId == 9).Sum(y => y.HrsWorked);
            engVM.sTidwellManual = sTidwellManual;

            var sTidwellPTO = _db.TimeTrackers.Where(t => t.EngineerId == 15).Where(h => h.LaborCodeId == 7).Sum(y => y.HrsWorked);
            engVM.sTidwellPTO = sTidwellPTO;

            var sTidwellNVH = _db.TimeTrackers.Where(t => t.EngineerId == 15).Where(h => h.LaborCodeId == 8).Sum(y => y.HrsWorked);
            engVM.sTidwellNVH = sTidwellNVH;

            var sTidwellEff = (((sTidwellTotal - sTidwellNVH - sTidwellPTO) / (sTidwellTotal - sTidwellPTO)) * 100M);
            engVM.sTidwellEff = Decimal.Round(sTidwellEff.Value, 2);


            var rBrownTotal = _db.TimeTrackers.Where(t => t.EngineerId == 14).Sum(y => y.HrsWorked);
            engVM.rBrownTotal = rBrownTotal;

            var rBrownEng = _db.TimeTrackers.Where(t => t.EngineerId == 14).Where(h => h.LaborCodeId == 1 || h.LaborCodeId == 2 || h.LaborCodeId == 3 || h.LaborCodeId == 4 || h.LaborCodeId == 5 || h.LaborCodeId == 6).Sum(y => y.HrsWorked);
            engVM.rBrownEng = rBrownEng;

            var rBrownQuote = _db.TimeTrackers.Where(t => t.EngineerId == 14).Where(h => h.LaborCodeId == 11).Sum(y => y.HrsWorked);
            engVM.rBrownQuote = rBrownQuote;

            var rBrownManual = _db.TimeTrackers.Where(t => t.EngineerId == 14).Where(h => h.LaborCodeId == 9).Sum(y => y.HrsWorked);
            engVM.rBrownManual = rBrownManual;

            var rBrownPTO = _db.TimeTrackers.Where(t => t.EngineerId == 14).Where(h => h.LaborCodeId == 7).Sum(y => y.HrsWorked);
            engVM.rBrownPTO = rBrownPTO;

            var rBrownNVH = _db.TimeTrackers.Where(t => t.EngineerId == 14).Where(h => h.LaborCodeId == 8).Sum(y => y.HrsWorked);
            engVM.rBrownNVH = rBrownNVH;

            var rBrownEff = (((rBrownTotal - rBrownNVH - rBrownPTO) / (rBrownTotal - rBrownPTO)) * 100M);
            engVM.rBrownEff = Decimal.Round(rBrownEff.Value, 2);


            var pKimberlinTotal = _db.TimeTrackers.Where(t => t.EngineerId == 13).Sum(y => y.HrsWorked);
            engVM.pKimberlinTotal = pKimberlinTotal;

            var pKimberlinEng = _db.TimeTrackers.Where(t => t.EngineerId == 13).Where(h => h.LaborCodeId == 1 || h.LaborCodeId == 2 || h.LaborCodeId == 3 || h.LaborCodeId == 4 || h.LaborCodeId == 5 || h.LaborCodeId == 6).Sum(y => y.HrsWorked);
            engVM.pKimberlinEng = pKimberlinEng;

            var pKimberlinQuote = _db.TimeTrackers.Where(t => t.EngineerId == 13).Where(h => h.LaborCodeId == 11).Sum(y => y.HrsWorked);
            engVM.pKimberlinQuote = pKimberlinQuote;

            var pKimberlinManual = _db.TimeTrackers.Where(t => t.EngineerId == 13).Where(h => h.LaborCodeId == 9).Sum(y => y.HrsWorked);
            engVM.pKimberlinManual = pKimberlinManual;

            var pKimberlinPTO = _db.TimeTrackers.Where(t => t.EngineerId == 13).Where(h => h.LaborCodeId == 7).Sum(y => y.HrsWorked);
            engVM.pKimberlinPTO = pKimberlinPTO;

            var pKimberlinNVH = _db.TimeTrackers.Where(t => t.EngineerId == 13).Where(h => h.LaborCodeId == 8).Sum(y => y.HrsWorked);
            engVM.pKimberlinNVH = pKimberlinNVH;

            var pKimberlinEff = (((pKimberlinTotal - pKimberlinNVH - pKimberlinPTO) / (pKimberlinTotal - pKimberlinPTO)) * 100M);
            engVM.pKimberlinEff = Decimal.Round(pKimberlinEff.Value, 2);


            var dHerrTotal = _db.TimeTrackers.Where(t => t.EngineerId == 9).Sum(y => y.HrsWorked);
            engVM.dHerrTotal = dHerrTotal;

            var dHerrEng = _db.TimeTrackers.Where(t => t.EngineerId == 9).Where(h => h.LaborCodeId == 1 || h.LaborCodeId == 2 || h.LaborCodeId == 3 || h.LaborCodeId == 4 || h.LaborCodeId == 5 || h.LaborCodeId == 6).Sum(y => y.HrsWorked);
            engVM.dHerrEng = dHerrEng;

            var dHerrQuote = _db.TimeTrackers.Where(t => t.EngineerId == 9).Where(h => h.LaborCodeId == 11).Sum(y => y.HrsWorked);
            engVM.dHerrQuote = dHerrQuote;

            var dHerrManual = _db.TimeTrackers.Where(t => t.EngineerId == 9).Where(h => h.LaborCodeId == 9).Sum(y => y.HrsWorked);
            engVM.dHerrManual = dHerrManual;

            var dHerrPTO = _db.TimeTrackers.Where(t => t.EngineerId == 9).Where(h => h.LaborCodeId == 7).Sum(y => y.HrsWorked);
            engVM.dHerrPTO = dHerrPTO;

            var dHerrNVH = _db.TimeTrackers.Where(t => t.EngineerId == 9).Where(h => h.LaborCodeId == 8).Sum(y => y.HrsWorked);
            engVM.dHerrNVH = dHerrNVH;

            var dHerrEff = (((dHerrTotal - dHerrNVH - dHerrPTO) / (dHerrTotal - dHerrPTO)) * 100M);
            engVM.dHerrEff = Decimal.Round(dHerrEff.Value, 2);


            var totalHrs = _db.TimeTrackers.Sum(y => y.HrsWorked);
            engVM.totalHrs = totalHrs;

            var totalEng = _db.TimeTrackers.Where(h => h.LaborCodeId == 1 || h.LaborCodeId == 2 || h.LaborCodeId == 3 || h.LaborCodeId == 4 || h.LaborCodeId == 5 || h.LaborCodeId == 6).Sum(y => y.HrsWorked);
            engVM.totalEng = totalEng;

            var totalQuote = _db.TimeTrackers.Where(h => h.LaborCodeId == 11).Sum(y => y.HrsWorked);
            engVM.totalQuote = totalQuote;

            var totalManual = _db.TimeTrackers.Where(h => h.LaborCodeId == 9).Sum(y => y.HrsWorked);
            engVM.totalManual = totalManual;

            var totalPTO = _db.TimeTrackers.Where(h => h.LaborCodeId == 7).Sum(y => y.HrsWorked);
            engVM.totalPTO = totalPTO;

            var totalNVH = _db.TimeTrackers.Where(h => h.LaborCodeId == 8).Sum(y => y.HrsWorked);
            engVM.totalNVH = totalNVH;

            var totalEff = (((totalHrs - totalNVH - totalPTO) / (totalHrs - totalPTO)) * 100M);
            engVM.totalEff = Decimal.Round(totalEff.Value, 2);


            return View(engVM);

        }

        public ActionResult EmpEffReport()
        {

            var engineers = _db.Engineers.ToList();
            //var fromDate = DateOnly.FromDateTime(DateTime.Now);
            //var toDate = DateOnly.FromDateTime(DateTime.Now);

            TimeTrackerVM1 timeTrackerVM = new TimeTrackerVM1()
            {
                Engineers = engineers,
                FromDate = null,
                ToDate = null,
            };

            return View(timeTrackerVM);

        }

        [HttpPost]
        public IActionResult EmpEffReport(TimeTrackerVM1 ttVM)
        {
            //var objCategoryList = _db.Categories.ToList();
            //IEnumerable<OrderHeader> orderHeaderList = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser");
            //return View(orderHeaderList);

            //var fromDate = ttVM.FromDate.ToDateTime(TimeOnly.Parse("12:00 AM"));
            //var toDate = ttVM.ToDate.ToDateTime(TimeOnly.Parse("12:00 AM"));
            var fromDate = ttVM.FromDate;
            var toDate = ttVM.ToDate;

            var id = ttVM.Engineer.Id;

            var query = from a in _db.TimeTrackers
                        join b in _db.Engineers.Where(y => y.Id == id) on a.EngineerId equals b.Id
                        join c in _db.LaborCodes on a.LaborCodeId equals c.LaborCodeId
                        where a.DateWorkPerformed >= fromDate && a.DateWorkPerformed <= toDate
                        select new
                        {
                            DateWorkPerformed = a.DateWorkPerformed,
                            Engineer = b.EngineerName,
                            JobNumber = a.JobNumber,
                            LaborCode = c.LaborCodeName,
                            HrsWorked = a.HrsWorked,
                            WorkDescription = a.WorkDescription
                        };

            var hrsWorked = query.SelectMany(x => x.JobNumber);

            var query1 = from b in _db.EngineeringLogs
                         where b.Engineer.Id == id && (b.LogStatusId != 16 || b.LogStatusId != 17)
                         select new
                         {
                             b.Id,
                             b.JobNumber,
                             b.QuotedEngHrs,
                             b.QuotedShopHrs
                         };

            var open = query1.Count();
            var quotedEngHrs = query1.Select(x => x.QuotedEngHrs).Sum();
            var quotedShopHrs = query1.Select(x => x.QuotedShopHrs).Sum();




            List < TimeTrackerVM1 > result = new List<TimeTrackerVM1>();
            foreach (var pfep in query.ToList())
            {
                result.Add(new TimeTrackerVM1
                {
                    DateWorkPerformed = pfep.DateWorkPerformed,
                    Name = pfep.Engineer,
                    JobNumber = pfep.JobNumber,
                    LaborCodeName = pfep.LaborCode,
                    HrsWorked = pfep.HrsWorked,
                    WorkDescription = pfep.WorkDescription,
                });
            }


            return View("EmpEffReport1", result);

            //return View("Index", query.ToList());
        }

        public ActionResult ProjectTimeReport()
        {

            var engineeringLogs = from a in _db.EngineeringLogs
                                  join b in _db.LogStatuses on a.LogStatusId equals b.LogStatusId
                                  join c in _db.Estimators on a.EstimatorId equals c.Id
                                  join d in _db.Engineers on a.EngineerId equals d.Id
                                  join e in _db.MfgLocations on a.MfgLocationId equals e.Id
                                  join f in _db.SalesLocations on a.SalesLocationId equals f.Id
                                  where b.LogStatusId == 6 || b.LogStatusId == 7 || b.LogStatusId == 8 || b.LogStatusId == 9 || b.LogStatusId == 10 || b.LogStatusId == 11 || b.LogStatusId == 12 || b.LogStatusId == 13 || b.LogStatusId == 14 || b.LogStatusId == 15 || b.LogStatusId == 16 || b.LogStatusId == 17 || b.LogStatusId == 18
                                  orderby a.JobNumber descending
                                  select a;

            //var fromDate = DateOnly.FromDateTime(DateTime.Now);
            //var toDate = DateOnly.FromDateTime(DateTime.Now);

            EngLogVM1 engLogVM1 = new EngLogVM1()
            {

                EngineeringLogs = engineeringLogs

            };

            return View(engLogVM1);

        }

        [HttpPost]
        public IActionResult ProjectTimeReport(EngLogVM1 engLogVM1)
        {
            //var objCategoryList = _db.Categories.ToList();
            //IEnumerable<OrderHeader> orderHeaderList = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser");
            //return View(orderHeaderList);

            //var fromDate = ttVM.FromDate.ToDateTime(TimeOnly.Parse("12:00 AM"));
            //var toDate = ttVM.ToDate.ToDateTime(TimeOnly.Parse("12:00 AM"));

            var job = engLogVM1.EngineeringLog.JobNumber;

            var query = from a in _db.TimeTrackers
                        join b in _db.Engineers on a.EngineerId equals b.Id
                        join c in _db.LaborCodes on a.LaborCodeId equals c.LaborCodeId
                        where a.JobNumber == job
                        select new
                        {
                            DateWorkPerformed = a.DateWorkPerformed,
                            Engineer = b.EngineerName,
                            JobNumber = a.JobNumber,
                            LaborCode = c.LaborCodeName,
                            HrsWorked = a.HrsWorked,
                            WorkDescription = a.WorkDescription
                        };


            List<TimeTrackerVM1> result = new List<TimeTrackerVM1>();
            foreach (var pfep in query.ToList())
            {
                result.Add(new TimeTrackerVM1
                {
                    DateWorkPerformed = pfep.DateWorkPerformed,
                    Name = pfep.Engineer,
                    JobNumber = pfep.JobNumber,
                    LaborCodeName = pfep.LaborCode,
                    HrsWorked = pfep.HrsWorked,
                    WorkDescription = pfep.WorkDescription,
                });
            }


            return View("ProjectTimeReport1", result);

            //return View("Index", query.ToList());
        }



        public IActionResult QuoteDashboard()
        {

            var query1 = from a in _db.EngineeringLogs
                         join b in _db.Estimators on a.EstimatorId equals b.Id
                         where a.LogStatusId == 1 || a.LogStatusId == 2 || a.LogStatusId == 3 || a.LogStatusId == 4
                         orderby a.QuoteRequestReceivedDate descending
                         select new
                         {
                             a.QuoteNo,
                             a.Estimator.EstimatorName,
                             a.Customer,
                             a.SystemDescription,
                             a.QuoteRequestReceivedDate,
                             a.QuoteTargetDate,
                             a.InitialQuoteReviewTargetDate,
                             a.InitialQuoteReviewDate,
                             a.FinalQuoteReviewTargetDate,
                             a.FinalQuoteReviewDate,
                             a.QuoteDate
                         };

            List<EngLogVM1> result = new List<EngLogVM1>();
            foreach (var pfep in query1.ToList())
            {
                result.Add(new EngLogVM1
                {
                    QuoteNo = pfep.QuoteNo,
                    EstimatorName = pfep.EstimatorName,
                    Customer = pfep.Customer,
                    SystemDescription = pfep.SystemDescription,
                    QuoteReceivedDate = pfep.QuoteRequestReceivedDate,
                    QuoteTargetDate = pfep.QuoteTargetDate,
                    InitialQuoteReviewTargetDate = pfep.InitialQuoteReviewTargetDate,
                    InitialQuoteReviewDate = pfep.InitialQuoteReviewDate,
                    FinalQuoteReviewTargetDate = pfep.FinalQuoteReviewTargetDate,
                    FinalQuoteReviewDate = pfep.FinalQuoteReviewDate,
                    QuoteDate = pfep.QuoteDate
                });
            }


            return View("QuoteDashboard", result);

            //return View("Index", query.ToList());
        }

        public IActionResult DesignDashboard()
        {

            var query1 = from a in _db.EngineeringLogs
                         join b in _db.Engineers on a.EngineerId equals b.Id
                         where a.LogStatusId == 6 || a.LogStatusId == 7 || a.LogStatusId == 8 || a.LogStatusId == 9 || a.LogStatusId == 10 || a.LogStatusId == 11 || a.LogStatusId == 12
                         orderby a.QuoteRequestReceivedDate descending
                         select new
                         {
                             a.JobNumber,
                             a.Engineer.EngineerName,
                             a.Customer,
                             a.SystemDescription,
                             a.KickOffTargetDate,
                             a.KickOffDate,
                             a.FinancialReviewTargetDate,
                             a.FinancialReviewDate,
                             a.InitialDesignReviewTargetDate,
                             a.InitialDesignReviewDate,
                             a.FinalDesignReviewTargetDate,
                             a.FinalDesignReviewDate,
                             a.ShopReleaseTargetDate,
                             a.ShopReleaseDate
                         };

            List<EngLogVM1> result = new List<EngLogVM1>();
            foreach (var pfep in query1.ToList())
            {
                result.Add(new EngLogVM1
                {
                    JobNumber = pfep.JobNumber,
                    EngineerName = pfep.EngineerName,
                    Customer = pfep.Customer,
                    SystemDescription = pfep.SystemDescription,
                    KickOffTD = pfep.KickOffTargetDate,
                    KickOffD = pfep.KickOffDate,
                    FinancialReviewTargetDate = pfep.FinancialReviewTargetDate,
                    FinancialReviewDate = pfep.FinancialReviewDate,
                    InitialDesignReviewTargetDate = pfep.InitialDesignReviewTargetDate,
                    InitialDesignReviewDate = pfep.InitialDesignReviewDate,
                    FinalDesignReviewTargetDate = pfep.FinalDesignReviewTargetDate,
                    FinalDesignReviewDate = pfep.FinalDesignReviewDate,
                    ShopReleaseTargetDate = pfep.ShopReleaseTargetDate,
                    ShopReleaseDate = pfep.ShopReleaseDate
                });
            }


            return View("DesignDashboard", result);

            //return View("Index", query.ToList());
        }


        public ActionResult EmpEff1Report()
        {

            var engineers = _db.Engineers.ToList();
            //var fromDate = DateOnly.FromDateTime(DateTime.Now);
            //var toDate = DateOnly.FromDateTime(DateTime.Now);

            TimeTrackerVM1 timeTrackerVM = new TimeTrackerVM1()
            {
                Engineers = engineers,
                FromDate = null,
                ToDate = null,
            };

            return View(timeTrackerVM);

        }

        [HttpPost]
        public IActionResult EmpEff1Report(TimeTrackerVM1 ttVM)
        {
            //var objCategoryList = _db.Categories.ToList();
            //IEnumerable<OrderHeader> orderHeaderList = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser");
            //return View(orderHeaderList);

            //var fromDate = ttVM.FromDate.ToDateTime(TimeOnly.Parse("12:00 AM"));
            //var toDate = ttVM.ToDate.ToDateTime(TimeOnly.Parse("12:00 AM"));
            var fromDate = ttVM.FromDate;
            var toDate = ttVM.ToDate;
            var id = ttVM.Engineer.Id;

            var engName = _db.Engineers.Where(x => x.Id == id).Select(x => x.EngineerName).FirstOrDefault();
            var imageUrl = _db.Engineers.Where(x => x.Id == id).Select(x => x.ImageUrl).FirstOrDefault();

            var query = from a in _db.TimeTrackers
                        join b in _db.Engineers.Where(y => y.Id == id) on a.EngineerId equals b.Id
                        join c in _db.LaborCodes on a.LaborCodeId equals c.LaborCodeId
                        select new
                        {
                            Engineer = b.EngineerName,
                            JobNumber = a.JobNumber,
                            LaborCode = c.LaborCodeName,
                            HrsWorked = a.HrsWorked,
                            WorkDescription = a.WorkDescription
                        };


            var hrsWorked = query.SelectMany(x => x.JobNumber);

            var query1 = from b in _db.EngineeringLogs
                         where b.Engineer.Id == id && (b.LogStatusId != 16 && b.LogStatusId != 17)
                         select new
                         {
                             b.Id,
                             b.JobNumber,
                             b.QuotedEngHrs,
                             b.QuotedShopHrs
                         };

            var queryGrouped = from a in query
                               join b in query1 on a.JobNumber equals b.JobNumber
                               group a.HrsWorked by b.JobNumber into g
                               select new
                               {
                                    g.Key,
                                    HrsWorked = g.Sum()
                                  
                               };


            var queryGrouped2 = from a in queryGrouped
                                join b in query1 on a.Key equals b.JobNumber
                                select new
                                {
                                    a.Key,
                                    b.QuotedEngHrs,
                                    a.HrsWorked
                                };

            var countProjectsOverHrs = 0;
            foreach (var a in queryGrouped2.ToList())
            {
                if (a.HrsWorked > a.QuotedEngHrs)
                {
                    countProjectsOverHrs++;
                }
            }

            var openEngTime = from a in query
                              join b in query1 on a.JobNumber equals b.JobNumber
                              select new
                              {
                                  a.HrsWorked
                              };

            var actualOpenEngHrs = openEngTime.Select(y => y.HrsWorked).Sum();

            var projectsOverHrs = openEngTime.Count();

            var open = query1.Count();
            var quotedEngHrs = query1.Select(x => x.QuotedEngHrs).Sum();
            var quotedShopHrs = query1.Select(x => x.QuotedShopHrs).Sum();
            
            var currentOpenEff = new decimal?();
            if (actualOpenEngHrs > 0)
            {
                currentOpenEff = actualOpenEngHrs / quotedEngHrs;
            }
            else
            {
                currentOpenEff = new decimal?(0);
            }

            var currentOpenEffPercentage = Math.Round((decimal)currentOpenEff * 100, 2).ToString() + "%";

            TimeTrackerVM1 result = new TimeTrackerVM1();
            result.OpenProjects = open;
            result.OpenProjectsOverHrs = countProjectsOverHrs;
            result.QuotedEngHrs = quotedEngHrs;
            result.CurrentOpenEff = currentOpenEffPercentage;
            result.ActualEngHrs = actualOpenEngHrs;
            result.Name = engName;
            result.ImageUrl = imageUrl;


            var query10 = from a in _db.EngineeringLogs
                          join b in _db.EcnLogs on a.Id equals b.EngineeringLogId
                          select new
                          {
                              a.Id,
                              a.Engineer.EngineerName,
                              //b.Ecn
                          };


            List < EngViewMetricsVM > engMetrics = new List<EngViewMetricsVM>();

            return View("EmpEffReport2", result);

            //return View("Index", query.ToList());
        }

        public IActionResult EngTTReport()
        {

            return View("EngTTReport");

        }

        [HttpPost]
        public IActionResult EngTTReport(TimeTrackerVM1 ttVM)
        {
            //var objCategoryList = _db.Categories.ToList();
            //IEnumerable<OrderHeader> orderHeaderList = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser");
            //return View(orderHeaderList);

            //var fromDate = ttVM.FromDate.ToDateTime(TimeOnly.Parse("12:00 AM"));
            //var toDate = ttVM.ToDate.ToDateTime(TimeOnly.Parse("12:00 AM"));
            
            var fromDate = ttVM.FromDate;
            var toDate = ttVM.ToDate;

            var query = from a in _db.TimeTrackers
                        join b in _db.Engineers on a.EngineerId equals b.Id
                        join c in _db.LaborCodes on a.LaborCodeId equals c.LaborCodeId
                        where a.DateWorkPerformed >= fromDate && a.DateWorkPerformed <= toDate
                        select new
                        {
                            DateWorkPerformed = a.DateWorkPerformed,
                            Engineer = b.EngineerName,
                            JobNumber = a.JobNumber,
                            LaborCode = c.LaborCodeName,
                            HrsWorked = a.HrsWorked,
                            WorkDescription = a.WorkDescription
                        };

            List<TimeTrackerVM1> result = new List<TimeTrackerVM1>();
            foreach (var pfep in query.ToList())
            {
                result.Add(new TimeTrackerVM1
                {
                    DateWorkPerformed = pfep.DateWorkPerformed,
                    Name = pfep.Engineer,
                    JobNumber = pfep.JobNumber,
                    LaborCodeName = pfep.LaborCode,
                    HrsWorked = pfep.HrsWorked,
                    WorkDescription = pfep.WorkDescription,
                });
            }


            return View("EngTTReport1", result);

            //return View("Index", query.ToList());
        }

        public IActionResult TTList()
        {
            //var objCategoryList = _db.Categories.ToList();
            //IEnumerable<OrderHeader> orderHeaderList = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser");
            //return View(orderHeaderList);

            var baselinedate = DateTime.Now.AddDays(-30);

            var query = from a in _db.TimeTrackers
                        join e in _db.Engineers on a.EngineerId equals e.Id
                        join co in _db.FloLocations on a.FloLocationId equals co.FloLocationId
                        join y in _db.LaborCodes on a.LaborCodeId equals y.LaborCodeId
                        where a.DateWorkPerformed >= baselinedate
                        orderby a.Id descending
                        select new
                        {
                            a.Id,
                            a.DateWorkPerformed,
                            a.JobNumber,
                            a.CustomerName,
                            a.FloLocation.LocationName,
                            a.Engineer.EngineerName,
                            a.LaborCode.LaborCodeName,
                            a.ProjectName,
                            a.WorkDescription,
                            a.HrsWorked,
                            a.Notes
                        };

            List<TimeTrackerVM1> result = new List<TimeTrackerVM1>();
            foreach (var pfep in query.ToList())
            {
                result.Add(new TimeTrackerVM1
                {
                    Id = pfep.Id,
                    DateWorkPerformed = pfep.DateWorkPerformed,
                    JobNumber = pfep.JobNumber,
                    CustomerName = pfep.CustomerName,
                    LocationName = pfep.LocationName,
                    Name = pfep.EngineerName,
                    LaborCodeName = pfep.LaborCodeName,
                    ProjectName = pfep.ProjectName,
                    WorkDescription = pfep.WorkDescription,
                    HrsWorked = pfep.HrsWorked,
                    Notes = pfep.Notes
                });
            }

            return View(result);

            //return View("Index", query.ToList());
        }

        public IActionResult TTList90()
        {
            //var objCategoryList = _db.Categories.ToList();
            //IEnumerable<OrderHeader> orderHeaderList = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser");
            //return View(orderHeaderList);

            var baselinedate = DateTime.Now.AddDays(-90);

            var query = from a in _db.TimeTrackers
                        join e in _db.Engineers on a.EngineerId equals e.Id
                        join co in _db.FloLocations on a.FloLocationId equals co.FloLocationId
                        join y in _db.LaborCodes on a.LaborCodeId equals y.LaborCodeId
                        where a.DateWorkPerformed >= baselinedate
                        orderby a.Id descending
                        select new
                        {
                            a.Id,
                            a.DateWorkPerformed,
                            a.JobNumber,
                            a.CustomerName,
                            a.FloLocation.LocationName,
                            a.Engineer.EngineerName,
                            a.LaborCode.LaborCodeName,
                            a.ProjectName,
                            a.WorkDescription,
                            a.HrsWorked,
                            a.Notes
                        };

            List<TimeTrackerVM1> result = new List<TimeTrackerVM1>();
            foreach (var pfep in query.ToList())
            {
                result.Add(new TimeTrackerVM1
                {
                    Id = pfep.Id,
                    DateWorkPerformed = pfep.DateWorkPerformed,
                    JobNumber = pfep.JobNumber,
                    CustomerName = pfep.CustomerName,
                    LocationName = pfep.LocationName,
                    Name = pfep.EngineerName,
                    LaborCodeName = pfep.LaborCodeName,
                    ProjectName = pfep.ProjectName,
                    WorkDescription = pfep.WorkDescription,
                    HrsWorked = pfep.HrsWorked,
                    Notes = pfep.Notes
                });
            }

            return View("TTList", result);

            //return View("Index", query.ToList());
        }

        public IActionResult TTListAll()
        {
            //var objCategoryList = _db.Categories.ToList();
            //IEnumerable<OrderHeader> orderHeaderList = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser");
            //return View(orderHeaderList);

            var baselinedate = DateTime.Now.AddDays(-90);

            var query = from a in _db.TimeTrackers
                        join e in _db.Engineers on a.EngineerId equals e.Id
                        join co in _db.FloLocations on a.FloLocationId equals co.FloLocationId
                        join y in _db.LaborCodes on a.LaborCodeId equals y.LaborCodeId
                        //where a.DateWorkPerformed >= baselinedate
                        orderby a.Id descending
                        select new
                        {
                            a.Id,
                            a.DateWorkPerformed,
                            a.JobNumber,
                            a.CustomerName,
                            a.FloLocation.LocationName,
                            a.Engineer.EngineerName,
                            a.LaborCode.LaborCodeName,
                            a.ProjectName,
                            a.WorkDescription,
                            a.HrsWorked,
                            a.Notes
                        };

            List<TimeTrackerVM1> result = new List<TimeTrackerVM1>();
            foreach (var pfep in query.ToList())
            {
                result.Add(new TimeTrackerVM1
                {
                    Id = pfep.Id,
                    DateWorkPerformed = pfep.DateWorkPerformed,
                    JobNumber = pfep.JobNumber,
                    CustomerName = pfep.CustomerName,
                    LocationName = pfep.LocationName,
                    Name = pfep.EngineerName,
                    LaborCodeName = pfep.LaborCodeName,
                    ProjectName = pfep.ProjectName,
                    WorkDescription = pfep.WorkDescription,
                    HrsWorked = pfep.HrsWorked,
                    Notes = pfep.Notes
                });
            }

            return View("TTList", result);

            //return View("Index", query.ToList());
        }

        public IActionResult TTListLast180()
        {
            //var objCategoryList = _db.Categories.ToList();
            //IEnumerable<OrderHeader> orderHeaderList = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser");
            //return View(orderHeaderList);

            var baselinedate = DateTime.Now.AddDays(-180);

            var query = from a in _db.TimeTrackers
                        join e in _db.Engineers on a.EngineerId equals e.Id
                        join co in _db.FloLocations on a.FloLocationId equals co.FloLocationId
                        join y in _db.LaborCodes on a.LaborCodeId equals y.LaborCodeId
                        where a.DateWorkPerformed >= baselinedate
                        orderby a.Id descending
                        select new
                        {
                            a.Id,
                            a.DateWorkPerformed,
                            a.JobNumber,
                            a.CustomerName,
                            a.FloLocation.LocationName,
                            a.Engineer.EngineerName,
                            a.LaborCode.LaborCodeName,
                            a.ProjectName,
                            a.WorkDescription,
                            a.HrsWorked,
                            a.Notes
                        };

            List<TimeTrackerVM1> result = new List<TimeTrackerVM1>();
            foreach (var pfep in query.ToList())
            {
                result.Add(new TimeTrackerVM1
                {
                    Id = pfep.Id,
                    DateWorkPerformed = pfep.DateWorkPerformed,
                    JobNumber = pfep.JobNumber,
                    CustomerName = pfep.CustomerName,
                    LocationName = pfep.LocationName,
                    Name = pfep.EngineerName,
                    LaborCodeName = pfep.LaborCodeName,
                    ProjectName = pfep.ProjectName,
                    WorkDescription = pfep.WorkDescription,
                    HrsWorked = pfep.HrsWorked,
                    Notes = pfep.Notes
                });
            }

            return View("TTList", result);

            //return View("Index", query.ToList());
        }

        public IActionResult TTListLast180to365()
        {
            //var objCategoryList = _db.Categories.ToList();
            //IEnumerable<OrderHeader> orderHeaderList = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser");
            //return View(orderHeaderList);

            var baselinedate = DateTime.Now.AddDays(-180);
            var yearagodate = DateTime.Now.AddDays(-365);

            var query = from a in _db.TimeTrackers
                        join e in _db.Engineers on a.EngineerId equals e.Id
                        join co in _db.FloLocations on a.FloLocationId equals co.FloLocationId
                        join y in _db.LaborCodes on a.LaborCodeId equals y.LaborCodeId
                        where a.DateWorkPerformed >= yearagodate && a.DateWorkPerformed <= baselinedate
                        orderby a.Id descending
                        select new
                        {
                            a.Id,
                            a.DateWorkPerformed,
                            a.JobNumber,
                            a.CustomerName,
                            a.FloLocation.LocationName,
                            a.Engineer.EngineerName,
                            a.LaborCode.LaborCodeName,
                            a.ProjectName,
                            a.WorkDescription,
                            a.HrsWorked,
                            a.Notes
                        };

            List<TimeTrackerVM1> result = new List<TimeTrackerVM1>();
            foreach (var pfep in query.ToList())
            {
                result.Add(new TimeTrackerVM1
                {
                    Id = pfep.Id,
                    DateWorkPerformed = pfep.DateWorkPerformed,
                    JobNumber = pfep.JobNumber,
                    CustomerName = pfep.CustomerName,
                    LocationName = pfep.LocationName,
                    Name = pfep.EngineerName,
                    LaborCodeName = pfep.LaborCodeName,
                    ProjectName = pfep.ProjectName,
                    WorkDescription = pfep.WorkDescription,
                    HrsWorked = pfep.HrsWorked,
                    Notes = pfep.Notes
                });
            }

            return View("TTList", result);

            //return View("Index", query.ToList());
        }

        public IActionResult TTList2024()
        {
            //var objCategoryList = _db.Categories.ToList();
            //IEnumerable<OrderHeader> orderHeaderList = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser");
            //return View(orderHeaderList);

            var baselinedate = DateTime.Now.AddDays(-180);
            var yearagodate = DateTime.Now.AddDays(-365);
            var startDate = DateTime.Parse("1/1/2024");
            var endDate = DateTime.Parse("12/31/2024");

            var query = from a in _db.TimeTrackers
                        join e in _db.Engineers on a.EngineerId equals e.Id
                        join co in _db.FloLocations on a.FloLocationId equals co.FloLocationId
                        join y in _db.LaborCodes on a.LaborCodeId equals y.LaborCodeId
                        where a.DateWorkPerformed >= startDate && a.DateWorkPerformed <= endDate
                        orderby a.Id descending
                        select new
                        {
                            a.Id,
                            a.DateWorkPerformed,
                            a.JobNumber,
                            a.CustomerName,
                            a.FloLocation.LocationName,
                            a.Engineer.EngineerName,
                            a.LaborCode.LaborCodeName,
                            a.ProjectName,
                            a.WorkDescription,
                            a.HrsWorked,
                            a.Notes
                        };

            List<TimeTrackerVM1> result = new List<TimeTrackerVM1>();
            foreach (var pfep in query.ToList())
            {
                result.Add(new TimeTrackerVM1
                {
                    Id = pfep.Id,
                    DateWorkPerformed = pfep.DateWorkPerformed,
                    JobNumber = pfep.JobNumber,
                    CustomerName = pfep.CustomerName,
                    LocationName = pfep.LocationName,
                    Name = pfep.EngineerName,
                    LaborCodeName = pfep.LaborCodeName,
                    ProjectName = pfep.ProjectName,
                    WorkDescription = pfep.WorkDescription,
                    HrsWorked = pfep.HrsWorked,
                    Notes = pfep.Notes
                });
            }

            return View("TTList", result);

            //return View("Index", query.ToList());
        }

        public IActionResult TTList2023()
        {
            //var objCategoryList = _db.Categories.ToList();
            //IEnumerable<OrderHeader> orderHeaderList = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser");
            //return View(orderHeaderList);

            var baselinedate = DateTime.Now.AddDays(-180);
            var yearagodate = DateTime.Now.AddDays(-365);
            var startDate = DateTime.Parse("1/1/2023");
            var endDate = DateTime.Parse("12/31/2023");

            var query = from a in _db.TimeTrackers
                        join e in _db.Engineers on a.EngineerId equals e.Id
                        join co in _db.FloLocations on a.FloLocationId equals co.FloLocationId
                        join y in _db.LaborCodes on a.LaborCodeId equals y.LaborCodeId
                        where a.DateWorkPerformed >= startDate && a.DateWorkPerformed <= endDate
                        orderby a.Id descending
                        select new
                        {
                            a.Id,
                            a.DateWorkPerformed,
                            a.JobNumber,
                            a.CustomerName,
                            a.FloLocation.LocationName,
                            a.Engineer.EngineerName,
                            a.LaborCode.LaborCodeName,
                            a.ProjectName,
                            a.WorkDescription,
                            a.HrsWorked,
                            a.Notes
                        };

            List<TimeTrackerVM1> result = new List<TimeTrackerVM1>();
            foreach (var pfep in query.ToList())
            {
                result.Add(new TimeTrackerVM1
                {
                    Id = pfep.Id,
                    DateWorkPerformed = pfep.DateWorkPerformed,
                    JobNumber = pfep.JobNumber,
                    CustomerName = pfep.CustomerName,
                    LocationName = pfep.LocationName,
                    Name = pfep.EngineerName,
                    LaborCodeName = pfep.LaborCodeName,
                    ProjectName = pfep.ProjectName,
                    WorkDescription = pfep.WorkDescription,
                    HrsWorked = pfep.HrsWorked,
                    Notes = pfep.Notes
                });
            }

            return View("TTList", result);

            //return View("Index", query.ToList());
        }

        public IActionResult UpsertTT(int? id)
        {
            IEnumerable<SelectListItem> FloLocationList = _unitOfWork.FloLocation
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.LocationName,
                    Value = u.FloLocationId.ToString()
                });

            IEnumerable<SelectListItem> LaborCodeList = _unitOfWork.LaborCode
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.LaborCodeName,
                    Value = u.LaborCodeId.ToString()
                });

            IEnumerable<SelectListItem> EngineerList = _unitOfWork.Engineer
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.EngineerName,
                    Value = u.Id.ToString()
                });

            ViewBag.FloLocationList = FloLocationList;
            ViewBag.LaborCodeList = LaborCodeList;
            ViewBag.EngineerList = EngineerList;
            //ViewData["CategoryList"] = CategoryList;
            TimeTrackerVM timeTrackerVM = new TimeTrackerVM()
            {
                LaborCodeList = LaborCodeList,
                FloLocationList = FloLocationList,
                EngineerList = EngineerList,
                TimeTracker = new TimeTracker()
            };



            if (id == null || id == 0)
            {
                //create
                timeTrackerVM.TimeTracker.DateWorkPerformed = null;
                return View(timeTrackerVM);
            }
            else
            {
                //update
                timeTrackerVM.TimeTracker = _unitOfWork.TimeTracker.Get(u => u.Id == id);
                return View(timeTrackerVM);
            }

        }



        [HttpPost]
        public IActionResult UpsertTT(TimeTrackerVM timeTrackerVM)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {

                if (timeTrackerVM.TimeTracker.Id == 0)
                {
                    _unitOfWork.TimeTracker.Add(timeTrackerVM.TimeTracker);
                }
                else
                {
                    _unitOfWork.TimeTracker.Update(timeTrackerVM.TimeTracker);
                }

                //_db.Categories.Add(c);
                //_unitOfWork.Product.Add(productVM.Product);
                //_db.SaveChanges();
                _unitOfWork.Save();
                TempData["success"] = "Time entry created successfully";
                return RedirectToAction("TTlist", "Engineering");
            }
            else
            {
                timeTrackerVM.FloLocationList = _unitOfWork.FloLocation.GetAll().Select(u => new SelectListItem
                {
                    Text = u.LocationName,
                    Value = u.FloLocationId.ToString()
                });

                timeTrackerVM.LaborCodeList = _unitOfWork.LaborCode.GetAll().Select(u => new SelectListItem
                {
                    Text = u.LaborCodeName,
                    Value = u.LaborCodeId.ToString()
                });

                timeTrackerVM.EngineerList = _unitOfWork.ApplicationUser.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });

                return View(timeTrackerVM);
            }
        }

        public IActionResult TimeFrameReport()
        {

            return View("TimeFrameReport");

        }

        [HttpPost]
        public IActionResult TimeFrameReport(OrderVM_Lite orderVM)
        {
            //var objCategoryList = _db.Categories.ToList();
            //IEnumerable<OrderHeader> orderHeaderList = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser");
            //return View(orderHeaderList);

            var fromDate = orderVM.FromDate.ToDateTime(TimeOnly.Parse("12:00 AM"));
            var toDate = orderVM.ToDate.ToDateTime(TimeOnly.Parse("12:00 AM"));


            var query = from a in _db.OrderHeaders
                        where a.OrderDate >= fromDate && a.OrderDate <= toDate
                        select new
                        {
                            a.Id,
                            a.OrderDate,
                            a.PurchaseOrderNo,
                            a.ApplicationUser.Email,
                            a.ListOrderTotal,
                            a.OrderTotal
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
                    OrderTotal = pfep.OrderTotal
                });
            }


            return View("OrderListReport1", result);

            //return View("Index", query.ToList());
        }

    }
}
