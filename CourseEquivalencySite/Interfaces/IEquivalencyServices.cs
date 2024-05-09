using CourseEquivalencySite.Models;

namespace CourseEquivalencySite.Interfaces
{
    public interface IEquivalencyServices
    {
        public List<Institution> getInstitutions();
        public List<Major> getMajors();
    }
}
