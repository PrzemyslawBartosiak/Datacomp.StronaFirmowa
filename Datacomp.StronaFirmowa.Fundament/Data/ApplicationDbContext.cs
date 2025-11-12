using Datacomp.StronaFirmowa.Fundament.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Datacomp.StronaFirmowa.Fundament.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Faq> Faq => Set<Faq>();
        public DbSet<WpisBlog> WpisyBlog => Set<WpisBlog>();
        public DbSet<Aktualnosc> Aktualnosci => Set<Aktualnosc>();
        public DbSet<Uzytkownik> Uzytkownicy => Set<Uzytkownik>();
        public DbSet<WiadomoscKontaktowa> WiadomosciKontaktowe => Set<WiadomoscKontaktowa>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Konfiguracja FAQ
            modelBuilder.Entity<Faq>(entity =>
            {
                entity.ToTable("Faq");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Pytanie).IsRequired().HasMaxLength(500);
                entity.Property(e => e.Odpowiedz).IsRequired();
                entity.Property(e => e.Jezyk).IsRequired().HasMaxLength(10);
                entity.HasIndex(e => new { e.Jezyk, e.Kolejnosc });
                entity.HasIndex(e => e.CzyAktywny);
            });

            // Konfiguracja WpisBlog
            modelBuilder.Entity<WpisBlog>(entity =>
            {
                entity.ToTable("WpisyBlog");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Tytul).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Slug).IsRequired().HasMaxLength(250);
                entity.Property(e => e.Tresc).IsRequired();
                entity.Property(e => e.Streszczenie).HasMaxLength(500);
                entity.Property(e => e.Jezyk).IsRequired().HasMaxLength(10);
                entity.HasIndex(e => e.Slug).IsUnique();
                entity.HasIndex(e => new { e.Jezyk, e.CzyOpublikowany });
            });

            // Konfiguracja Aktualnosc
            modelBuilder.Entity<Aktualnosc>(entity =>
            {
                entity.ToTable("Aktualnosci");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Tytul).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Tresc).IsRequired();
                entity.Property(e => e.Streszczenie).HasMaxLength(500);
                entity.Property(e => e.Jezyk).IsRequired().HasMaxLength(10);
                entity.HasIndex(e => new { e.Jezyk, e.CzyOpublikowany, e.DataPublikacji });
            });

            // Konfiguracja Uzytkownik
            modelBuilder.Entity<Uzytkownik>(entity =>
            {
                entity.ToTable("Uzytkownicy");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.HashHasla).IsRequired();
                entity.Property(e => e.Rola).IsRequired().HasMaxLength(50);
                entity.HasIndex(e => e.Email).IsUnique();
            });

            // Konfiguracja WiadomoscKontaktowa
            modelBuilder.Entity<WiadomoscKontaktowa>(entity =>
            {
                entity.ToTable("WiadomosciKontaktowe");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Imie).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Temat).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Wiadomosc).IsRequired();
                entity.HasIndex(e => e.DataUtworzenia);
                entity.HasIndex(e => e.CzyPrzeczytana);
            });
        }
    }
}
