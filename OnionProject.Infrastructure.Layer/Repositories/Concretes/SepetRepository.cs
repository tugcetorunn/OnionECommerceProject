using OnionProject.Core.Layer.Entities;
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
    public class SepetRepository : BaseRepository<Sepet>, ISepetRepository
    {
        public SepetRepository(UrunDbContext context) : base(context)
        {
        }
    }
}
