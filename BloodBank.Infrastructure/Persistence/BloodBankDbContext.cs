using BloodBank.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Infrastructure.Persistence;

public class BloodBankDbContext : DbContext
{
    public BloodBankDbContext(DbContextOptions<BloodBankDbContext> options) : base(options)
    {

    }


    public DbSet<Doador> Doadores { get; set; }
    public DbSet<Doacao> Doacoes { get; set; }
    public DbSet<Endereco> Endereco { get; set; }
    public DbSet<EstoqueSangue> EstoqueSange { get; set; }

    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Doador>(d =>
        {
            d.HasKey(d => d.Id);
            d.HasMany<Doacao>(x => x.Doacoes)
                .WithOne(x => x.Doador)
                .HasForeignKey(x=> x.DoadorId)
                .OnDelete(DeleteBehavior.Cascade);

            d.HasOne<Endereco>(x => x.Endereco)
                .WithOne(x => x.Doador)
                .HasForeignKey<Doador>(x=> x.EnderecoId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        base.OnModelCreating(builder);
    }
}

