using Microsoft.AspNetCore.Mvc;
using OnionProject.Application.Layer.Services.Urunler;
using OnionProject.UI.MVCCore.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace OnionProject.UI.MVCCore.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly IUrunService urunService;
        public HomeController(IUrunService _urunService)
        {
            urunService = _urunService;
        }

        public async Task<IActionResult> Index()
        {
            var urunler = await urunService.UrunleriListeleAsync();
            return View();
        }

        public async Task<IActionResult> Detay(int urunId)
        {
            var urun = await urunService.UyeyeUrunBulAsync(urunId);
            return View(urun);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
