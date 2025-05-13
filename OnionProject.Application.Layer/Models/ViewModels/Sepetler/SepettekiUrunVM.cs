using OnionProject.Core.Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Application.Layer.Models.ViewModels.Sepetler
{
    public class SepettekiUrunVM
    {
        public int SepetId { get; set; }
        public int UyeId { get; set; }
        public int UrunId { get; set; }
        public int Adet { get; set; }
        public string UrunAdi { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamFiyat => Adet * Fiyat;
    }
}
