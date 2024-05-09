using CourseEquivalencySite.Data;
using CourseEquivalencySite.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    }
}
