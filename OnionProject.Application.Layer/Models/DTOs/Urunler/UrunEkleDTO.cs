using OnionProject.Core.Layer.Entities;
using OnionProject.Core.Layer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Application.Layer.Models.DTOs.Urunler
{
    public class UrunEkleDTO
    {
        public string UrunAdi { get; set; }
        public decimal Fiyat { get; set; }
        public string Aciklama { get; set; }
        public string UrunResmi { get; set; }
        public int StokAdedi { get; set; }
        public int KategoriId { get; set; }
        public KayitDurumu KayitDurumu { get; set; }
    }
}
