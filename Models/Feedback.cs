namespace TravelAgencyApp.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Comment { get; set; }
        public DateTime SubmittedAt { get; set; }
    }
}

