using Microsoft.AspNetCore.Mvc;

namespace OnionProject.UI.MVCCore.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class AdminController : Controller // panel controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
