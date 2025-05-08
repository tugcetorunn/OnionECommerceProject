using OnionProject.Core.Layer.Abstracts;
using OnionProject.Core.Layer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Core.Layer.Entities
{
    public class Urun : IEntity
    {
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public decimal Fiyat { get; set; }
        public string Aciklama { get; set; }
        public string UrunResmi { get; set; }
        public int StokAdedi { get; set; }
        public int KategoriId { get; set; }
        public Kategori? Kategori { get; set; }
        public ICollection<Sepet>? SepettekiUrunler { get; set; } // sepeti temsil eden bir koleksiyon
        public DateTime EklenmeTarihi { get; set; }
        public DateTime? GuncellenmeTarihi { get; set; }
        public DateTime? SilinmeTarihi { get; set; }
        public KayitDurumu KayitDurumu { get; set; }
    }
}
