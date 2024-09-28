using BitsOrchestraTestApp.Dtos;
using BitsOrchestraTestApp.Models;
using BitsOrchestraTestApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BitsOrchestraTestApp.Controllers
{
    [Route("person")]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet("upload")]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                ModelState.AddModelError("", "Please upload a file.");
                return View();
            }

            if (file.ContentType != "text/csv" && file.ContentType != "application/vnd.ms-excel")
            {
                ModelState.AddModelError("", "Please upload a valid CSV file.");
                return View();
            }

            try
            {
                await _personService.UploadPersonsFromCsvAsync(file.OpenReadStream());
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "CSV file's data is invalid");
                return View();
            }

            return RedirectToAction("Index");
        }

        [HttpGet("index")]
        [Route("/")]
        public async Task<IActionResult> Index()
        {
            var persons = await _personService.GetAllPersonsAsync();
            Console.WriteLine(persons != null ? $"{persons.Count} persons found." : "Persons is null");
            return View(persons);
        }

        [HttpPost("edit")]
        public async Task<IActionResult> Edit([FromBody] PersonDto personDto)
        {
            await _personService.EditPersonAsync(personDto);
            return Ok();
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            await _personService.DeletePersonAsync(id);
            return Ok();
        }
    }
}
