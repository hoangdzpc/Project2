namespace AppRating1.Controllers.Models
{
    public class SuggestComment
    {
        public Guid Id { get; set; }
        public Guid RatedEntityId { get; set; } // Khóa ngoại đến bảng RatedEntity
        public string Comment { get; set; }
    }
}
