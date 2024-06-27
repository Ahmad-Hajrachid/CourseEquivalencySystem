using CourseEquivalencySite.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseEquivalencySite.Interfaces
{
    public interface ICourseSimilarityService
    {
        Task<List<CourseSimilarityResult>> GetCourseSimilaritiesAsync();
    }
}
