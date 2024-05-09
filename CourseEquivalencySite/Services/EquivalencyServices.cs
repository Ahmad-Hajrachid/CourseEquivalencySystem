using CourseEquivalencySite.Data;
using CourseEquivalencySite.Interfaces;
using CourseEquivalencySite.Models;

namespace CourseEquivalencySite.Services
{
    public class EquivalencyServices : IEquivalencyServices
    {
        private readonly ApplicationDbContext _context;

        public EquivalencyServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Institution> getInstitutions()
        {
            return _context.institutions.ToList();
        }

        public List<Major> getMajors()
        {
            return _context.majors.ToList();
        }
    }
}
