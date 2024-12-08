using Microsoft.EntityFrameworkCore;
using TrainReservationAPI.Models;

namespace TrainReservationAPI.Data
{
    public class TrainReservationContext : DbContext
    {
        public TrainReservationContext(DbContextOptions<TrainReservationContext> options) : base(options)
        {
        }

        // DbSet properties for each table
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Train> Trains { get; set; }


        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<WaitingList> WaitingLists { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define primary keys
            modelBuilder.Entity<Passenger>()
                .HasKey(p => p.Passenger_ID);



            modelBuilder.Entity<Reservation>()
              .HasKey(r => r.Reservation_No);

            // Define relationships
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Passenger)
                .WithMany()
                .HasForeignKey(r => r.Passenger_ID);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Train)
                .WithMany()
                .HasForeignKey(r => r.Train_ID);


            modelBuilder.Entity<WaitingList>()
                .HasOne(w => w.Passenger)
                .WithMany()
                .HasForeignKey(w => w.Passenger_ID);

            modelBuilder.Entity<WaitingList>()
                .HasOne(w => w.Train)
                .WithMany()
                .HasForeignKey(w => w.Train_ID);

        }

    }
}
