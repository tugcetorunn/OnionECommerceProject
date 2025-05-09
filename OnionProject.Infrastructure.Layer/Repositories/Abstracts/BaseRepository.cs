using Microsoft.EntityFrameworkCore;
using OnionProject.Core.Layer.Abstracts;
using OnionProject.Core.Layer.Enums;
using OnionProject.Core.Layer.Repositories.Abstracts;
using OnionProject.Infrastructure.Layer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Infrastructure.Layer.Repositories.Abstracts
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IEntity 
    {
        protected readonly UrunDbContext context;
        protected readonly DbSet<TEntity> table;
        public BaseRepository(UrunDbContext _context)
        {
            context = _context;
            table = context.Set<TEntity>();
        }
        public async Task<TEntity> AraAsync(int id)
        {
            return await table.FindAsync(id);
        }

        public async Task EkleAsync(TEntity entity)
        {
            entity.EklenmeTarihi = DateTime.Now;
            entity.KayitDurumu = KayitDurumu.Eklendi;
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task GuncelleAsync(TEntity entity)
        {
            entity.GuncellenmeTarihi = DateTime.Now;
            entity.KayitDurumu = KayitDurumu.Guncellendi;
            context.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> ListeleAsync()
        {
            return await table.Where(x => x.KayitDurumu != KayitDurumu.Silindi).ToListAsync();
        }

        public async Task SilAsync(int id)
        {
            var entity = await AraAsync(id);

            entity.SilinmeTarihi = DateTime.Now;
            entity.KayitDurumu = KayitDurumu.Silindi;
            context.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
