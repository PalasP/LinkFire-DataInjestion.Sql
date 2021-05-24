using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace DataInjestion.Sql.Models
{
    public partial class LinkFireDBContext : DbContext
    {
        public LinkFireDBContext()
        {
        }

        public LinkFireDBContext(DbContextOptions<LinkFireDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Artistcollection> Artistcollections { get; set; }
        public virtual DbSet<Collection> Collections { get; set; }
        public virtual DbSet<Collectionmatch> Collectionmatches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Name=LinkFireDB");
               // IConfigurationRoot configuration = new ConfigurationBuilder()
               //.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
               //.AddJsonFile("appsettings.json")
               //.Build();
               // optionsBuilder.UseSqlServer(configuration.GetConnectionString("LinkFireDB"), x => x.UseNetTopologySuite());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.ToTable("ARTIST");

                entity.Property(e => e.ArtistId)
                    .ValueGeneratedNever()
                    .HasColumnName("artist_id");

                entity.Property(e => e.ArtistTypeId).HasColumnName("artist_type_id");

                entity.Property(e => e.ExportDate).HasColumnName("export_date");

                entity.Property(e => e.IsActualArtist).HasColumnName("is_actual_artist");

                entity.Property(e => e.Name)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.ViewUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("view_url");
            });

            modelBuilder.Entity<Artistcollection>(entity =>
            {
                entity.HasKey(e => new { e.ArtistId, e.CollectionId, e.RoleId })
                    .HasName("PK__ARTISTCO__6CD0400119605F66");

                entity.ToTable("ARTISTCOLLECTION");

                entity.Property(e => e.ArtistId).HasColumnName("artist_id");

                entity.Property(e => e.CollectionId).HasColumnName("collection_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.ExportDate).HasColumnName("export_date");

                entity.Property(e => e.IsPrimaryArtist).HasColumnName("is_primary_artist");
            });

            modelBuilder.Entity<Collection>(entity =>
            {
                entity.ToTable("COLLECTION");

                entity.Property(e => e.CollectionId)
                    .ValueGeneratedNever()
                    .HasColumnName("collection_id");

                entity.Property(e => e.ArtistDisplayName)
                    .IsUnicode(false)
                    .HasColumnName("artist_display_name");

                entity.Property(e => e.ArtworkUrl)
                    .IsUnicode(false)
                    .HasColumnName("artwork_url");

                entity.Property(e => e.CollectionTypeId)
                    .IsUnicode(false)
                    .HasColumnName("collection_type_id");

                entity.Property(e => e.ContentProviderName)
                    .IsUnicode(false)
                    .HasColumnName("content_provider_name");

                entity.Property(e => e.Copyright)
                    .IsUnicode(false)
                    .HasColumnName("copyright");

                entity.Property(e => e.ExportDate).HasColumnName("export_date");

                entity.Property(e => e.IsCompilation)
                    .IsUnicode(false)
                    .HasColumnName("is_compilation");

                entity.Property(e => e.ItunesReleaseDate)
                    .HasColumnType("datetime")
                    .HasColumnName("itunes_release_date");

                entity.Property(e => e.LabelStudio)
                    .IsUnicode(false)
                    .HasColumnName("label_studio");

                entity.Property(e => e.MediaTypeId)
                    .IsUnicode(false)
                    .HasColumnName("media_type_id");

                entity.Property(e => e.Name)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.OriginalReleaseDate)
                    .HasColumnType("datetime")
                    .HasColumnName("original_release_date");

                entity.Property(e => e.PLine)
                    .IsUnicode(false)
                    .HasColumnName("p_line");

                entity.Property(e => e.ParentalAdvisoryId).HasColumnName("parental_advisory_id");

                entity.Property(e => e.SearchTerms)
                    .IsUnicode(false)
                    .HasColumnName("search_terms");

                entity.Property(e => e.TitleVersion)
                    .IsUnicode(false)
                    .HasColumnName("title_version");

                entity.Property(e => e.ViewUrl)
                    .IsUnicode(false)
                    .HasColumnName("view_url");
            });

            modelBuilder.Entity<Collectionmatch>(entity =>
            {
                entity.HasKey(e => e.CollectionId)
                    .HasName("PK__COLLECTI__53D3A5CA6CD19A9D");

                entity.ToTable("COLLECTIONMATCH");

                entity.Property(e => e.CollectionId)
                    .ValueGeneratedNever()
                    .HasColumnName("collection_id");

                entity.Property(e => e.AmgAlbumId)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("amg_album_id");

                entity.Property(e => e.ExportDate).HasColumnName("export_date");

                entity.Property(e => e.Grid)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("grid");

                entity.Property(e => e.Upc)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("upc");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
