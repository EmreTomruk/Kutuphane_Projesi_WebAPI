using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebAPI_I.Model
{
    public partial class KutuphaneDBContext : DbContext
    {
        public KutuphaneDBContext()
        {
        }

        public KutuphaneDBContext(DbContextOptions<KutuphaneDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<Cezalar> Cezalars { get; set; }
        public virtual DbSet<KategoriKitap> KategoriKitaps { get; set; }
        public virtual DbSet<Kategoriler> Kategorilers { get; set; }
        public virtual DbSet<KitapKategori> KitapKategoris { get; set; }
        public virtual DbSet<Kitaplar> Kitaplars { get; set; }
        public virtual DbSet<OduncVerme> OduncVermes { get; set; }
        public virtual DbSet<YayinEvleri> YayinEvleris { get; set; }
        public virtual DbSet<Yazarlar> Yazarlars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data source=.;initial catalog=KutuphaneDB;integrated security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.CezaBitisTarihi).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Cezalar>(entity =>
            {
                entity.HasKey(e => e.CezaId);

                entity.ToTable("Cezalar");

                entity.HasIndex(e => e.UyeId, "IX_Cezalar_UyeID");

                entity.Property(e => e.CezaId).HasColumnName("CezaID");

                entity.Property(e => e.UyeId).HasColumnName("UyeID");

                entity.HasOne(d => d.Uye)
                    .WithMany(p => p.Cezalars)
                    .HasForeignKey(d => d.UyeId);
            });

            modelBuilder.Entity<KategoriKitap>(entity =>
            {
                entity.HasKey(e => new { e.KategorilerKategoriId, e.KitaplarKitapId });

                entity.ToTable("KategoriKitap");

                entity.HasIndex(e => e.KitaplarKitapId, "IX_KategoriKitap_KitaplarKitapID");

                entity.Property(e => e.KategorilerKategoriId).HasColumnName("KategorilerKategoriID");

                entity.Property(e => e.KitaplarKitapId).HasColumnName("KitaplarKitapID");

                entity.HasOne(d => d.KategorilerKategori)
                    .WithMany(p => p.KategoriKitaps)
                    .HasForeignKey(d => d.KategorilerKategoriId);

                entity.HasOne(d => d.KitaplarKitap)
                    .WithMany(p => p.KategoriKitaps)
                    .HasForeignKey(d => d.KitaplarKitapId);
            });

            modelBuilder.Entity<Kategoriler>(entity =>
            {
                entity.HasKey(e => e.KategoriId);

                entity.ToTable("Kategoriler");

                entity.Property(e => e.KategoriId).HasColumnName("KategoriID");
            });

            modelBuilder.Entity<KitapKategori>(entity =>
            {
                entity.ToTable("KitapKategori");

                entity.HasIndex(e => e.KategoriId, "IX_KitapKategori_KategoriID");

                entity.HasIndex(e => e.KitapId, "IX_KitapKategori_KitapID");

                entity.Property(e => e.KitapKategoriId).HasColumnName("KitapKategoriID");

                entity.Property(e => e.KategoriId).HasColumnName("KategoriID");

                entity.Property(e => e.KitapId).HasColumnName("KitapID");

                entity.HasOne(d => d.Kategori)
                    .WithMany(p => p.KitapKategoris)
                    .HasForeignKey(d => d.KategoriId);

                entity.HasOne(d => d.Kitap)
                    .WithMany(p => p.KitapKategoris)
                    .HasForeignKey(d => d.KitapId);
            });

            modelBuilder.Entity<Kitaplar>(entity =>
            {
                entity.HasKey(e => e.KitapId);

                entity.ToTable("Kitaplar");

                entity.HasIndex(e => e.YayinEviId, "IX_Kitaplar_YayinEviID");

                entity.HasIndex(e => e.YazarId, "IX_Kitaplar_YazarID");

                entity.Property(e => e.KitapId).HasColumnName("KitapID");

                entity.Property(e => e.BasimTarihi).HasColumnType("date");

                entity.Property(e => e.KapakResmi).HasMaxLength(30);

                entity.Property(e => e.KayitTarihi).HasColumnType("smalldatetime");

                entity.Property(e => e.KitapAdi)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Ozet).HasMaxLength(300);

                entity.Property(e => e.YayinEviId).HasColumnName("YayinEviID");

                entity.Property(e => e.YazarId).HasColumnName("YazarID");

                entity.HasOne(d => d.YayinEvi)
                    .WithMany(p => p.Kitaplars)
                    .HasForeignKey(d => d.YayinEviId);

                entity.HasOne(d => d.Yazar)
                    .WithMany(p => p.Kitaplars)
                    .HasForeignKey(d => d.YazarId);
            });

            modelBuilder.Entity<OduncVerme>(entity =>
            {
                entity.ToTable("OduncVerme");

                entity.HasIndex(e => e.KitapId, "IX_OduncVerme_KitapID");

                entity.HasIndex(e => e.UyeId, "IX_OduncVerme_UyeID");

                entity.Property(e => e.OduncVermeId).HasColumnName("OduncVermeID");

                entity.Property(e => e.KitapId).HasColumnName("KitapID");

                entity.Property(e => e.UyeId).HasColumnName("UyeID");

                entity.HasOne(d => d.Kitap)
                    .WithMany(p => p.OduncVermes)
                    .HasForeignKey(d => d.KitapId);

                entity.HasOne(d => d.Uye)
                    .WithMany(p => p.OduncVermes)
                    .HasForeignKey(d => d.UyeId);
            });

            modelBuilder.Entity<YayinEvleri>(entity =>
            {
                entity.HasKey(e => e.YayinEviId);

                entity.ToTable("YayinEvleri");

                entity.Property(e => e.YayinEviId).HasColumnName("YayinEviID");

                entity.Property(e => e.Eposta).HasColumnName("EPosta");
            });

            modelBuilder.Entity<Yazarlar>(entity =>
            {
                entity.HasKey(e => e.YazarId);

                entity.ToTable("Yazarlar");

                entity.Property(e => e.YazarId).HasColumnName("YazarID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
