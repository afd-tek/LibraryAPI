using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LibraryAPI.Models
{
    public partial class libraryContext : DbContext
    {
        public libraryContext()
        {
        }

        public libraryContext(DbContextOptions<libraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Debts> Debts { get; set; }
        public virtual DbSet<Rooms> Rooms { get; set; }
        public virtual DbSet<Tables> Tables { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=Ahmet;database=library;User Id=sa;Password=1908");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Desk)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.State).HasColumnType("date");

                entity.HasOne(d => d.TakerNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.Taker)
                    .HasConstraintName("FK__Book__Taker__403A8C7D");
            });

            modelBuilder.Entity<Debts>(entity =>
            {
                entity.HasKey(e => e.Debtor)
                    .HasName("PK_Debt");

                entity.Property(e => e.Debtor)
                    .HasColumnName("debtor")
                    .ValueGeneratedNever();

                entity.Property(e => e.DebtQuantity)
                    .HasColumnName("debtQuantity")
                    .HasColumnType("money");

                entity.HasOne(d => d.DebtorNavigation)
                    .WithOne(p => p.Debts)
                    .HasForeignKey<Debts>(d => d.Debtor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Debt_Users");
            });

            modelBuilder.Entity<Rooms>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<Tables>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.HasOne(d => d.OwnerNavigation)
                    .WithMany(p => p.Tables)
                    .HasForeignKey(d => d.Owner)
                    .HasConstraintName("FK_Tables_Users");

                entity.HasOne(d => d.RoomNavigation)
                    .WithMany(p => p.Tables)
                    .HasForeignKey(d => d.Room)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tables_Rooms");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.StudentNumber)
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Tckimlik)
                    .IsRequired()
                    .HasColumnName("TCKimlik")
                    .HasMaxLength(11);

                entity.Property(e => e.Utype).HasColumnName("UType");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
