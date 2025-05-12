using Microsoft.AspNetCore.Mvc;

namespace OnionProject.UI.MVCCore.Areas.UyeArea.Controllers
{
    [Area("UyeArea")]
    public class UyeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
