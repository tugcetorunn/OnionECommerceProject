using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Core.Layer.Repositories.Abstracts
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task EkleAsync(TEntity entity);
        Task GuncelleAsync(TEntity entity);
        Task SilAsync(int id);
        Task<TEntity> AraAsync(int id);
        Task<IEnumerable<TEntity>> ListeleAsync();
        Task<IEnumerable<TResult>> FiltreleVeListeleAsync<TResult>(Expression<Func<TEntity, TResult>> select, Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
    }
}
