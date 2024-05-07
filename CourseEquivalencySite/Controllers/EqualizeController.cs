using Microsoft.AspNetCore.Mvc;

namespace CourseEquivalencySite.Controllers
{
    public class EqualizeController : Controller
    {
        public IActionResult Equalize()
        {
            return View();
        }
    }
}
