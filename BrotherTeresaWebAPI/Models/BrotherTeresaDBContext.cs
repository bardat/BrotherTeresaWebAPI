using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BrotherTeresaWebAPI.Models
{
    public partial class BrotherTeresaDBContext : DbContext
    {
        public BrotherTeresaDBContext()
        {
        }

        public BrotherTeresaDBContext(DbContextOptions<BrotherTeresaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblFinancialItem> TblFinancialItems { get; set; }
        public virtual DbSet<TblFood> TblFoods { get; set; }
        public virtual DbSet<TblFoodAvailable> TblFoodAvailables { get; set; }
        public virtual DbSet<TblLocation> TblLocations { get; set; }
        public virtual DbSet<TblLog> TblLogs { get; set; }
        public virtual DbSet<TblPerson> TblPeople { get; set; }
        public virtual DbSet<TblRequest> TblRequests { get; set; }
        public virtual DbSet<TblSupply> TblSupplies { get; set; }
        public virtual DbSet<TblSupplyAvailable> TblSupplyAvailables { get; set; }
        public virtual DbSet<TblWeather> TblWeathers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=BrotherTeresaDevDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblFinancialItem>(entity =>
            {
                entity.HasKey(e => e.FinancialItemId)
                    .HasName("PK__tblFinan__4C382B6A2A7F43F6");

                entity.ToTable("tblFinancialItem");

                entity.Property(e => e.FinancialItemId).HasColumnName("financialItemId");

                entity.Property(e => e.FinancialItemCashAmount).HasColumnName("financialItemCashAmount");

                entity.Property(e => e.FinancialItemDescription)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("financialItemDescription");

                entity.Property(e => e.FinancialItemDonor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("financialItemDonor");

                entity.Property(e => e.FinancialItemIsMoney)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("financialItemIsMoney");

                entity.Property(e => e.FinancialItemName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("financialItemName");
            });

            modelBuilder.Entity<TblFood>(entity =>
            {
                entity.HasKey(e => e.FoodId)
                    .HasName("PK__tblFood__77EAEA39F1316EA3");

                entity.ToTable("tblFood");

                entity.Property(e => e.FoodId).HasColumnName("foodId");

                entity.Property(e => e.FoodImgUrl)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("foodImgURL");

                entity.Property(e => e.FoodName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("foodName");

                entity.Property(e => e.LogId).HasColumnName("logId");

                entity.HasOne(d => d.Log)
                    .WithMany(p => p.TblFoods)
                    .HasForeignKey(d => d.LogId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_food");
            });

            modelBuilder.Entity<TblFoodAvailable>(entity =>
            {
                entity.HasKey(e => e.AFoodId)
                    .HasName("PK__tblFoodA__E81DEA90D1E54516");

                entity.ToTable("tblFoodAvailable");

                entity.Property(e => e.AFoodId).HasColumnName("aFoodId");

                entity.Property(e => e.AFoodImgUrl)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("aFoodImgURL");

                entity.Property(e => e.AFoodName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("aFoodName");
            });

            modelBuilder.Entity<TblLocation>(entity =>
            {
                entity.HasKey(e => e.LocationId)
                    .HasName("PK__tblLocat__30646B6E4D46B32B");

                entity.ToTable("tblLocation");

                entity.Property(e => e.LocationId).HasColumnName("locationId");

                entity.Property(e => e.LocationAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("locationAddress");

                entity.Property(e => e.LocationDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("locationDescription");

                entity.Property(e => e.LocationGps)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("locationGPS");

                entity.Property(e => e.LocationImageUrl)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("locationImageURL");

                entity.Property(e => e.LocationName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("locationName");

                entity.Property(e => e.LogId).HasColumnName("logId");

                entity.HasOne(d => d.Log)
                    .WithMany(p => p.TblLocations)
                    .HasForeignKey(d => d.LogId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_location");
            });

            modelBuilder.Entity<TblLog>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PK__tblLog__7839F64DF4BFE815");

                entity.ToTable("tblLog");

                entity.Property(e => e.LogId).HasColumnName("logId");

                entity.Property(e => e.LogDate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("logDate");

                entity.Property(e => e.LogShortName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("logShortName");
            });

            modelBuilder.Entity<TblPerson>(entity =>
            {
                entity.HasKey(e => e.PersonId)
                    .HasName("PK__tblPerso__EC7D7D4D9FD2AFAC");

                entity.ToTable("tblPerson");

                entity.Property(e => e.PersonId).HasColumnName("personId");

                entity.Property(e => e.LogId).HasColumnName("logId");

                entity.Property(e => e.PersonAge)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("personAge");

                entity.Property(e => e.PersonDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("personDescription");

                entity.Property(e => e.PersonGender)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("personGender");

                entity.Property(e => e.PersonHeight)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("personHeight");

                entity.Property(e => e.PersonImageUrl)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("personImageURL");

                entity.Property(e => e.PersonName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("personName");

                entity.Property(e => e.PersonNote)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("personNote");

                entity.Property(e => e.PersonRace)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("personRace");

                entity.Property(e => e.PersonWeight)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("personWeight");

                entity.HasOne(d => d.Log)
                    .WithMany(p => p.TblPeople)
                    .HasForeignKey(d => d.LogId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblPerson__logId__2B3F6F97");
            });

            modelBuilder.Entity<TblRequest>(entity =>
            {
                entity.HasKey(e => e.RequestId)
                    .HasName("PK__tblReque__E3C5DE313E9EAF68");

                entity.ToTable("tblRequest");

                entity.Property(e => e.RequestId).HasColumnName("requestId");

                entity.Property(e => e.PersonId).HasColumnName("personId");

                entity.Property(e => e.RequestDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("requestDescription");

                entity.Property(e => e.RequestItem)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("requestItem");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.TblRequests)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblReques__reque__2E1BDC42");
            });

            modelBuilder.Entity<TblSupply>(entity =>
            {
                entity.HasKey(e => e.SupplyId)
                    .HasName("PK__tblSuppl__EF30F880DF69CDB0");

                entity.ToTable("tblSupply");

                entity.Property(e => e.SupplyId).HasColumnName("supplyId");

                entity.Property(e => e.LogId).HasColumnName("logId");

                entity.Property(e => e.SupplyImgUrl)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("supplyImgURL");

                entity.Property(e => e.SupplyName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("supplyName");

                entity.HasOne(d => d.Log)
                    .WithMany(p => p.TblSupplies)
                    .HasForeignKey(d => d.LogId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_supply");
            });

            modelBuilder.Entity<TblSupplyAvailable>(entity =>
            {
                entity.HasKey(e => e.ASupplyId)
                    .HasName("PK__tblSuppl__3AD5AC8FE5C24126");

                entity.ToTable("tblSupplyAvailable");

                entity.Property(e => e.ASupplyId).HasColumnName("aSupplyId");

                entity.Property(e => e.ASupplyImgUrl)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("aSupplyImgURL");

                entity.Property(e => e.ASupplyName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("aSupplyName");
            });

            modelBuilder.Entity<TblWeather>(entity =>
            {
                entity.HasKey(e => e.WeatherId)
                    .HasName("PK__tblWeath__CFCB758D56D6DDEE");

                entity.ToTable("tblWeather");

                entity.Property(e => e.WeatherId).HasColumnName("weatherId");

                entity.Property(e => e.LogId).HasColumnName("logId");

                entity.Property(e => e.WeatherDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("weatherDescription");

                entity.Property(e => e.WeatherTemp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("weatherTemp");

                entity.HasOne(d => d.Log)
                    .WithMany(p => p.TblWeathers)
                    .HasForeignKey(d => d.LogId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_conditions");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
