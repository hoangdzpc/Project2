using AppRating1.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppRating1.Data
{
    [Table("Rating")]
    public class RatingTable
    {
        [Key]
        public int Id { get; set; }

        public int RatingValue { get; set; }
        public int UserId { get; set; } // Khóa ngoại đến bảng User
        public int RatedEntityId { get; set; } // Khóa ngoại đến bảng RatedEntity
        [Required]
        public string Comment { get; set; }



        [ForeignKey("UserId")]
        public UserTable User { get; set; }

        [ForeignKey("RatedEntityId")]
        public RatedEntityTable RatedEntity { get; set; }
    }
}
