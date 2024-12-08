using Microsoft.AspNetCore.Mvc;

namespace flodraulicproject.Areas.Admin.Controllers
{
    public class StatusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
