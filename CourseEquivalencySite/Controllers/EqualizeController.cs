using CourseEquivalencySite.Data;
using CourseEquivalencySite.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;


namespace CourseEquivalencySite.Controllers
{
    public class EqualizeController : Controller
    {
        private readonly IEquivalencyServices _services;

        public EqualizeController(IEquivalencyServices services)
        {
            _services = services;
        }
        public IActionResult Equalize()
        {
            var data = _services.getInstitutions();
          
            return View(data);
        }

        [HttpGet]
        public IActionResult getMajors(int id)
        {
            var data = _services.getMajors(id);

            return Ok(data);
        }
        [HttpGet]
        public IActionResult getInstitutions()
        {
            var data = _services.getInstitutions();

            return Ok(data);
        }
        [HttpGet]
        public IActionResult getCourses(int institutionId, int majorId)
        {
            var data = _services.getCourses(institutionId,majorId);

            return Ok(data);
        }
        public IActionResult equalizedCourses() {
            return View();
                }
    }

}
