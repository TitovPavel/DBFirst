using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DBFirst.Models
{
    public partial class MyPartiesContext : DbContext
    {
        public MyPartiesContext()
        {
        }

        public MyPartiesContext(DbContextOptions<MyPartiesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<Participants> Participants { get; set; }
        public virtual DbSet<Parties> Parties { get; set; }
        public virtual DbSet<Sponsors> Sponsors { get; set; }
        public virtual DbSet<SponsorsParties> SponsorsParties { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=MyParties;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contacts>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Images>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasColumnName("fileName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ImageData)
                    .IsRequired()
                    .HasColumnName("imageData");
            });

            modelBuilder.Entity<Participants>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ArrivalDate)
                    .HasColumnName("arrivalDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('2019-11-30')");

                entity.Property(e => e.Attend).HasColumnName("attend");

                entity.Property(e => e.AvatarId).HasColumnName("avatarId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PartyId).HasColumnName("partyId");

                entity.Property(e => e.Reason)
                    .IsRequired()
                    .HasColumnName("reason")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Avatar)
                    .WithMany(p => p.Participants)
                    .HasForeignKey(d => d.AvatarId)
                    .HasConstraintName("FK__Participa__avata__6E565CE8");

                entity.HasOne(d => d.Party)
                    .WithMany(p => p.Participants)
                    .HasForeignKey(d => d.PartyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Participa__party__6F4A8121");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Participants)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Participa__userI__703EA55A");
            });

            modelBuilder.Entity<Parties>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasColumnName("location")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerId).HasColumnName("ownerId");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Parties)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Parties__ownerId__67A95F59");
            });

            modelBuilder.Entity<Sponsors>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasColumnName("location")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LogoId).HasColumnName("logoId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Sponsors)
                    .HasForeignKey<Sponsors>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sponsors__id__63D8CE75");

                entity.HasOne(d => d.Logo)
                    .WithMany(p => p.Sponsors)
                    .HasForeignKey(d => d.LogoId)
                    .HasConstraintName("FK__Sponsors__logoId__64CCF2AE");
            });

            modelBuilder.Entity<SponsorsParties>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PartyId).HasColumnName("partyId");

                entity.Property(e => e.SponsorId).HasColumnName("sponsorId");

                entity.HasOne(d => d.Party)
                    .WithMany(p => p.SponsorsParties)
                    .HasForeignKey(d => d.PartyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SponsorsP__party__6A85CC04");

                entity.HasOne(d => d.Sponsor)
                    .WithMany(p => p.SponsorsParties)
                    .HasForeignKey(d => d.SponsorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SponsorsP__spons__6B79F03D");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Birthday)
                    .HasColumnName("birthday")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fio)
                    .IsRequired()
                    .HasColumnName("FIO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Role).HasColumnName("role");
            });
        }
    }
}
