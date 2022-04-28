using Microsoft.AspNetCore.Mvc;
using PruebaWTW.Web.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PruebaWTW.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly HttpClient _httpClient;

        public UsuarioController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient.CreateClient("myApi");
        }

        public async Task<IActionResult> Index()
        {
            var resultado = await _httpClient.GetAsync("/api/Usuario");
            var modelResultado = await resultado.Content.ReadAsAsync<IEnumerable<UsuarioModel>>(new[] { new JsonMediaTypeFormatter() });
            return View(modelResultado);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(UsuarioModel usuarioModel)
        {
            if (ModelState.IsValid)
            {
                var resultado = await _httpClient.PostAsJsonAsync("/api/Usuario", usuarioModel);
                var modelResultado = await resultado.Content.ReadAsAsync<UsuarioModel>(new[] { new JsonMediaTypeFormatter() });
                return RedirectToAction("Index");
            }
            else
            {
                return View(usuarioModel);
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var resultado = await _httpClient.PostAsJsonAsync("/api/Usuario/validar", model);
                    var modelResultado = await resultado.Content.ReadAsAsync<LoginModel>(new[] { new JsonMediaTypeFormatter() });
                    TempData["UsuarioActual"] = modelResultado.NombreUsuario;
                    return RedirectToAction("Welcome", "Usuario");
                }
                catch (System.Exception)
                {
                    TempData["UsuarioActual"] = null;
                    return RedirectToAction("Welcome", "Usuario");

                }
            }
            else
            {
                return View(model);
            }
        }

        public IActionResult Welcome(LoginModel model)
        {
            return View(model);
        }
    }
}