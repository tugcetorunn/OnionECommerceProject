using OnionProject.Application.Layer.Models.DTOs.Urunler;
using OnionProject.Application.Layer.Models.ViewModels.Urunler;
using OnionProject.Core.Layer.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Application.Layer.Services.Urunler
{
    public interface IUrunService
    {
        Task UrunEkleAsync(UrunEkleDTO urun);
        Task UrunGuncelleAsync(UrunGuncelleDTO urun);
        Task UrunSilAsync(int urunId); // soft delete
        Task<IEnumerable<UrunListeleDTO?>> UrunleriListeleAsync();
        Task<UrunAdminDetayVM> AdmineUrunBulAsync(int urunId);
        Task<UrunUyeDetayVM> UyeyeUrunBulAsync(int urunId);
        // Task<IEnumerable<UrunListeleDTO>> UrunleriListeleByKategoriIdAsync(int kategoriId);

        Task<UrunAdminDetayVM> UrunDetayGetirAsync(int urunId);
    }
}
