using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PrjWebApi01.Models
{
    public partial class LibraryContext : DbContext
    {
        public LibraryContext()
        {
        }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Producers> Producers { get; set; }
        public virtual DbSet<Films> Films { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Library;Username=postgres;Password=servidor;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Producers>(entity =>
            {
                entity.HasKey(e => e.IdProducer)
                    .HasName("pk_producer");

                entity.ToTable("producers");

                entity.Property(e => e.IdProducer)
                    .HasColumnName("id_producer")
                    .HasColumnType("numeric(10,0)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(30);

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(30);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Films>(entity =>
            {
                entity.HasKey(e => e.IdFilm)
                    .HasName("pk_film");

                entity.ToTable("films");

                entity.Property(e => e.IdFilm)
                    .HasColumnName("id_film")
                    .HasColumnType("numeric(10,0)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200);

                entity.Property(e => e.Genre)
                    .HasColumnName("genre")
                    .HasMaxLength(30);

                entity.Property(e => e.IdProducer)
                    .HasColumnName("id_producer")
                    .HasColumnType("numeric(10,0)");

                entity.Property(e => e.Publisher)
                    .HasColumnName("publisher")
                    .HasMaxLength(30);

                entity.Property(e => e.Section)
                    .HasColumnName("section")
                    .HasMaxLength(20);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(30);

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.IdProducerNavigation)
                    .WithMany(p => p.Films)
                    .HasForeignKey(d => d.IdProducer)
                    .HasConstraintName("fk_filmsproducers");
            });
        }
    }
}
