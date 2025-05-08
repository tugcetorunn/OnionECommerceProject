using OnionProject.Core.Layer.Abstracts;
using OnionProject.Core.Layer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Core.Layer.Entities
{
    public class Kategori : IEntity
    {
        public int KategoriId { get; set; }
        public string KategoriAdi { get; set; }
        public ICollection<Urun>? Urunler { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public DateTime? GuncellenmeTarihi { get; set; }
        public DateTime? SilinmeTarihi { get; set; }
        public KayitDurumu KayitDurumu { get; set; }
    }
}
