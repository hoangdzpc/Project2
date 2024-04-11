namespace AppRating1.Models
{
    public class Rating
    {
        public int UserId { get; set; } // Khóa ngoại đến bảng User
        public int RatedEntityId { get; set; } // Khóa ngoại đến bảng RatedEntity
        public int RatingValue { get; set; }
        public string Comment { get; set; }
    }
}
