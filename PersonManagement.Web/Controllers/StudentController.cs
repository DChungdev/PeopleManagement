using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PersonManagement.Web.Models;

namespace PersonManagement.Web.Controllers
{
    public class StudentController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44360/api");
        private readonly HttpClient _client;

        public StudentController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        public async Task<IActionResult> Index()
        {
            List<StudentViewModel> list = new List<StudentViewModel>();
            try
            {
                HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + "/Students/GetStudents");
                response.EnsureSuccessStatusCode();

                string data = await response.Content.ReadAsStringAsync();
                list = JsonConvert.DeserializeObject<List<StudentViewModel>>(data);
            }
            catch (HttpRequestException ex)
            {
                // Log error (ex.Message) and/or display an error message to the user
                Console.WriteLine($"Request error: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Log error (ex.Message) and/or display an error message to the user
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }

            return View(list);
        }
    }
}
