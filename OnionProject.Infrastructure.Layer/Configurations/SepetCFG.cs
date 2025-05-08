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
    public class SepetCFG : BaseCFG<Sepet>, IEntityTypeConfiguration<Sepet>
    {
        public void Configure(EntityTypeBuilder<Sepet> builder)
        {
            base.Configure(builder);
        }
    }
}
