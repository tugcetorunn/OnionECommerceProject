using OnionProject.Core.Layer.Entities;
using OnionProject.Core.Layer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Application.Layer.Models.ViewModels.Urunler
{
    public class UrunAdminDetayVM
    {
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public decimal Fiyat { get; set; }
        public string Aciklama { get; set; }
        public string UrunResmi { get; set; }
        public int StokAdedi { get; set; }
        public int KategoriId { get; set; }
        public string Kategori { get; set; } // joinlenmiş veri old için vm
        public DateTime EklenmeTarihi { get; set; }
        public DateTime? GuncellenmeTarihi { get; set; }
        public DateTime? SilinmeTarihi { get; set; }
        public string KayitDurumu { get; set; } // ??
        public KayitDurumu KayitDurumuEnum { get; set; } // enum türünde
    }
}
