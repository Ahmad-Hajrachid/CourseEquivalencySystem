using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CourseEquivalencySite.Data;
using CourseEquivalencySite.Models;
using CourseEquivalencySite.Interfaces;

namespace CourseEquivalencySite.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IEquivalencyServices _services;

        public CoursesController(ApplicationDbContext context, IEquivalencyServices services)
        {
            _context = context;
            _services = services;
        }
        public IActionResult index()
        {
            var data =_services.getInstitutions();
            return View(data);
        }
        public IActionResult details(int id)
        {
            var data = _services.getCourse(id);

            return View(data);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(string courseNameAR, string courseNameEN, string courseDescreptionAR, string courseDescreptionEN, int courseWeightAR, int courseWeightEN, int institutionId, int majorId)
        {
            _services.addCourse(courseNameAR, courseNameEN, courseDescreptionAR, courseDescreptionEN,courseWeightAR,courseWeightEN,institutionId,majorId);
            return RedirectToAction(nameof(index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.course.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, string courseNameAR, string courseNameEN, string courseDescreptionAR, string courseDescreptionEN, int courseWeightAR, int courseWeightEN, int institutionId, int majorId)
        {
            _services.EditCourse(id, courseNameAR, courseNameEN, courseDescreptionAR, courseDescreptionEN, courseWeightAR, courseWeightEN, institutionId, majorId);
            return RedirectToAction(nameof(index));
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
             _services.deleteCourse(id);
            return Json(new { success = true });

        }



    }
}
