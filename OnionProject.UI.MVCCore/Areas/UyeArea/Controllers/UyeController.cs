using Microsoft.AspNetCore.Mvc;
using OnionProject.Application.Layer.Models.DTOs.Sepetler;
using OnionProject.Application.Layer.Services.Login;
using OnionProject.Application.Layer.Services.Sepetler;
using System.Threading.Tasks;

namespace OnionProject.UI.MVCCore.Areas.UyeArea.Controllers
{
    [Area("UyeArea")]
    public class UyeController : Controller
    {
        private readonly ISepetService sepetService;
        private readonly ILoginService loginService;
        public UyeController(ISepetService _sepetService, ILoginService _loginService)
        {
            sepetService = _sepetService;
            loginService = _loginService;
        }
        public async Task<IActionResult> Index()
        {
            // sepetteki ürünleri listele
            var uye = await loginService.UyeGetirAsync(User);
            var sepettekiUrunler = await sepetService.KullanicininSepettekiUrunleriniGetirAsync(uye.Id);
            return View(sepettekiUrunler);
        }

        [HttpPost]
        public async Task<IActionResult> SepeteEkle(int uid) // view de id olarak urunId için uid dedik
        {
            SepeteEkleDTO ekle = new();
            ekle.UyeId = await UyeIdGetir();
            ekle.UrunId = uid;
            ekle.Adet = 1;
            await sepetService.SepeteEkleAsync(ekle);

            return NoContent();
        }

        private async Task<int> UyeIdGetir()
        {
            var uye = await loginService.UyeGetirAsync(User);
            return uye.Id;
        }
    }
}
