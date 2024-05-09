using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseEquivalencySite.Models
{
    public class Course
    {
        public int courseID { get; set; }
        public String courseName { get; set; }
        public String courseDescription { get; set; }
        public int courseWeight { get; set; }
        [Required]
        [ForeignKey("institutionId")]
        public int institutionId { get; set; }
        public Institution institution { get; set; }
        [Required]
        [ForeignKey("majorId")]
        public int majorId { get; set; }
    }
}
