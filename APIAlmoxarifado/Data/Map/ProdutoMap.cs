using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using APIAlmoxarifado.Models;

namespace APIAlmoxarifado.Data.Map
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(x => x.IdProduto);
            builder.Property(x => x.Descricao).HasMaxLength(255);
            builder.Property(x => x.Preco).HasColumnType("decimal(10, 2)");
            builder.Property(x => x.EstoqueAtual);
            builder.Property(x => x.EstoqueMinimo);
            builder.Property(x => x.Status);
            builder.Property(x => x.EmailStatus).HasDefaultValue(false);
        }
    }
}
