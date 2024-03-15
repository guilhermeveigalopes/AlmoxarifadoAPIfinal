using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using APIAlmoxarifado.Models;

namespace APIAlmoxarifado.Data.Map
{
    public class LogsMap : IEntityTypeConfiguration<Logs>
    {
        public void Configure(EntityTypeBuilder<Logs> builder)
        {
            builder.HasKey(x => x.IdLog);
            builder.Property(x => x.CodRob).IsRequired().HasMaxLength(255);
            builder.Property(x => x.UsuRob).IsRequired().HasMaxLength(255);
            builder.Property(x => x.DateLog).IsRequired();
            builder.Property(x => x.Processo).IsRequired().HasMaxLength(255);
            builder.Property(x => x.InfLog).HasMaxLength(1000);
            builder.Property(x => x.IdProd).IsRequired();
        }
    }
}
