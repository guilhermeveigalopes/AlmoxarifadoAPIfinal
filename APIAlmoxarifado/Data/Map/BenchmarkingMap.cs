using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using APIAlmoxarifado.Models;

namespace APIAlmoxarifado.Data.Map
{
    public class BenchmarkingMap : IEntityTypeConfiguration<Benchmarking>
    {
        public void Configure(EntityTypeBuilder<Benchmarking> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.MercadoTitle).HasMaxLength(255);
            builder.Property(x => x.MercadoPrice).HasMaxLength(50);
            builder.Property(x => x.MercadoUrl).HasMaxLength(500);
            builder.Property(x => x.MagazineTitle).HasMaxLength(255);
            builder.Property(x => x.MagazinePrice).HasMaxLength(50);
            builder.Property(x => x.MagazineUrl).HasMaxLength(500);
            builder.Property(x => x.Melhor).IsRequired();
        }
    }
}
