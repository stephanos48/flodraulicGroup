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
    public class EcnLogController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EcnLogController(ApplicationDbContext db, IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {

            var query = from a in _db.EcnLogs
                        join b in _db.EcnLogStatuses on a.EcnLogStatusId equals b.EcnLogStatusId
                        join c in _db.EngineeringLogs on a.EngineeringLogId equals c.Id
                        orderby a.EcnLogStatusId
                        select new
                        {

                            a.Id,
                            a.DateCreated,
                            b.StatusName,
                            a.EngineeringLog.JobNumber,
                            a.CreatedBy,
                            a.Reason,
                            a.CostImpact,
                            a.ECNAddlEngHrs,
                            a.ECNAddlShopHrs,
                            a.PCNAddlEngHrs,
                            a.PCNAddlShopHrs,
                            a.EcnCompletionDate,
                            a.EcnRequestDate,
                            a.EngineeringLogId,
                            a.AffectPrice,
                            a.CustomerApprovalReq,
                            a.Notes
                            
                        };

            List<EcnLogVM1> result = new List<EcnLogVM1>();
            foreach (var pfep in query.ToList())
            {
                result.Add(new EcnLogVM1
                {

                    Id = pfep.Id,
                    EngineeringLogId = pfep.EngineeringLogId,
                    StatusName = pfep.StatusName,
                    JobNumber = pfep.JobNumber,
                    Reason = pfep.Reason,
                    CostImpact = pfep.CostImpact,
                    ECNAddlEngHrs = pfep.ECNAddlEngHrs,
                    ECNAddlShopHrs = pfep.ECNAddlShopHrs,
                    PCNAddlEngHrs = pfep.PCNAddlEngHrs,
                    PCNAddlShopHrs = pfep.PCNAddlShopHrs,
                    AffectPrice = pfep.AffectPrice,
                    Notes = pfep.Notes

                });
            }

            return View(result);
        }

        public IActionResult Upsert(int? id)
        {

            IEnumerable<SelectListItem> EcnLogStatusList = _unitOfWork.EcnLogStatus
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.StatusName,
                    Value = u.EcnLogStatusId.ToString()
                });

            IEnumerable<SelectListItem> EngLogList = _unitOfWork.EngineeringLog
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.QuoteNo,
                    Value = u.Id.ToString()
                });

            ViewBag.EcnLogStatusList = EcnLogStatusList;
            ViewBag.EngLogList = EngLogList.Distinct();
            //ViewData["CategoryList"] = CategoryList;
            EcnLogVM ecnLogVM = new EcnLogVM()
            {
                EcnLogStatusList = EcnLogStatusList,
                EngLogList = EngLogList,
                EcnLog = new EcnLog()
            };

            if (id == null || id == 0)
            {
                //create
                return View(ecnLogVM);
            }
            else
            {
                //update
                ecnLogVM.EcnLog = _unitOfWork.EcnLog.Get(u => u.Id == id, includeProperties:"EcnLogImages");
                return View(ecnLogVM);
            }

        }

        [HttpPost]
        public IActionResult Upsert(EcnLogVM ecnLogVM, List<IFormFile> files)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {

                if (ecnLogVM.EcnLog.Id == 0)
                {
                    _unitOfWork.EcnLog.Add(ecnLogVM.EcnLog);
                }
                else
                {
                    _unitOfWork.EcnLog.Update(ecnLogVM.EcnLog);
                }

                _unitOfWork.Save();

                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (files != null)
                {
                    foreach(IFormFile file in files)
                    {
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        string ecnLogPath = @"images\ecnlogs\ecnlog-" + ecnLogVM.EcnLog.Id;
                        string finalPath = Path.Combine(wwwRootPath, ecnLogPath);

                        if(!Directory.Exists(finalPath))
                            Directory.CreateDirectory(finalPath);

                        using (var fileStream = new FileStream(Path.Combine(finalPath, fileName), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }

                        EcnLogImage ecnLogImage = new()
                        {
                            ImageUrl = @"\" + ecnLogPath + @"\" + fileName,
                            EcnLogId=ecnLogVM.EcnLog.Id
                        };

                        if (ecnLogVM.EcnLog.EcnLogImages == null)
                            ecnLogVM.EcnLog.EcnLogImages = new List<EcnLogImage>();

                        ecnLogVM.EcnLog.EcnLogImages.Add(ecnLogImage);
                    }

                    _unitOfWork.EcnLog.Update(ecnLogVM.EcnLog);
                    _unitOfWork.Save();
                }

                //_db.Categories.Add(c);
                //_unitOfWork.Product.Add(productVM.Product);
                //_db.SaveChanges();

                TempData["success"] = "Ecn entry created/updated successfully";
                return RedirectToAction("Index");
            }
            else
            {
				IEnumerable<SelectListItem> EcnLogStatusList = _unitOfWork.EcnLogStatus
					.GetAll().Select(u => new SelectListItem
					{
						Text = u.StatusName,
						Value = u.EcnLogStatusId.ToString()
					});

				IEnumerable<SelectListItem> EngLogList = _unitOfWork.EngineeringLog
					.GetAll().Select(u => new SelectListItem
					{
						Text = u.QuoteNo,
						Value = u.Id.ToString()
					});

				return View(ecnLogVM);
            }
        }

        public IActionResult EcnLogComment(int id)
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            var name = _db.ApplicationUsers.Where(u => u.Id == userId).Select(w => w.Name);

            var query = from a in _db.EcnLogComments
                        join b in _db.ApplicationUsers on a.CreatedBy equals b.Id
                        where a.EcnLogId == id && a.CreatedBy == userId
                        select new
                        {

                            a.EcnLogId,
                            a.Id,
                            b.Name,
                            a.DateCreated,
                            a.CreatedBy,
                            a.Comment,
                            a.Notes

                        };
            
            ViewBag.EcnLogId = id;

            List<EcnLogCommentVM1> result = new List<EcnLogCommentVM1>();
            foreach (var comment in query.ToList())
            {
                result.Add(new EcnLogCommentVM1
                {
                    EcnLogId = id,
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

        public IActionResult UpsertEcnLogComment(int id, int? id2)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            var name = _db.ApplicationUsers.Where(u => u.Id == userId).Select(w => w.Name).FirstOrDefault();

            var ecnLogId = id;

            ViewBag.EngineeringLogId = id;

            IEnumerable<SelectListItem> EngLogList = _unitOfWork.EngineeringLog
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.JobNumber,
                    Value = u.Id.ToString()
                });

            //ViewData["CategoryList"] = CategoryList;
            EcnLogCommentVM ecnLogVM = new EcnLogCommentVM()
            {
                EngLogList = EngLogList,
                Name = name,
                EcnLogComment = new EcnLogComment()
            };

            //EngLogCommentVM engLogVM = new EngLogCommentVM();
            var count = _db.EcnLogComments.Where(x=>x.Id == id2).Count();

            if (count == null || count == 0)
            {
                //create
                ecnLogVM.EcnLogComment.CreatedBy = userId;
                ecnLogVM.EcnLogComment.DateCreated = DateTime.UtcNow;
                ecnLogVM.Name = name;
                ecnLogVM.EcnLogComment.EcnLogId = id;
                return View(ecnLogVM);
            }
            else
            {
                //update
                ecnLogVM.EcnLogComment = _unitOfWork.EcnLogComment.Get(u => u.Id == id2);
                //engLogVM.EngLogComment.EngineeringLog = _unitOfWork.EngineeringLog.Get(u => u.Id == engLogId);
                //engLogVM.EngLogComment.EngineeringLogId = engLogId;
                ecnLogVM.Name = name;
                ecnLogVM.EcnLogComment.ModifiedBy = userId;
                ecnLogVM.EcnLogComment.DateModified = DateTime.UtcNow;
                //engLogVM.EngLogComment.EngineeringLogId = id2;
                return View(ecnLogVM);
            }

        }

        [HttpPost]
        public IActionResult UpsertEcnLogComment(EcnLogCommentVM ecnLogVM)
        {

            var ecnlogid = ecnLogVM.EcnLogComment.EcnLogId;

            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {

                if (ecnLogVM.EcnLogComment.Id == 0)
                {
                    _unitOfWork.EcnLogComment.Add(ecnLogVM.EcnLogComment);
                }
                else
                {
                    _unitOfWork.EcnLogComment.Update(ecnLogVM.EcnLogComment);
                }

                //_db.Categories.Add(c);
                //_unitOfWork.Product.Add(productVM.Product);
                //_db.SaveChanges();
                _unitOfWork.Save();

                TempData["success"] = "Ecn comment created/updated successfully";
                return RedirectToAction("EcnLogComment", new { id = ecnlogid });
            }
            else
            {
                /*engLogVM.EngLogList = _unitOfWork.EngineeringLog.GetAll().Select(u => new SelectListItem
                {
                    Text = u.JobNumber,
                    Value = u.Id.ToString()
                });
                */

                return View(ecnLogVM);
            }
        }




    }
}
