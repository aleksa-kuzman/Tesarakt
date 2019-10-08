using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Tesarakt.Common.Models.Domain
{
    public partial class TesaraktContext : DbContext
    {
        public virtual DbSet<GrupaProizvoda> GrupaProizvoda { get; set; }
        public virtual DbSet<Proizvod> Proizvod { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-TQ3HLQF;Database=Tesarakt;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GrupaProizvoda>(entity =>
            {
                entity.HasKey(e => e.GrupaId);

                entity.Property(e => e.GrupaId).ValueGeneratedNever();

                entity.Property(e => e.NazivGrupe).HasMaxLength(50);
            });

            modelBuilder.Entity<Proizvod>(entity =>
            {
                entity.Property(e => e.ProizvodId).ValueGeneratedNever();

                entity.Property(e => e.NazivProizvoda).HasMaxLength(50);
            });
        }
    }
}
