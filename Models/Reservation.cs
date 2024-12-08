namespace TrainReservationAPI.Models
{
    public class Reservation
    {
        public int Reservation_No { get; set; }
        public int Passenger_ID { get; set; }
        public int Train_ID { get; set; }
        public string Status { get; set; } // Confirmed, Temporary, or Canceled
        public DateTime? Expiry_Date { get; set; }

        // Navigation properties
        public Passenger Passenger { get; set; }
        public Train Train { get; set; }
    }
}