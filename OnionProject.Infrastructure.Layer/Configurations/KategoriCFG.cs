using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionProject.Core.Layer.Entities;
using OnionProject.Core.Layer.Enums;
using OnionProject.Infrastructure.Layer.Configurations.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Infrastructure.Layer.Configurations
{
    public class KategoriCFG : BaseCFG<Kategori>, IEntityTypeConfiguration<Kategori>
    {
        public void Configure(EntityTypeBuilder<Kategori> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.KategoriAdi).HasMaxLength(30).IsRequired();

            builder.HasData(new Kategori
            {
                KategoriId = 1,
                KategoriAdi = "Meyve",
                KayitDurumu = KayitDurumu.Eklendi
            }, new Kategori
            {
                KategoriId = 2,
                KategoriAdi = "Sebze",
                KayitDurumu = KayitDurumu.Eklendi
            }, new Kategori
            {
                KategoriId = 3,
                KategoriAdi = "Süt Ürünleri",
                KayitDurumu = KayitDurumu.Eklendi
            }, new Kategori
            {
                KategoriId = 4,
                KategoriAdi = "Kadın Giyim",
                KayitDurumu = KayitDurumu.Eklendi
            }, new Kategori
            {
                KategoriId = 5,
                KategoriAdi = "Erkek Giyim",
                KayitDurumu = KayitDurumu.Eklendi
            }, new Kategori
            {
                KategoriId = 6,
                KategoriAdi = "Kadın Ayakkabı",
                KayitDurumu = KayitDurumu.Eklendi
            }, new Kategori
            {
                KategoriId = 7,
                KategoriAdi = "Erkek Ayakkabı",
                KayitDurumu = KayitDurumu.Eklendi
            });
        }
    }
}
