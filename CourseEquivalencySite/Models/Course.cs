using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseEquivalencySite.Models
{
    public class Course
    {
        public int courseID { get; set; }
        public String? courseNameAR { get; set; }
        public String? courseNameEN { get; set; }
        public String? courseDescriptionAR { get; set; }
        public String? courseDescriptionEN { get; set; }
        public int? courseWeightAR { get; set; }
        public int? courseWeightEN { get; set; } 
        public int? institutionId { get; set; }
        public Institution? institution { get; set; }
        public int? majorId { get; set; }
        public Major? major { get; set; }
        public bool? isDeleted { get; set; }

    }
}
