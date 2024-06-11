using Microsoft.AspNetCore.Mvc;

namespace CourseEquivalencySite.Controllers
{
    public class AdminPageController : Controller
    {
       public IActionResult index()
        {
            return View();
        }
    }
}
