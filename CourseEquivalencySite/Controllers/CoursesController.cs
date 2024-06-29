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
using System.Net.Http;
using System.Text.Json;
using System.Text;
using Humanizer;
using Newtonsoft.Json;
using static IronPython.Runtime.Profiler;
using JsonSerializer = System.Text.Json.JsonSerializer;

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

        [HttpGet]
        public async Task<IActionResult> GetGetSimilarity()
        {
            var serializerOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };



            try
            {

                using (var http = new HttpClient())
                {
                    var request = new HttpRequestMessage(HttpMethod.Get, "http://127.0.0.1:5000/api/courses/similarity");
                    var content = new StringContent(string.Empty, Encoding.UTF8, "application/json");

                    request.Content = content;
                    var response = await http.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        if (!string.IsNullOrEmpty(data))
                        {
                            return Json(data, serializerOptions);

                        }




                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in GetSimilarity: {ex.Message}");
                return StatusCode(500, new { error = ex.Message });
            }
            return Json("");
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
        public IActionResult Create(string courseNameAR, string courseNameEN, string courseDescriptionAR, string courseDescriptionEN, int courseWeightAR, int courseWeightEN, int institutionId, int majorId)
        {
            _services.addCourse(courseNameAR, courseNameEN, courseDescriptionAR, courseDescriptionEN,courseWeightAR,courseWeightEN,institutionId, majorId);
            return RedirectToAction(nameof(index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var course = _context.course.Include(x => x.institution).Include(x => x.major).FirstOrDefault(x => x.courseID == id);

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

public class CourseComparisonResult
{
    public CourseInfo MiddleEastUniversity { get; set; }
    public CourseInfo ZaytounehUniversity { get; set; }
    public double SimilarityScore { get; set; }
}

public class CourseInfo
{
    public int CourseID { get; set; }
    public string CourseName { get; set; }
    public string CourseDescription { get; set; }
}