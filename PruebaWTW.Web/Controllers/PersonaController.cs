using Microsoft.AspNetCore.Mvc;
using PruebaWTW.Web.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace PruebaWTW.Web.Controllers
{
    public class PersonaController : Controller
    {
        private readonly HttpClient _httpClient;

        public PersonaController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("myApi");
        }

        public async Task<IActionResult> Index()
        {
            var resultado = await _httpClient.GetAsync("/api/Persona");
            var modelResultado = await resultado.Content.ReadAsAsync<IEnumerable<PersonaModel>>(new[] { new JsonMediaTypeFormatter() });
            return View(modelResultado);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(PersonaModel personaModel)
        {
            if (ModelState.IsValid)
            {
                var resultado = await _httpClient.PostAsJsonAsync("/api/Persona", personaModel);
                var modelResultado = await resultado.Content.ReadAsAsync<PersonaModel>(new[] { new JsonMediaTypeFormatter() });
                return RedirectToAction("Index");
            }
            else
            {
                return View(personaModel);
            }
        }
    }
}