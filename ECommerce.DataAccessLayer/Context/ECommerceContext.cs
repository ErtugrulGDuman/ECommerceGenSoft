using ECommerce.EntityLayer.Conrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccessLayer.Context
{
    public class ECommerceContext : DbContext
    {
        public ECommerceContext(DbContextOptions<ECommerceContext> options) : base(options)
        {
        }

        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
        public DbSet<SiparisDetay> SiparisDetaylar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Kullanici Konfigürasyonu
            modelBuilder.Entity<Kullanici>(entity =>
            {
                entity.ToTable("Kullanicilar");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Sifre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Ad)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Soyad)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Telefon)
                    .HasMaxLength(15);

                entity.HasIndex(e => e.Email)
                    .IsUnique();
            });

            // Urun Konfigürasyonu
            modelBuilder.Entity<Urun>(entity =>
            {
                entity.ToTable("Urunler");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Ad)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Fiyat)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(1000);

                entity.Property(e => e.KisaAciklama)
                    .HasMaxLength(250);

                entity.Property(e => e.Resim)
                    .HasMaxLength(500);
            });

            // Siparis Konfigürasyonu
            modelBuilder.Entity<Siparis>(entity =>
            {
                entity.ToTable("Siparisler");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.SiparisNumarasi)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ToplamTutar)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();

                entity.Property(e => e.TeslimatAdresi)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.TeslimatNotu)
                    .HasMaxLength(250);

                // Kullanici ile ilişki
                entity.HasOne(d => d.Kullanici)
                    .WithMany(p => p.Siparisler)
                    .HasForeignKey(d => d.KullaniciId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // SiparisDetay Konfigürasyonu
            modelBuilder.Entity<SiparisDetay>(entity =>
            {
                entity.ToTable("SiparisDetaylar");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.BirimFiyat)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();

                entity.Property(e => e.ToplamFiyat)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();

                entity.Property(e => e.Not)
                    .HasMaxLength(250);

                // Siparis ile ilişki
                entity.HasOne(d => d.Siparis)
                    .WithMany(p => p.SiparisDetaylari)
                    .HasForeignKey(d => d.SiparisId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Urun ile ilişki
                entity.HasOne(d => d.Urun)
                    .WithMany(p => p.SiparisDetaylari)
                    .HasForeignKey(d => d.UrunId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                    e.State == EntityState.Added
                    || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).GuncellemeTarihi = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).OlusturmaTarihi = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
