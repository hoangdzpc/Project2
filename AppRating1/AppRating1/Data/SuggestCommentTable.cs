using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppRating1.Data
{
    [Table("SuggestComments")]
    public class SuggestCommentTable
    {
        [Key]
        public int Id { get; set; }
        public int RatedEntityId { get; set; } // Khóa ngoại đến bảng RatedEntity
        [Required]
        public string Comment { get; set; }

        [ForeignKey("RatedEntityId")]
        public  RatedEntityTable RatedEntity { get; set; }
    }
}
