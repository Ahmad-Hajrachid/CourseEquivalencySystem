namespace CourseEquivalencySite.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public int CourseWeight { get; set; }
        public string CourseInstitution { get; set; }
        public Course()
        {
            
        }
    }
}
