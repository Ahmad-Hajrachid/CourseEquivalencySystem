using CourseEquivalencySite.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseEquivalencySite.Interfaces
{
    public interface IEquivalencyServices
    {
        public List<Institution> getInstitutions();
        public List<Major> getMajors(int id);
        public List<Course> getCourses(int institutionId,int majorId);
        public Course getCourse(int id);
        public bool addCourse(string courseNameAR, string courseNameEN, string courseDescreptionAR, string courseDescriptionEN, int courseWeightAR, int courseWeightEN, int institutionId, int majorId);
        public bool EditCourse(int id, string courseNameAR, string courseNameEN, string courseDescreptionAR, string courseDescriptionEN, int courseWeightAR, int courseWeightEN, int institutionId, int majorId);
        public bool deleteCourse(int id);


    }
}
