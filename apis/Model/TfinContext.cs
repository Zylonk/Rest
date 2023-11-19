using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace apis.Model;

public partial class TfinContext : DbContext
{
    public TfinContext()
    {
    }

    public TfinContext(DbContextOptions<TfinContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adminrestaurant> Adminrestaurants { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Food> Foods { get; set; }

    public virtual DbSet<GuestInfo> GuestInfos { get; set; }

    public virtual DbSet<Restaurant> Restaurants { get; set; }

    public virtual DbSet<TablesInRestaurant> TablesInRestaurants { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseLazyLoadingProxies().UseNpgsql("Host=localhost;Port=5432;Database=TFin;Username=postgres;Password=postgres");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Adminrestaurant>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("adminrestaurant_pkey");

            entity.ToTable("adminrestaurant", "TdFin");

            entity.Property(e => e.AdminId).HasColumnName("AdminID");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("Booking_pkey");

            entity.ToTable("Booking", "TdFin");

            entity.Property(e => e.BookingVisitsofdata).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.BookingGuestInfoNavigation).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.BookingGuestInfo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GuestInfo");

            entity.HasOne(d => d.BookingRestaurantNavigation).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.BookingRestaurant)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Restaurant");
        });

        modelBuilder.Entity<Food>(entity =>
        {
            entity.HasKey(e => e.FoodId).HasName("Food_pkey");

            entity.ToTable("Food", "TdFin");

            entity.Property(e => e.FoodId).HasColumnName("FoodID");
        });

        modelBuilder.Entity<GuestInfo>(entity =>
        {
            entity.HasKey(e => e.GuestId).HasName("GuestInfo_pkey");

            entity.ToTable("GuestInfo", "TdFin");

            entity.Property(e => e.GuestId).HasColumnName("GuestID");
        });

        modelBuilder.Entity<Restaurant>(entity =>
        {
            entity.HasKey(e => e.RestaurantId).HasName("Restaurant_pkey");

            entity.ToTable("Restaurant", "TdFin");

            entity.HasOne(d => d.RestaurantAdmin).WithMany(p => p.Restaurants)
                .HasForeignKey(d => d.RestaurantAdminId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Admin");

            entity.HasOne(d => d.RestaurantFoodNavigation).WithMany(p => p.Restaurants)
                .HasForeignKey(d => d.RestaurantFood)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Food");

            entity.HasOne(d => d.RestaurantTablesStatusNavigation).WithMany(p => p.Restaurants)
                .HasForeignKey(d => d.RestaurantTablesStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tables");
        });

        modelBuilder.Entity<TablesInRestaurant>(entity =>
        {
            entity.HasKey(e => e.TableId).HasName("TablesInRestaurant_pkey");

            entity.ToTable("TablesInRestaurant", "TdFin");

            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.TableStatus)
                .IsRequired()
                .HasDefaultValueSql("true");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
