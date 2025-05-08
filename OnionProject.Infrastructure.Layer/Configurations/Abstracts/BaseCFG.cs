using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionProject.Core.Layer.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Infrastructure.Layer.Configurations.Abstracts
{
    public abstract class BaseCFG<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : class, IEntity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(x => x.EklenmeTarihi).HasColumnType("smalldatetime").HasDefaultValue(DateTime.Now);
            builder.Property(x => x.GuncellenmeTarihi).HasColumnType("smalldatetime").IsRequired(false);
            builder.Property(x => x.SilinmeTarihi).HasColumnType("smalldatetime").IsRequired(false);
        }
    }
}
