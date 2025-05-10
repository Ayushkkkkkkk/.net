using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TravelAgencyApp.Models
{
    public class Profile
    {
        public int Id { get; set; }

        public string AgencyName { get; set; }

        public string ContactEmail { get; set; }

        public string Description { get; set; }

        [JsonIgnore]
        public ICollection<Tour> Tours { get; set; } = new List<Tour>();
    }
}

