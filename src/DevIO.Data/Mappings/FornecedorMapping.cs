using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                    .IsRequired()
                    .HasColumnType("varchar(200)");

            builder.Property(p => p.Documento)
                    .IsRequired()
                    .HasColumnType("varchar(14)");

            //configuracao de  1x1 fornecedor para endereço
            builder.HasOne(x => x.Endereco)
                    .WithOne(e => e.Fornecedor);

            //configuracao de  1xN fornecedor para produtos
            builder.HasMany(x => x.Produtos)
                    .WithOne(p => p.Fornecedor)
                    .HasForeignKey(p => p.FornecedorId);


            builder.ToTable("Fornecedores");
        }
    }
}
