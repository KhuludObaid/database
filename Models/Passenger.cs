namespace TrainReservationAPI.Models
{
    public class Passenger
    {
        public int Passenger_ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Miles_Travelled { get; set; }
        public string Loyalty_Class { get; set; }
    }
}