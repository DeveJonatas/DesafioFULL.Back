using Desafio.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Desafio.Repository
{
    public class DesafioDbContext : DbContext
    {

        public DesafioDbContext(DbContextOptions<DesafioDbContext> options) : base(options)
        {
        }

        public IQueryable<Titulo> TitulosQuery { get => Titulos; }
        public IQueryable<Parcela> ParcelaQuery { get => Parcelas; }


        public DbSet<Titulo> Titulos { get; set; }
        public DbSet<Parcela> Parcelas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Titulo>().HasKey(x => x.Id);

            builder.Entity<Titulo>().Property(x => x.NomeDevedor).HasMaxLength(80);

            builder.Entity<Titulo>().Property(x => x.Juros).HasPrecision(10, 2);

            builder.Entity<Titulo>().Property(x => x.Multa).HasPrecision(10, 2);


            builder.Entity<Parcela>().HasKey(x => x.Id);

            builder.Entity<Parcela>().Property(x => x.Valor).HasPrecision(10, 2);

            builder.Entity<Parcela>()
                .HasOne(s => s.Titulo)
                .WithMany(g => g.Parcelas)
                .HasForeignKey(s => s.IdTitulo);

            base.OnModelCreating(builder);
        }
    }
}
