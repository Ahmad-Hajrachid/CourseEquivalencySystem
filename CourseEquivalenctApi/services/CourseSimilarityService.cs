using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CourseEquivalencySite.Models;
using CourseEquivalencySite.Interfaces;

namespace CourseEquivalencySite.Services
{
    public class CourseSimilarityService : ICourseSimilarityService
    {
        private readonly HttpClient _httpClient;

        public CourseSimilarityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CourseSimilarityResult>> GetCourseSimilaritiesAsync()
        {
            var response = await _httpClient.GetAsync("http://127.0.0.1:5000/course_similarity");
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<CourseSimilarityResult>>(jsonResponse);

            return result;
        }
    }
}
