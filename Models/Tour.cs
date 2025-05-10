using System.Text.Json.Serialization;
using TravelAgencyApp.Models;

namespace TravelAgencyApp.Models
{
    public class Tour
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Capacity { get; set; }
        public string? ImagePath { get; set; }

        public int ProfileId { get; set; }
        public Profile Profile { get; set; }

        [JsonIgnore]
        public ICollection<Booking> Bookings { get; set; }
    }
}

