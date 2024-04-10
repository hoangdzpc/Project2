namespace AppRating1.Controllers.Models
{
    public class RatedEntity
    {
        public Guid Id { get; set; }
        public Guid ServiceTypeId { get; set; } // Khóa ngoại đến bảng ServiceType
        public string Name { get; set; }
    }
}