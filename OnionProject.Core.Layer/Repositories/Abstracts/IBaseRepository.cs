using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
