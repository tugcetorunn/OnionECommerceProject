using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using OnionProject.Core.Layer.Abstracts;
using OnionProject.Core.Layer.Enums;
using OnionProject.Core.Layer.Repositories.Abstracts;
using OnionProject.Infrastructure.Layer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            await context.SaveChangesAsync(); // son sınavda savechanges i repodaki metodu kullanarak yaptım doğru mu bak...
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

        public async Task<IEnumerable<TResult>> FiltreleVeListeleAsync<TResult>(Expression<Func<TEntity, TResult>> select, Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = table.AsNoTracking();

            if(where != null)
                query = query.Where(where);

            if (include != null)
                query = include(query);

            if (orderBy != null)
                return await orderBy(query).Select(select).ToListAsync();
            else
                return await query.Select(select).ToListAsync();
        }
    }
}
