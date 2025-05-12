using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnionProject.Application.Layer.Models.DTOs.Urunler;
using OnionProject.Application.Layer.Services.Kategoriler;
using OnionProject.Application.Layer.Services.Urunler;
using OnionProject.UI.MVCCore.Utilities;
using OnionProject.UI.MVCCore.ViewModels.Urunler;
using System.Threading.Tasks;

namespace OnionProject.UI.MVCCore.Controllers
{
    [Authorize]
    public class UrunController : Controller
    {
        private readonly IUrunService urunService;
        private readonly IKategoriService kategoriService;
        private readonly IMapper mapper;
        public UrunController(IUrunService _urunService, IKategoriService _kategoriService, IMapper _mapper)
        {
            urunService = _urunService;
            kategoriService = _kategoriService;
            mapper = _mapper;
        }
        [AllowAnonymous]
        public async Task<IActionResult?> Index()
        {
            return View(await urunService.UrunleriListeleAsync());
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AdmineDetay(int id)
        {
            var urun = await urunService.AdmineUrunBulAsync(id);
            if (urun == null)
            {
                return NotFound();
            }
            return View(urun);
        }

        [Authorize(Roles = "Uye")]
        public async Task<IActionResult> UyeyeDetay(int id)
        {
            var urun = await urunService.UyeyeUrunBulAsync(id);
            if (urun == null)
            {
                return NotFound();
            }
            return View(urun);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Ekle()
        {
            var kategoriler = new SelectList(await kategoriService.KategorileriListeleAsync(), "KategoriId", "KategoriAdi");
            UrunEkleFormVM form = new UrunEkleFormVM
            {
                Kategoriler = kategoriler
            };
            return View(form);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Ekle(UrunEkleVM urun)
        {
            if (ModelState.IsValid)
            {
                UrunEkleDTO urunDTO = new()
                {
                    UrunAdi = urun.UrunAdi,
                    KategoriId = urun.KategoriId,
                    Fiyat = urun.Fiyat,
                    StokAdedi = urun.StokAdedi,
                    Aciklama = urun.Aciklama,
                    UrunResmi = FileOperations.UploadImage(urun.UrunResmiDosya),
                };
                await urunService.UrunEkleAsync(urunDTO);
                return RedirectToAction("Index");
            }

            var kategoriler = new SelectList(await kategoriService.KategorileriListeleAsync(), "KategoriId", "KategoriAdi");
            UrunEkleFormVM form = new UrunEkleFormVM
            {
                Kategoriler = kategoriler
            };
            return View(form);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Guncelle(int id)
        {
            var urun = await urunService.AdmineUrunBulAsync(id);
            if (urun == null)
            {
                return NotFound();
            }
            var kategoriler = new SelectList(await kategoriService.KategorileriListeleAsync(), "KategoriId", "KategoriAdi");
            UrunGuncelleVM urunVM = new()
            {
                UrunId = urun.UrunId,
                KategoriId = urun.KategoriId,
                UrunAdi = urun.UrunAdi,
                Fiyat = urun.Fiyat,
                StokAdedi = urun.StokAdedi,
                Aciklama = urun.Aciklama,
                UrunResmi = urun.UrunResmi,
            };
            UrunGuncelleFormVM form = new UrunGuncelleFormVM
            {
                Kategoriler = kategoriler,
                Urun = urunVM
            };
            return View(form);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Guncelle(UrunGuncelleVM urun)
        {
            if (ModelState.IsValid)
            {
                var eskiUrun = await urunService.AdmineUrunBulAsync(urun.UrunId);
                UrunGuncelleDTO urunDTO = new()
                {
                    UrunId = urun.UrunId,
                    KategoriId = urun.KategoriId,
                    UrunAdi = urun.UrunAdi,
                    Fiyat = urun.Fiyat,
                    StokAdedi = urun.StokAdedi,
                    Aciklama = urun.Aciklama,
                    UrunResmi = eskiUrun.UrunResmi,
                };

                if (urun.UrunResmiDosya != null)
                {
                    urunDTO.UrunResmi = FileOperations.UploadImage(urun.UrunResmiDosya);
                }

                await urunService.UrunGuncelleAsync(urunDTO);
                return RedirectToAction("Index");
            }
            var kategoriler = new SelectList(await kategoriService.KategorileriListeleAsync(), "KategoriId", "KategoriAdi");
            UrunGuncelleFormVM form = new UrunGuncelleFormVM
            {
                Kategoriler = kategoriler,
                Urun = urun
            };
            return View(form);
        }
    }
}
