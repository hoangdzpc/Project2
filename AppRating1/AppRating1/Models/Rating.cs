namespace AppRating1.Controllers.Models
{
    public class Rating
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; } // Khóa ngoại đến bảng User
        public Guid RatedEntityId { get; set; } // Khóa ngoại đến bảng RatedEntity
        public int RatingValue { get; set; }
        public string Comment { get; set; }
    }
}
