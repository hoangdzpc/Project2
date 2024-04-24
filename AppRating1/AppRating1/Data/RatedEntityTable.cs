using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppRating1.Data
{
    [Table("RatedEntity")]
    public class RatedEntityTable
    {
        [Key]
        public int Id { get; set; }

        public int ServiceTypeId { get; set; } // Khóa ngoại đến bảng ServiceType
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [ForeignKey("ServiceTypeId")]
        public ServiceTypeTable ServiceType { get; set; }

        public virtual ICollection<RatingTable> Ratings { get; set; }
        public virtual ICollection<SuggestCommentTable> SuggestComments { get; set; }
        public ICollection<RatingViewModel> RatingViewModels { get; set; }
       
        public RatedEntityTable()
        {
            Ratings = new List<RatingTable>();
            SuggestComments = new List<SuggestCommentTable>();
            RatingViewModels = new List<RatingViewModel>();
        }
    }
}
