namespace TrainReservationAPI.Models
{
    public class WaitingList
    {
        public int Waiting_List_ID { get; set; }
        public int Passenger_ID { get; set; }
        public int Train_ID { get; set; }
        public int Position { get; set; }

        // Navigation properties
        public Passenger Passenger { get; set; }
        public Train Train { get; set; }
    }
}