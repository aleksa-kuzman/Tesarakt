using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Tesarakt.Common.Models.Domain
{
    public partial class TesaraktContext : DbContext
    {
        public virtual DbSet<GrupaProizvoda> GrupaProizvoda { get; set; }
        public virtual DbSet<Proizvod> Proizvod { get; set; }


        public TesaraktContext(DbContextOptions<TesaraktContext> options) :base (options)
        {

        }
       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(@"server=localhost;Database=tesarakt;user=root;password='' ");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity((Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<GrupaProizvoda> entity) =>
            {
                entity.HasKey(e => e.Id);
                

                entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("GrupaId");

                entity.Property(e => e.NazivGrupe).HasMaxLength(50);
            });

            modelBuilder.Entity<Proizvod>(entity =>
            {


                entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("ProizvodId");
               
                entity.Property(e => e.NazivProizvoda).HasMaxLength(50);
            });
        }
    }
}
