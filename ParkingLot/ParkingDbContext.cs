using Microsoft.EntityFrameworkCore;

namespace ParkingLot
{
    internal class ParkingDbContext : DbContext
    {
        public DbSet<ParkingLot> ParkingLot { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Car> Car { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<CarAuthor> CarAuthor { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optimionsBullder)
        {
            optimionsBullder.UseSqlServer(@"Server = S-TIGINASHVILI\MSSQLSERVER01; Database = ParkingSlot; Trusted_Connection=True; Encrypt=false");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParkingLot>()
                .HasOne(x => x.Address)
                .WithOne()
                .HasForeignKey<ParkingLot>(x => x.AddressId);

            //

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();
                entity.HasMany(e => e.CarAuthor)
                    .WithOne(e => e.Car)
                    .HasForeignKey(e => e.BookId);
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();
                entity.HasMany(e => e.CarAuthor)
                    .WithOne(e => e.Author)
                    .HasForeignKey(e => e.AuthorId);
            });

            modelBuilder.Entity<CarAuthor>(entity =>
            {
                entity.HasKey(e => new { e.BookId, e.AuthorId });
                entity.HasOne(e => e.Car)
                    .WithMany(e => e.CarAuthor)
                    .HasForeignKey(e => e.AuthorId);
            });
        }

    }
}
