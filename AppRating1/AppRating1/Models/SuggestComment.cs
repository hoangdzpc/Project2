namespace AppRating1.Models
{
    public class SuggestComment
    {
        public int RatedEntityId { get; set; } // Khóa ngoại đến bảng RatedEntity
        public string Comment { get; set; }
    }
}
