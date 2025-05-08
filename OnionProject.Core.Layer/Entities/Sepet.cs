using OnionProject.Core.Layer.Abstracts;
using OnionProject.Core.Layer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Core.Layer.Entities
{
    public class Sepet : IEntity
    {
        public int SepetId { get; set; }
        public int UyeId { get; set; }
        public int UrunId { get; set; }
        public int Adet { get; set; } // aynı üründen kaç tane
        public Uye? Uye { get; set; }
        public Urun? Urun { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public DateTime GuncellenmeTarihi { get; set; }
        public DateTime SilinmeTarihi { get; set; }
        public KayitDurumu KayitDurumu { get; set; }
    }
}
