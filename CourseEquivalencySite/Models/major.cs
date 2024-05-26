using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseEquivalencySite.Models
{
    public class Major
    {
        public int majorID { get; set; }
        public String majorNameAR { get; set; }
        public String majorNameEN { get; set; }
        [Required]
        [ForeignKey("institutionId")]
        public int? institutionId { get; set; }
        public Institution institution { get; set; }
        public bool isDeleted { get; set; }

    }
}
