using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppRating1.Data
{
    [Table("ServiceType")]
    public class ServiceTypeTable
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<RatedEntityTable> RatedEntity { get; set;}
    }
}
