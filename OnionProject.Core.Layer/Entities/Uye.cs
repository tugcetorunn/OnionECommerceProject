using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// sadece identity ile ilgili olan paketleri bu katmana ekliyoruz. ef core ile ilgili olanları eklemiyoruz kesinlikle.

namespace OnionProject.Core.Layer.Entities
{
    public class Uye : IdentityUser<int>
    {
        public string Adres { get; set; }
        public ICollection<Sepet>? SepettekiUrunler { get; set; } // sepeti temsil eden bir koleksiyon
    }
}
