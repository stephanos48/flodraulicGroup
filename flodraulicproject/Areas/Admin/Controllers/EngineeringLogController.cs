using flodraulicproject.DataAccess.Data;
using flodraulicproject.DataAccess.Repository.IRepository;
using flodraulicproject.Models.ViewModels;
using flodraulicproject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using SQLitePCL;

namespace flodraulicproject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EngineeringLogController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EngineeringLogController(ApplicationDbContext db, IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var query = from a in _db.EngineeringLogs
                        join b in _db.LogStatuses on a.LogStatusId equals b.LogStatusId
                        join c in _db.Estimators on a.EstimatorId equals c.Id
                        join d in _db.Engineers on a.EngineerId equals d.Id
                        join e in _db.MfgLocations on a.MfgLocationId equals e.Id
                        join f in _db.SalesLocations on a.SalesLocationId equals f.Id
                        orderby a.LogStatusId
                        select new
                        {
                            a.Id,
                            a.QuoteNo,
                            a.JobNumber,
                            a.Customer,
                            a.SystemDescription,
                            a.Qty,
                            f.SalesLocationName,
                            e.MfgLocationName,
                            c.EstimatorName,
                            d.EngineerName,
                            b.LogStatusName,
                            a.QuotedEngHrs,
                            a.Notes
                        };

            var query1 = from a in _db.TimeTrackers
                        join b in _db.Engineers on a.EngineerId equals b.Id
                        join c in _db.LaborCodes on a.LaborCodeId equals c.LaborCodeId
                        select new
                        {
                            Engineer = b.EngineerName,
                            JobNumber = a.JobNumber,
                            LaborCode = c.LaborCodeName,
                            HrsWorked = a.HrsWorked,
                            WorkDescription = a.WorkDescription
                        };

            var query2 = from a in query1
                         group a.HrsWorked by a.JobNumber into g
                         select new
                         {
                             g.Key,
                             HrsWorked = g.Sum()
                         };

            List < EngLogVM1 > result = new List<EngLogVM1>();
            foreach (var pfep in query.ToList())
            {
                result.Add(new EngLogVM1
                {
                    Id = pfep.Id,
                    JobNumber = pfep.JobNumber,
                    QuoteNo = pfep.QuoteNo,
                    Customer = pfep.Customer,
                    SystemDescription = pfep.SystemDescription,
                    Qty = pfep.Qty,
                    SalesLocationName = pfep.SalesLocationName,
                    MfgLocationName = pfep.MfgLocationName,
                    EstimatorName = pfep.EstimatorName,
                    EngineerName = pfep.EngineerName,
                    LogStatusName = pfep.LogStatusName,
                    QuotedEngHrs = pfep.QuotedEngHrs,
                    Notes = pfep.Notes
                });
            }

            var query3 = from a in result
                         join b in query2 on a.JobNumber equals b.Key
                         select new
                         {
                      
                             a.Id,
                             a.JobNumber,
                             a.QuoteNo,
                             a.Customer,
                             a.SystemDescription,
                             a.Qty,
                             a.SalesLocationName,
                             a.MfgLocationName,
                             a.EstimatorName,
                             a.EngineerName,
                             a.LogStatusName,
                             a.QuotedEngHrs,
                             ActualEngHrs = b.HrsWorked,
                             a.Notes
                                                         
                         };			

            List<EngLogVM1> result1 = new List<EngLogVM1>();
            foreach (var pfep in query3.ToList())
            {

                result1.Add(new EngLogVM1
                {

                    Id = pfep.Id,
                    JobNumber = pfep.JobNumber,
                    QuoteNo = pfep.QuoteNo,
                    Customer = pfep.Customer,
                    SystemDescription = pfep.SystemDescription,
                    Qty = pfep.Qty,
                    SalesLocationName = pfep.SalesLocationName,
                    MfgLocationName = pfep.MfgLocationName,
                    EstimatorName = pfep.EstimatorName,
                    EngineerName = pfep.EngineerName,
                    LogStatusName = pfep.LogStatusName,
                    QuotedEngHrs = pfep.QuotedEngHrs,
					ActualEngHrs = pfep.ActualEngHrs,
                    Notes = pfep.Notes,
	
				});

            }

            foreach (var a in result1)
			{

                if (a.QuotedEngHrs == null || a.JobNumber == "")
                {

					a.ActualEngHrs = null;

                }

            }



            /*foreach (var p in result)
            {
                foreach (var s in query2)
                {
                    if (p.JobNumber == s.Key)
                    {
                        p.ActualEngHrs = s.HrsWorked;
                    }
                }
            }*/

            return View(result1);
        }

        public IActionResult MilestoneMap(int? id)
        {

			MilestoneMapVM milestoneMapVM = new MilestoneMapVM();

            if (id == null || id == 0)
            {
				//create
                milestoneMapVM.EngineeringLog = _unitOfWork.EngineeringLog.Get(u => u.Id == id);
                var query = (from a in _db.EngineeringLogs.Where(u => u.Id == id)
                             join b in _db.SalesLocations on a.SalesLocationId equals b.Id
                             select new { a.SalesLocation.SalesLocationName }).Single();
                milestoneMapVM.SalesLocationName = query.SalesLocationName;
                return View(milestoneMapVM);
            }
            else
            {
                //update
                milestoneMapVM.EngineeringLog = _unitOfWork.EngineeringLog.Get(u => u.Id == id);
				var query = (from a in _db.EngineeringLogs.Where(u => u.Id == id)
							join b in _db.SalesLocations on a.SalesLocationId equals b.Id
							select new { a.SalesLocation.SalesLocationName}).Single();
				milestoneMapVM.SalesLocationName = query.SalesLocationName;
                return View(milestoneMapVM);
            }

        }

        public IActionResult InitialQuoteReview(int? id)
		{

            InitialQuoteReviewVM initialVM = new InitialQuoteReviewVM()
			{
				InitialQuoteReview = new InitialQuoteReview()
            };

            if (id == null || id == 0)
            {
                //create
                var query = (from a in _db.EngineeringLogs.Where(u => u.Id == id)
                             join b in _db.SalesLocations on a.SalesLocationId equals b.Id
                             select new { a.SalesLocation.SalesLocationName }).Single();
                initialVM.SalesLocationName = query.SalesLocationName;
                return View(initialVM);
            }
            else
            {
                //update
                initialVM.EngineeringLog = _unitOfWork.EngineeringLog.Get(u => u.Id == id);
                var query = (from a in _db.EngineeringLogs.Where(u => u.Id == id)
                             join b in _db.SalesLocations on a.SalesLocationId equals b.Id
                             select new { a.SalesLocation.SalesLocationName }).Single();
                initialVM.SalesLocationName = query.SalesLocationName;
                return View(initialVM);
            }

        }


        public IActionResult QuoteLog()
		{
			var query = from a in _db.EngineeringLogs
						join b in _db.LogStatuses on a.LogStatusId equals b.LogStatusId
						join c in _db.Estimators on a.EstimatorId equals c.Id
						join d in _db.Engineers on a.EngineerId equals d.Id
						join e in _db.MfgLocations on a.MfgLocationId equals e.Id
						join f in _db.SalesLocations on a.SalesLocationId equals f.Id
                        where b.LogStatusId == 1 || b.LogStatusId == 2 || b.LogStatusId == 3 || b.LogStatusId == 4
						orderby a.LogStatusId
						select new
						{
							a.Id,
							a.QuoteNo,
							a.JobNumber,
							a.Customer,
							a.SystemDescription,
							a.Qty,
							f.SalesLocationName,
							e.MfgLocationName,
							c.EstimatorName,
							d.EngineerName,
							b.LogStatusName,
							a.QuotedEngHrs,
							a.Notes
						};

			var query1 = from a in _db.TimeTrackers
						 join b in _db.Engineers on a.EngineerId equals b.Id
						 join c in _db.LaborCodes on a.LaborCodeId equals c.LaborCodeId
						 select new
						 {
							 Engineer = b.EngineerName,
							 JobNumber = a.JobNumber,
							 LaborCode = c.LaborCodeName,
							 HrsWorked = a.HrsWorked,
							 WorkDescription = a.WorkDescription
						 };

			var query2 = from a in query1
						 group a.HrsWorked by a.JobNumber into g
						 select new
						 {
							 g.Key,
							 HrsWorked = g.Sum()
						 };

			List<EngLogVM1> result = new List<EngLogVM1>();
			foreach (var pfep in query.ToList())
			{
				result.Add(new EngLogVM1
				{
					Id = pfep.Id,
					JobNumber = pfep.JobNumber,
					QuoteNo = pfep.QuoteNo,
					Customer = pfep.Customer,
					SystemDescription = pfep.SystemDescription,
					Qty = pfep.Qty,
					SalesLocationName = pfep.SalesLocationName,
					MfgLocationName = pfep.MfgLocationName,
					EstimatorName = pfep.EstimatorName,
					EngineerName = pfep.EngineerName,
					LogStatusName = pfep.LogStatusName,
					QuotedEngHrs = pfep.QuotedEngHrs,
					Notes = pfep.Notes
				});
			}

			var query3 = from a in result
						 join b in query2 on a.JobNumber equals b.Key
						 select new
						 {

							 a.Id,
							 a.JobNumber,
							 a.QuoteNo,
							 a.Customer,
							 a.SystemDescription,
							 a.Qty,
							 a.SalesLocationName,
							 a.MfgLocationName,
							 a.EstimatorName,
							 a.EngineerName,
							 a.LogStatusName,
							 a.QuotedEngHrs,
							 ActualEngHrs = b.HrsWorked,
							 a.Notes

						 };

			List<EngLogVM1> result1 = new List<EngLogVM1>();
			foreach (var pfep in query3.ToList())
			{

				result1.Add(new EngLogVM1
				{
					Id = pfep.Id,
					JobNumber = pfep.JobNumber,
					QuoteNo = pfep.QuoteNo,
					Customer = pfep.Customer,
					SystemDescription = pfep.SystemDescription,
					Qty = pfep.Qty,
					SalesLocationName = pfep.SalesLocationName,
					MfgLocationName = pfep.MfgLocationName,
					EstimatorName = pfep.EstimatorName,
					EngineerName = pfep.EngineerName,
					LogStatusName = pfep.LogStatusName,
					QuotedEngHrs = pfep.QuotedEngHrs,
					ActualEngHrs = pfep.ActualEngHrs,
					Notes = pfep.Notes
				});

			}

            foreach (var a in result1)
            {

                if (a.QuotedEngHrs == null || a.JobNumber == "")
                {

                    a.ActualEngHrs = null;

                }

            }

            /*foreach (var p in result)
            {
                foreach (var s in query2)
                {
                    if (p.JobNumber == s.Key)
                    {
                        p.ActualEngHrs = s.HrsWorked;
                    }
                }
            }*/

            return View("Index", result1);
		}

		public IActionResult AwaitingDecision()
		{
			var query = from a in _db.EngineeringLogs
						join b in _db.LogStatuses on a.LogStatusId equals b.LogStatusId
						join c in _db.Estimators on a.EstimatorId equals c.Id
						join d in _db.Engineers on a.EngineerId equals d.Id
						join e in _db.MfgLocations on a.MfgLocationId equals e.Id
						join f in _db.SalesLocations on a.SalesLocationId equals f.Id
						where b.LogStatusId == 5
						orderby a.LogStatusId
						select new
						{
							a.Id,
							a.QuoteNo,
							a.JobNumber,
							a.Customer,
							a.SystemDescription,
							a.Qty,
							f.SalesLocationName,
							e.MfgLocationName,
							c.EstimatorName,
							d.EngineerName,
							b.LogStatusName,
							a.QuotedEngHrs,
							a.Notes
						};

			var query1 = from a in _db.TimeTrackers
						 join b in _db.Engineers on a.EngineerId equals b.Id
						 join c in _db.LaborCodes on a.LaborCodeId equals c.LaborCodeId
						 select new
						 {
							 Engineer = b.EngineerName,
							 JobNumber = a.JobNumber,
							 LaborCode = c.LaborCodeName,
							 HrsWorked = a.HrsWorked,
							 WorkDescription = a.WorkDescription
						 };

			var query2 = from a in query1
						 group a.HrsWorked by a.JobNumber into g
						 select new
						 {
							 g.Key,
							 HrsWorked = g.Sum()
						 };

			List<EngLogVM1> result = new List<EngLogVM1>();
			foreach (var pfep in query.ToList())
			{
				result.Add(new EngLogVM1
				{
					Id = pfep.Id,
					JobNumber = pfep.JobNumber,
					QuoteNo = pfep.QuoteNo,
					Customer = pfep.Customer,
					SystemDescription = pfep.SystemDescription,
					Qty = pfep.Qty,
					SalesLocationName = pfep.SalesLocationName,
					MfgLocationName = pfep.MfgLocationName,
					EstimatorName = pfep.EstimatorName,
					EngineerName = pfep.EngineerName,
					LogStatusName = pfep.LogStatusName,
					QuotedEngHrs = pfep.QuotedEngHrs,
					Notes = pfep.Notes
				});
			}

			var query3 = from a in result
						 join b in query2 on a.JobNumber equals b.Key
						 select new
						 {

							 a.Id,
							 a.JobNumber,
							 a.QuoteNo,
							 a.Customer,
							 a.SystemDescription,
							 a.Qty,
							 a.SalesLocationName,
							 a.MfgLocationName,
							 a.EstimatorName,
							 a.EngineerName,
							 a.LogStatusName,
							 a.QuotedEngHrs,
							 ActualEngHrs = b.HrsWorked,
							 a.Notes

						 };

			List<EngLogVM1> result1 = new List<EngLogVM1>();
			foreach (var pfep in query3.ToList())
			{

				result1.Add(new EngLogVM1
				{
					Id = pfep.Id,
					JobNumber = pfep.JobNumber,
					QuoteNo = pfep.QuoteNo,
					Customer = pfep.Customer,
					SystemDescription = pfep.SystemDescription,
					Qty = pfep.Qty,
					SalesLocationName = pfep.SalesLocationName,
					MfgLocationName = pfep.MfgLocationName,
					EstimatorName = pfep.EstimatorName,
					EngineerName = pfep.EngineerName,
					LogStatusName = pfep.LogStatusName,
					QuotedEngHrs = pfep.QuotedEngHrs,
					ActualEngHrs = pfep.ActualEngHrs,
					Notes = pfep.Notes
				});

			}

            foreach (var a in result1)
            {

                if (a.QuotedEngHrs == null || a.JobNumber == "")
                {

                    a.ActualEngHrs = null;

                }

            }

            /*foreach (var p in result)
            {
                foreach (var s in query2)
                {
                    if (p.JobNumber == s.Key)
                    {
                        p.ActualEngHrs = s.HrsWorked;
                    }
                }
            }*/

            return View("Index", result1);
		}

		public IActionResult EngLog()
		{
			var query = from a in _db.EngineeringLogs
						join b in _db.LogStatuses on a.LogStatusId equals b.LogStatusId
						join c in _db.Estimators on a.EstimatorId equals c.Id
						join d in _db.Engineers on a.EngineerId equals d.Id
						join e in _db.MfgLocations on a.MfgLocationId equals e.Id
						join f in _db.SalesLocations on a.SalesLocationId equals f.Id
						where b.LogStatusId == 6 || b.LogStatusId == 7 || b.LogStatusId == 8 || b.LogStatusId == 9 || b.LogStatusId == 10 || b.LogStatusId == 11 || b.LogStatusId == 12
						orderby a.LogStatusId
						select new
						{
							a.Id,
							a.QuoteNo,
							a.JobNumber,
							a.Customer,
							a.SystemDescription,
							a.Qty,
							f.SalesLocationName,
							e.MfgLocationName,
							c.EstimatorName,
							d.EngineerName,
							b.LogStatusName,
							a.QuotedEngHrs,
							a.Notes
						};

			var query1 = from a in _db.TimeTrackers
						 join b in _db.Engineers on a.EngineerId equals b.Id
						 join c in _db.LaborCodes on a.LaborCodeId equals c.LaborCodeId
						 select new
						 {
							 Engineer = b.EngineerName,
							 JobNumber = a.JobNumber,
							 LaborCode = c.LaborCodeName,
							 HrsWorked = a.HrsWorked,
							 WorkDescription = a.WorkDescription
						 };

			var query2 = from a in query1
						 group a.HrsWorked by a.JobNumber into g
						 select new
						 {
							 g.Key,
							 HrsWorked = g.Sum()
						 };

			List<EngLogVM1> result = new List<EngLogVM1>();
			foreach (var pfep in query.ToList())
			{
				result.Add(new EngLogVM1
				{
					Id = pfep.Id,
					JobNumber = pfep.JobNumber,
					QuoteNo = pfep.QuoteNo,
					Customer = pfep.Customer,
					SystemDescription = pfep.SystemDescription,
					Qty = pfep.Qty,
					SalesLocationName = pfep.SalesLocationName,
					MfgLocationName = pfep.MfgLocationName,
					EstimatorName = pfep.EstimatorName,
					EngineerName = pfep.EngineerName,
					LogStatusName = pfep.LogStatusName,
					QuotedEngHrs = pfep.QuotedEngHrs,
					Notes = pfep.Notes
				});
			}

			var query3 = from a in result
						 join b in query2 on a.JobNumber equals b.Key
						 select new
						 {

							 a.Id,
							 a.JobNumber,
							 a.QuoteNo,
							 a.Customer,
							 a.SystemDescription,
							 a.Qty,
							 a.SalesLocationName,
							 a.MfgLocationName,
							 a.EstimatorName,
							 a.EngineerName,
							 a.LogStatusName,
							 a.QuotedEngHrs,
							 ActualEngHrs = b.HrsWorked,
							 a.Notes

						 };

			List<EngLogVM1> result1 = new List<EngLogVM1>();
			foreach (var pfep in query3.ToList())
			{

				result1.Add(new EngLogVM1
				{
					Id = pfep.Id,
					JobNumber = pfep.JobNumber,
					QuoteNo = pfep.QuoteNo,
					Customer = pfep.Customer,
					SystemDescription = pfep.SystemDescription,
					Qty = pfep.Qty,
					SalesLocationName = pfep.SalesLocationName,
					MfgLocationName = pfep.MfgLocationName,
					EstimatorName = pfep.EstimatorName,
					EngineerName = pfep.EngineerName,
					LogStatusName = pfep.LogStatusName,
					QuotedEngHrs = pfep.QuotedEngHrs,
					ActualEngHrs = pfep.ActualEngHrs,
					Notes = pfep.Notes
				});

			}

            foreach (var a in result1)
            {

                if (a.QuotedEngHrs == null || a.JobNumber == "")
                {

                    a.ActualEngHrs = null;

                }

            }

            /*foreach (var p in result)
            {
                foreach (var s in query2)
                {
                    if (p.JobNumber == s.Key)
                    {
                        p.ActualEngHrs = s.HrsWorked;
                    }
                }
            }*/

            return View("Index", result1);
		}

		public IActionResult Assembly()
		{
			var query = from a in _db.EngineeringLogs
						join b in _db.LogStatuses on a.LogStatusId equals b.LogStatusId
						join c in _db.Estimators on a.EstimatorId equals c.Id
						join d in _db.Engineers on a.EngineerId equals d.Id
						join e in _db.MfgLocations on a.MfgLocationId equals e.Id
						join f in _db.SalesLocations on a.SalesLocationId equals f.Id
						where b.LogStatusId == 13 || b.LogStatusId == 14 || b.LogStatusId == 15
						orderby a.LogStatusId
						select new
						{
							a.Id,
							a.QuoteNo,
							a.JobNumber,
							a.Customer,
							a.SystemDescription,
							a.Qty,
							f.SalesLocationName,
							e.MfgLocationName,
							c.EstimatorName,
							d.EngineerName,
							b.LogStatusName,
							a.QuotedEngHrs,
							a.Notes
						};

			var query1 = from a in _db.TimeTrackers
						 join b in _db.Engineers on a.EngineerId equals b.Id
						 join c in _db.LaborCodes on a.LaborCodeId equals c.LaborCodeId
						 select new
						 {
							 Engineer = b.EngineerName,
							 JobNumber = a.JobNumber,
							 LaborCode = c.LaborCodeName,
							 HrsWorked = a.HrsWorked,
							 WorkDescription = a.WorkDescription
						 };

			var query2 = from a in query1
						 group a.HrsWorked by a.JobNumber into g
						 select new
						 {
							 g.Key,
							 HrsWorked = g.Sum()
						 };

			List<EngLogVM1> result = new List<EngLogVM1>();
			foreach (var pfep in query.ToList())
			{
				result.Add(new EngLogVM1
				{
					Id = pfep.Id,
					JobNumber = pfep.JobNumber,
					QuoteNo = pfep.QuoteNo,
					Customer = pfep.Customer,
					SystemDescription = pfep.SystemDescription,
					Qty = pfep.Qty,
					SalesLocationName = pfep.SalesLocationName,
					MfgLocationName = pfep.MfgLocationName,
					EstimatorName = pfep.EstimatorName,
					EngineerName = pfep.EngineerName,
					LogStatusName = pfep.LogStatusName,
					QuotedEngHrs = pfep.QuotedEngHrs,
					Notes = pfep.Notes
				});
			}

			var query3 = from a in result
						 join b in query2 on a.JobNumber equals b.Key
						 select new
						 {

							 a.Id,
							 a.JobNumber,
							 a.QuoteNo,
							 a.Customer,
							 a.SystemDescription,
							 a.Qty,
							 a.SalesLocationName,
							 a.MfgLocationName,
							 a.EstimatorName,
							 a.EngineerName,
							 a.LogStatusName,
							 a.QuotedEngHrs,
							 ActualEngHrs = b.HrsWorked,
							 a.Notes

						 };

			List<EngLogVM1> result1 = new List<EngLogVM1>();
			foreach (var pfep in query3.ToList())
			{

				result1.Add(new EngLogVM1
				{
					Id = pfep.Id,
					JobNumber = pfep.JobNumber,
					QuoteNo = pfep.QuoteNo,
					Customer = pfep.Customer,
					SystemDescription = pfep.SystemDescription,
					Qty = pfep.Qty,
					SalesLocationName = pfep.SalesLocationName,
					MfgLocationName = pfep.MfgLocationName,
					EstimatorName = pfep.EstimatorName,
					EngineerName = pfep.EngineerName,
					LogStatusName = pfep.LogStatusName,
					QuotedEngHrs = pfep.QuotedEngHrs,
					ActualEngHrs = pfep.ActualEngHrs,
					Notes = pfep.Notes
				});

			}

            foreach (var a in result1)
            {

                if (a.QuotedEngHrs == null || a.JobNumber == "")
                {

                    a.ActualEngHrs = null;

                }

            }

            /*foreach (var p in result)
            {
                foreach (var s in query2)
                {
                    if (p.JobNumber == s.Key)
                    {
                        p.ActualEngHrs = s.HrsWorked;
                    }
                }
            }*/

            return View("Index", result1);
		}

		public IActionResult CompletedProjects()
		{
			var query = from a in _db.EngineeringLogs
						join b in _db.LogStatuses on a.LogStatusId equals b.LogStatusId
						join c in _db.Estimators on a.EstimatorId equals c.Id
						join d in _db.Engineers on a.EngineerId equals d.Id
						join e in _db.MfgLocations on a.MfgLocationId equals e.Id
						join f in _db.SalesLocations on a.SalesLocationId equals f.Id
						where b.LogStatusId == 16
						orderby a.LogStatusId
						select new
						{
							a.Id,
							a.QuoteNo,
							a.JobNumber,
							a.Customer,
							a.SystemDescription,
							a.Qty,
							f.SalesLocationName,
							e.MfgLocationName,
							c.EstimatorName,
							d.EngineerName,
							b.LogStatusName,
							a.QuotedEngHrs,
							a.Notes
						};

			var query1 = from a in _db.TimeTrackers
						 join b in _db.Engineers on a.EngineerId equals b.Id
						 join c in _db.LaborCodes on a.LaborCodeId equals c.LaborCodeId
						 select new
						 {
							 Engineer = b.EngineerName,
							 JobNumber = a.JobNumber,
							 LaborCode = c.LaborCodeName,
							 HrsWorked = a.HrsWorked,
							 WorkDescription = a.WorkDescription
						 };

			var query2 = from a in query1
						 group a.HrsWorked by a.JobNumber into g
						 select new
						 {
							 g.Key,
							 HrsWorked = g.Sum()
						 };

			List<EngLogVM1> result = new List<EngLogVM1>();
			foreach (var pfep in query.ToList())
			{
				result.Add(new EngLogVM1
				{
					Id = pfep.Id,
					JobNumber = pfep.JobNumber,
					QuoteNo = pfep.QuoteNo,
					Customer = pfep.Customer,
					SystemDescription = pfep.SystemDescription,
					Qty = pfep.Qty,
					SalesLocationName = pfep.SalesLocationName,
					MfgLocationName = pfep.MfgLocationName,
					EstimatorName = pfep.EstimatorName,
					EngineerName = pfep.EngineerName,
					LogStatusName = pfep.LogStatusName,
					QuotedEngHrs = pfep.QuotedEngHrs,
					Notes = pfep.Notes
				});
			}

			var query3 = from a in result
						 join b in query2 on a.JobNumber equals b.Key
						 select new
						 {

							 a.Id,
							 a.JobNumber,
							 a.QuoteNo,
							 a.Customer,
							 a.SystemDescription,
							 a.Qty,
							 a.SalesLocationName,
							 a.MfgLocationName,
							 a.EstimatorName,
							 a.EngineerName,
							 a.LogStatusName,
							 a.QuotedEngHrs,
							 ActualEngHrs = b.HrsWorked,
							 a.Notes

						 };

			List<EngLogVM1> result1 = new List<EngLogVM1>();
			foreach (var pfep in query3.ToList())
			{

				result1.Add(new EngLogVM1
				{
					Id = pfep.Id,
					JobNumber = pfep.JobNumber,
					QuoteNo = pfep.QuoteNo,
					Customer = pfep.Customer,
					SystemDescription = pfep.SystemDescription,
					Qty = pfep.Qty,
					SalesLocationName = pfep.SalesLocationName,
					MfgLocationName = pfep.MfgLocationName,
					EstimatorName = pfep.EstimatorName,
					EngineerName = pfep.EngineerName,
					LogStatusName = pfep.LogStatusName,
					QuotedEngHrs = pfep.QuotedEngHrs,
					ActualEngHrs = pfep.ActualEngHrs,
					Notes = pfep.Notes
				});

			}

            foreach (var a in result1)
            {

                if (a.QuotedEngHrs == null || a.JobNumber == "")
                {

                    a.ActualEngHrs = null;

                }

            }

            /*foreach (var p in result)
            {
                foreach (var s in query2)
                {
                    if (p.JobNumber == s.Key)
                    {
                        p.ActualEngHrs = s.HrsWorked;
                    }
                }
            }*/

            return View("Index", result1);
		}

		public IActionResult NoQuoteArchiveProjects()
		{
			var query = from a in _db.EngineeringLogs
						join b in _db.LogStatuses on a.LogStatusId equals b.LogStatusId
						join c in _db.Estimators on a.EstimatorId equals c.Id
						join d in _db.Engineers on a.EngineerId equals d.Id
						join e in _db.MfgLocations on a.MfgLocationId equals e.Id
						join f in _db.SalesLocations on a.SalesLocationId equals f.Id
						where b.LogStatusId == 17
						orderby a.LogStatusId
						select new
						{
							a.Id,
							a.QuoteNo,
							a.JobNumber,
							a.Customer,
							a.SystemDescription,
							a.Qty,
							f.SalesLocationName,
							e.MfgLocationName,
							c.EstimatorName,
							d.EngineerName,
							b.LogStatusName,
							a.QuotedEngHrs,
							a.Notes
						};

			var query1 = from a in _db.TimeTrackers
						 join b in _db.Engineers on a.EngineerId equals b.Id
						 join c in _db.LaborCodes on a.LaborCodeId equals c.LaborCodeId
						 select new
						 {
							 Engineer = b.EngineerName,
							 JobNumber = a.JobNumber,
							 LaborCode = c.LaborCodeName,
							 HrsWorked = a.HrsWorked,
							 WorkDescription = a.WorkDescription
						 };

			var query2 = from a in query1
						 group a.HrsWorked by a.JobNumber into g
						 select new
						 {
							 g.Key,
							 HrsWorked = g.Sum()
						 };

			List<EngLogVM1> result = new List<EngLogVM1>();
			foreach (var pfep in query.ToList())
			{
				result.Add(new EngLogVM1
				{
					Id = pfep.Id,
					JobNumber = pfep.JobNumber,
					QuoteNo = pfep.QuoteNo,
					Customer = pfep.Customer,
					SystemDescription = pfep.SystemDescription,
					Qty = pfep.Qty,
					SalesLocationName = pfep.SalesLocationName,
					MfgLocationName = pfep.MfgLocationName,
					EstimatorName = pfep.EstimatorName,
					EngineerName = pfep.EngineerName,
					LogStatusName = pfep.LogStatusName,
					QuotedEngHrs = pfep.QuotedEngHrs,
					Notes = pfep.Notes
				});
			}

			var query3 = from a in result
						 join b in query2 on a.JobNumber equals b.Key
						 select new
						 {

							 a.Id,
							 a.JobNumber,
							 a.QuoteNo,
							 a.Customer,
							 a.SystemDescription,
							 a.Qty,
							 a.SalesLocationName,
							 a.MfgLocationName,
							 a.EstimatorName,
							 a.EngineerName,
							 a.LogStatusName,
							 a.QuotedEngHrs,
							 ActualEngHrs = b.HrsWorked,
							 a.Notes

						 };

			List<EngLogVM1> result1 = new List<EngLogVM1>();
			foreach (var pfep in query3.ToList())
			{

				result1.Add(new EngLogVM1
				{
					Id = pfep.Id,
					JobNumber = pfep.JobNumber,
					QuoteNo = pfep.QuoteNo,
					Customer = pfep.Customer,
					SystemDescription = pfep.SystemDescription,
					Qty = pfep.Qty,
					SalesLocationName = pfep.SalesLocationName,
					MfgLocationName = pfep.MfgLocationName,
					EstimatorName = pfep.EstimatorName,
					EngineerName = pfep.EngineerName,
					LogStatusName = pfep.LogStatusName,
					QuotedEngHrs = pfep.QuotedEngHrs,
					ActualEngHrs = pfep.ActualEngHrs,
					Notes = pfep.Notes
				});

			}

            foreach (var a in result1)
            {

                if (a.QuotedEngHrs == null || a.JobNumber == "")
                {

                    a.ActualEngHrs = null;

                }

            }

            /*foreach (var p in result)
            {
                foreach (var s in query2)
                {
                    if (p.JobNumber == s.Key)
                    {
                        p.ActualEngHrs = s.HrsWorked;
                    }
                }
            }*/

            return View("Index", result1);
		}

		public IActionResult ProjectsOnHold()
		{
			var query = from a in _db.EngineeringLogs
						join b in _db.LogStatuses on a.LogStatusId equals b.LogStatusId
						join c in _db.Estimators on a.EstimatorId equals c.Id
						join d in _db.Engineers on a.EngineerId equals d.Id
						join e in _db.MfgLocations on a.MfgLocationId equals e.Id
						join f in _db.SalesLocations on a.SalesLocationId equals f.Id
						where b.LogStatusId == 18
						orderby a.LogStatusId
						select new
						{
							a.Id,
							a.QuoteNo,
							a.JobNumber,
							a.Customer,
							a.SystemDescription,
							a.Qty,
							f.SalesLocationName,
							e.MfgLocationName,
							c.EstimatorName,
							d.EngineerName,
							b.LogStatusName,
							a.QuotedEngHrs,
							a.Notes
						};

			var query1 = from a in _db.TimeTrackers
						 join b in _db.Engineers on a.EngineerId equals b.Id
						 join c in _db.LaborCodes on a.LaborCodeId equals c.LaborCodeId
						 select new
						 {
							 Engineer = b.EngineerName,
							 JobNumber = a.JobNumber,
							 LaborCode = c.LaborCodeName,
							 HrsWorked = a.HrsWorked,
							 WorkDescription = a.WorkDescription
						 };

			var query2 = from a in query1
						 group a.HrsWorked by a.JobNumber into g
						 select new
						 {
							 g.Key,
							 HrsWorked = g.Sum()
						 };

			List<EngLogVM1> result = new List<EngLogVM1>();
			foreach (var pfep in query.ToList())
			{
				result.Add(new EngLogVM1
				{
					Id = pfep.Id,
					JobNumber = pfep.JobNumber,
					QuoteNo = pfep.QuoteNo,
					Customer = pfep.Customer,
					SystemDescription = pfep.SystemDescription,
					Qty = pfep.Qty,
					SalesLocationName = pfep.SalesLocationName,
					MfgLocationName = pfep.MfgLocationName,
					EstimatorName = pfep.EstimatorName,
					EngineerName = pfep.EngineerName,
					LogStatusName = pfep.LogStatusName,
					QuotedEngHrs = pfep.QuotedEngHrs,
					Notes = pfep.Notes
				});
			}

			var query3 = from a in result
						 join b in query2 on a.JobNumber equals b.Key
						 select new
						 {

							 a.Id,
							 a.JobNumber,
							 a.QuoteNo,
							 a.Customer,
							 a.SystemDescription,
							 a.Qty,
							 a.SalesLocationName,
							 a.MfgLocationName,
							 a.EstimatorName,
							 a.EngineerName,
							 a.LogStatusName,
							 a.QuotedEngHrs,
							 ActualEngHrs = b.HrsWorked,
							 a.Notes

						 };

			List<EngLogVM1> result1 = new List<EngLogVM1>();
			foreach (var pfep in query3.ToList())
			{

				result1.Add(new EngLogVM1
				{
					Id = pfep.Id,
					JobNumber = pfep.JobNumber,
					QuoteNo = pfep.QuoteNo,
					Customer = pfep.Customer,
					SystemDescription = pfep.SystemDescription,
					Qty = pfep.Qty,
					SalesLocationName = pfep.SalesLocationName,
					MfgLocationName = pfep.MfgLocationName,
					EstimatorName = pfep.EstimatorName,
					EngineerName = pfep.EngineerName,
					LogStatusName = pfep.LogStatusName,
					QuotedEngHrs = pfep.QuotedEngHrs,
					ActualEngHrs = pfep.ActualEngHrs,
					Notes = pfep.Notes
				});

			}

            foreach (var a in result1)
            {

                if (a.QuotedEngHrs == null || a.JobNumber == "")
                {

                    a.ActualEngHrs = null;

                }

            }

            /*foreach (var p in result)
            {
                foreach (var s in query2)
                {
                    if (p.JobNumber == s.Key)
                    {
                        p.ActualEngHrs = s.HrsWorked;
                    }
                }
            }*/

            return View("Index", result1);
		}

		public IActionResult Upsert(int? id)
        {
            IEnumerable<SelectListItem> EngineerList = _unitOfWork.Engineer
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.EngineerName,
                    Value = u.Id.ToString()
                });

            IEnumerable<SelectListItem> EstimatorList = _unitOfWork.Estimator
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.EstimatorName,
                    Value = u.Id.ToString()
                });

            IEnumerable<SelectListItem> LogStatusList = _unitOfWork.LogStatus
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.LogStatusName,
                    Value = u.LogStatusId.ToString()
                });

            IEnumerable<SelectListItem> MfgLocationList = _unitOfWork.MfgLocation
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.MfgLocationName,
                    Value = u.Id.ToString()
                });

            IEnumerable<SelectListItem> SalesLocationList = _unitOfWork.SalesLocation
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.SalesLocationName,
                    Value = u.Id.ToString()
                });

            ViewBag.EngineerList = EngineerList;
            ViewBag.EstimatorList = EstimatorList;
            ViewBag.LogStatusList = LogStatusList;
            ViewBag.MfgLocationList = MfgLocationList;
            ViewBag.SalesLocationList = SalesLocationList;
            //ViewData["CategoryList"] = CategoryList;
            EngineeringLogVM engLogVM = new EngineeringLogVM()
            {
                EngineerList = EngineerList,
                EstimatorList = EstimatorList,
                LogStatusList = LogStatusList,
                MfgLocationList = MfgLocationList,
                SalesLocationList = SalesLocationList,
                EngineeringLog = new EngineeringLog()
            };

            if (id == null || id == 0)
            {
                //create
                return View(engLogVM);
            }
            else
            {
                //update
                engLogVM.EngineeringLog = _unitOfWork.EngineeringLog.Get(u => u.Id == id);
                return View(engLogVM);
            }

        }

        [HttpPost]
        public IActionResult Upsert(EngineeringLogVM engLogVM)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {

                if (engLogVM.EngineeringLog.Id == 0)
                {
                    _unitOfWork.EngineeringLog.Add(engLogVM.EngineeringLog);
                }
                else
                {
                    _unitOfWork.EngineeringLog.Update(engLogVM.EngineeringLog);
                }

                //_db.Categories.Add(c);
                //_unitOfWork.Product.Add(productVM.Product);
                //_db.SaveChanges();
                _unitOfWork.Save();
                TempData["success"] = "Time entry created successfully";
                return RedirectToAction("Index", "EngineeringLog");
            }
            else
            {
                engLogVM.MfgLocationList = _unitOfWork.MfgLocation.GetAll().Select(u => new SelectListItem
                {
                    Text = u.MfgLocationName,
                    Value = u.Id.ToString()
                });

                engLogVM.SalesLocationList = _unitOfWork.SalesLocation.GetAll().Select(u => new SelectListItem
                {
                    Text = u.SalesLocationName,
                    Value = u.Id.ToString()
                });

                engLogVM.EngineerList = _unitOfWork.Engineer.GetAll().Select(u => new SelectListItem
                {
                    Text = u.EngineerName,
                    Value = u.Id.ToString()
                });

                engLogVM.EstimatorList = _unitOfWork.Estimator.GetAll().Select(u => new SelectListItem
                {
                    Text = u.EstimatorName,
                    Value = u.Id.ToString()
                });

                engLogVM.LogStatusList = _unitOfWork.LogStatus.GetAll().Select(u => new SelectListItem
                {
                    Text = u.LogStatusName,
                    Value = u.LogStatusId.ToString()
                });

                return View(engLogVM);
            }
        }

        public IActionResult EngLogComment(int id)
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            var name = _db.ApplicationUsers.Where(u => u.Id == userId).Select(w => w.Name);

            var query = from a in _db.EngLogComments
                        join b in _db.ApplicationUsers on a.CreatedBy equals b.Id
                        where a.EngineeringLogId == id && a.CreatedBy == userId
                        select new
                        {

                            a.EngineeringLogId,
                            a.Id,
                            b.Name,
                            a.DateCreated,
                            a.CreatedBy,
                            a.Comment,
                            a.Notes

                        };
            
            ViewBag.EngineeringLogId = id;

            List<EngLogCommentVM1> result = new List<EngLogCommentVM1>();
            foreach (var comment in query.ToList())
            {
                result.Add(new EngLogCommentVM1
                {
                    EngineeringLogId = id,
                    Id = comment.Id,
                    Name = comment.Name,
                    CreatedBy = comment.CreatedBy,
                    DateCreated = comment.DateCreated,
                    Comment = comment.Comment,
                    Notes = comment.Notes

                });
            }

            return View(result);
        }

        public IActionResult UpsertEngLogComment(int id, int? id2)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            var name = _db.ApplicationUsers.Where(u => u.Id == userId).Select(w => w.Name).FirstOrDefault();

            var engLogId = id;

            ViewBag.EngineeringLogId = id;

            IEnumerable<SelectListItem> EngLogList = _unitOfWork.EngineeringLog
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.JobNumber,
                    Value = u.Id.ToString()
                });

            //ViewData["CategoryList"] = CategoryList;
            EngLogCommentVM engLogVM = new EngLogCommentVM()
            {
                EngLogList = EngLogList,
                Name = name,
                EngLogComment = new EngLogComment()
            };

            //EngLogCommentVM engLogVM = new EngLogCommentVM();
            var count = _db.EngLogComments.Where(x=>x.Id == id2).Count();

            if (count == null || count == 0)
            {
                //create
                engLogVM.EngLogComment.CreatedBy = userId;
                engLogVM.EngLogComment.DateCreated = DateTime.UtcNow;
                engLogVM.Name = name;
                engLogVM.EngLogComment.EngineeringLogId = id;
                return View(engLogVM);
            }
            else
            {
                //update
                engLogVM.EngLogComment = _unitOfWork.EngLogComment.Get(u => u.Id == id2);
                //engLogVM.EngLogComment.EngineeringLog = _unitOfWork.EngineeringLog.Get(u => u.Id == engLogId);
                //engLogVM.EngLogComment.EngineeringLogId = engLogId;
                engLogVM.Name = name;
                engLogVM.EngLogComment.ModifiedBy = userId;
                engLogVM.EngLogComment.DateModified = DateTime.UtcNow;
                //engLogVM.EngLogComment.EngineeringLogId = id2;
                return View(engLogVM);
            }

        }

        [HttpPost]
        public IActionResult UpsertEngLogComment(EngLogCommentVM engLogVM)
        {

            var englogid = engLogVM.EngLogComment.EngineeringLogId;

            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {

                if (engLogVM.EngLogComment.Id == 0)
                {
                    _unitOfWork.EngLogComment.Add(engLogVM.EngLogComment);
                }
                else
                {
                    _unitOfWork.EngLogComment.Update(engLogVM.EngLogComment);
                }

                //_db.Categories.Add(c);
                //_unitOfWork.Product.Add(productVM.Product);
                //_db.SaveChanges();
                _unitOfWork.Save();

                TempData["success"] = "Eng comment created/updated successfully";
                return RedirectToAction("EngLogComment", new { id = englogid });
            }
            else
            {
                /*engLogVM.EngLogList = _unitOfWork.EngineeringLog.GetAll().Select(u => new SelectListItem
                {
                    Text = u.JobNumber,
                    Value = u.Id.ToString()
                });
                */

                return View(engLogVM);
            }
        }




    }
}
