using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionProject.Core.Layer.Entities;
using OnionProject.Infrastructure.Layer.Configurations.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Infrastructure.Layer.Configurations
{
    public class UrunCFG : BaseCFG<Urun>, IEntityTypeConfiguration<Urun>
    {
        public void Configure(EntityTypeBuilder<Urun> builder)
        {
            base.Configure(builder);
        }
    }
}
