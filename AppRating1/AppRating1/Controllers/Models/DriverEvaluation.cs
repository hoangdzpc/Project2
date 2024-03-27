namespace AppRating1.Controllers.Models
{
    public class DriverEvaluation
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }  //Rating from 1 to 5 stars
        public string Comment { get; set; } // User's comment
    }
}