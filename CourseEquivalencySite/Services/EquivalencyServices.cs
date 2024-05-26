using CourseEquivalencySite.Data;
using CourseEquivalencySite.Interfaces;
using CourseEquivalencySite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseEquivalencySite.Services
{
    public class EquivalencyServices : IEquivalencyServices
    {
        private readonly ApplicationDbContext _context;

        public EquivalencyServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public Course getCourse(int id)
        {
            var data = _context.course.Find(id);
            return data;
        }

        public List<Course> getCourses(int institutionId, int majorId)
        {
            List<Course> data = _context.course.Where(i => i.isDeleted == false && i.institutionId == institutionId && i.majorId == majorId).Include(i => i.institution).Include(m => m.major).ToList();
            return data;
        }

        public List<Institution> getInstitutions()
        {
            List<Institution> data = _context.institutions.Where(i => i.isDeleted == false).ToList();
            return data;
        }

        public List<Major> getMajors(int id)
        {
            List<Major> data = _context.majors.Where(i => i.isDeleted == false && i.institutionId == id).Include(i => i.institution).ToList();

            return data;
        }
        [HttpPost]
        public bool addCourse(string courseNameAR, string courseNameEN, string courseDescriptionAR, string courseDescriptionEN, int courseWeightAR, int courseWeightEN, int institutionId, int majorId)
        {
            if (string.IsNullOrEmpty(courseNameAR) || string.IsNullOrEmpty(courseNameEN) || string.IsNullOrEmpty(courseDescriptionAR) || string.IsNullOrEmpty(courseDescriptionEN))
            {
                return false;
            }

            var newData = new Course
            {
                courseNameAR = courseNameAR,
                courseNameEN = courseNameEN,
                courseDescriptionAR = courseDescriptionAR,
                courseDescriptionEN = courseDescriptionEN,
                courseWeightAR = courseWeightAR,
                courseWeightEN = courseWeightEN,
                institutionId = institutionId,
                majorId = majorId,
                isDeleted = false
            };
            _context.course.Add(newData);
            _context.SaveChanges();
           
                return true;
            }

        public bool EditCourse(int id, string courseNameAR, string courseNameEN, string courseDescriptionAR, string courseDescriptionEN, int courseWeightAR, int courseWeightEN, int institutionId, int majorId)
        {
            if (string.IsNullOrEmpty(courseNameAR) || string.IsNullOrEmpty(courseNameEN) || string.IsNullOrEmpty(courseDescriptionAR) || string.IsNullOrEmpty(courseDescriptionEN))
            {
                return false;
            }
            Course newData = _context.course.Find(id);

            newData.courseNameAR = courseNameAR;
                newData.courseNameEN = courseNameEN;
                newData.courseDescriptionAR = courseDescriptionAR;
                newData.courseDescriptionEN = courseDescriptionEN;
                newData.courseWeightAR = courseWeightAR;
                newData.courseWeightEN = courseWeightEN;
                newData.institutionId = institutionId;
            newData.majorId = majorId;
            _context.course.Update(newData);
            _context.SaveChanges();

            return true;
        }


        bool IEquivalencyServices.deleteCourse(int id)
        {

            Course course =  _context.course.Find(id);
            course.isDeleted = true;
            if (course != null)
            {
                _context.course.Update(course);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
    }
