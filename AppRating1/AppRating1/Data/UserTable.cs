using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppRating1.Data
{
    [Table("User")]
    public class UserTable
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }

        public virtual ICollection<RatingTable> Rating { get; set; }
        public ICollection<RatingViewModel> RatingViewModels { get; set; }
       
    }
}
