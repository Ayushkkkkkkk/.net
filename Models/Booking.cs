namespace TravelAgencyApp.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string PaymentStatus { get; set; }

        public int TourId { get; set; }
        public Tour Tour { get; set; }
    }
}

