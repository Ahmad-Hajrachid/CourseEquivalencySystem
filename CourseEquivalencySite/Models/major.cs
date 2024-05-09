using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseEquivalencySite.Models
{
    public class Major
    {
        public int majorID { get; set; }
        public String majorName { get; set; }
        [Required]
        [ForeignKey("InstitutionId")]
        public int institutionId { get; set; }
    }
}
