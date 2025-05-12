using Microsoft.EntityFrameworkCore;
using OnionProject.Core.Layer.Entities;
using OnionProject.Core.Layer.Enums;
using OnionProject.Core.Layer.Repositories.Abstracts;
using OnionProject.Infrastructure.Layer.Contexts;
using OnionProject.Infrastructure.Layer.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Infrastructure.Layer.Repositories.Concretes
{
    public class UrunRepository : BaseRepository<Urun>, IUrunRepository
    {
        public UrunRepository(UrunDbContext context) : base(context)
        {
        }

        public async Task<Urun?> UrunBulAsync(int urunId)
        {
            return await table.Include(x => x.Kategori).SingleOrDefaultAsync(x => x.UrunId == urunId && x.KayitDurumu != KayitDurumu.Silindi);
        }

        public async Task<IEnumerable<Urun?>> UrunleriListeleAsync()
        {
            var urunler = await table.Include(x => x.Kategori).Where(x => x.KayitDurumu != KayitDurumu.Silindi).ToListAsync();
            if (urunler == null || !urunler.Any())
                return new List<Urun?>();
            return urunler;
        }

    }
}
