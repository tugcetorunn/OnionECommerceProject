using OnionProject.Core.Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Core.Layer.Repositories.Abstracts
{
    public interface IUrunRepository : IBaseRepository<Urun>
    {
        //Task<IEnumerable<Urun>> UrunleriKategoriyeGoreListeleAsync(int kategoriId);
        //Task<IEnumerable<Urun>> UrunleriFiyataGoreListeleAsync(decimal minFiyat, decimal maxFiyat);
        //Task<IEnumerable<Urun>> UrunleriStokAdedineGoreListeleAsync(int stokAdedi);
        //Task<IEnumerable<Urun>> UrunleriEklenmeTarihineGoreListeleAsync(DateTime eklenmeTarihi);
        //Task<IEnumerable<Urun>> UrunleriGuncellenmeTarihineGoreListeleAsync(DateTime guncellenmeTarihi);

        //Task UrunEkle(Urun urun);
        //Task UrunGuncelle(Urun urun);
        //Task UrunSil(int urunId); // soft delete
        //Task<IEnumerable<Urun>> UrunleriListele();

        Task<Urun?> UrunBulAsync(int urunId);
        Task<IEnumerable<Urun?>> UrunleriListeleAsync();
    }
}
