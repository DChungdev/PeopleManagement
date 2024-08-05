using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PersonManagement.Common.Entities;
using PersonManagement.Web.Models;
using System.Net.Http.Headers;

namespace PersonManagement.Web.Controllers
{
    public class PersonController : Controller
    {
        private readonly HttpClient _client;

        public PersonController()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44360/api"),
                DefaultRequestHeaders =
            {
                Accept = { new MediaTypeWithQualityHeaderValue("application/json") }
            }
            };
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync("/Persons/GetPersons");
                response.EnsureSuccessStatusCode();

                string data = await response.Content.ReadAsStringAsync();
                var persons = JsonConvert.DeserializeObject<List<Person>>(data);

                // Convert to ViewModels
                var viewModels = persons.Select(person =>
                {
                    if (person is Student s)
                    {
                        return new PersonViewModel
                        {
                            Id = s.Id,
                            Name = s.Name,
                            PhoneNumber = s.PhoneNumber,
                            EmailAddress = s.EmailAddress,
                            Address = s.Address == null ? "No Address" : $"{s.Address.Name}, {s.Address.Number}",
                            Role = "Student"
                        };
                    }
                    if (person is Professor p)
                    {
                        return new PersonViewModel
                        {
                            Id = p.Id,
                            Name = p.Name,
                            PhoneNumber = p.PhoneNumber,
                            EmailAddress = p.EmailAddress,
                            Address = p.Address == null ? "No Address" : $"{p.Address.Name}, {p.Address.Number}",
                            Role = "Professor"
                        };
                    }
                    return null; // Default case if no match
                }).ToList();

                return View(viewModels);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request error: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }


}
