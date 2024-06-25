using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Data;
using WebApplication1.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Migrations;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Usuario model)
        {
                var admin = AdminService.ObtenerAdmin();

                if (model.User == admin.User && model.Password == admin.Password)
                {
                    // Iniciar sesión para el usuario administrador
                    var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, model.User),
                            new Claim(ClaimTypes.Role, "Admin"), // Opcional: asignar roles
                        };

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var authProperties = new AuthenticationProperties
                        {
                            IsPersistent = true, // Opcional: hacer la sesión persistente
                        };

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties).Wait();

                    TempData["AlertMessage"] = "¡Login exitoso!";
                    return RedirectToAction("Index", "Home"); // Redirigir al área administrativa
                }
                else
                {
                    ModelState.AddModelError("", "Credenciales incorrectas");
                return View("~/Views/Productos/NoProductos.cshtml");
                }
          
        }

        public async Task<IActionResult> Index()
        {
            var productosDestacados = await _context.Producto
                .Where(td => td.destacar == true)
                .ToListAsync();
            return View(productosDestacados);
        }

        [HttpPost]
        public async Task<IActionResult> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                // Si el término de búsqueda está vacío, podrías redirigir a la página principal o mostrar un mensaje de error.
                ViewData["Mensaje"] = "No se encontraron productos";
                return View("~/Views/Productos/NoProductos.cshtml");
            }

            // Lógica para buscar productos por el término de búsqueda
            var productosEncontrados = await _context.Producto
                .Where(p => p.nombre.StartsWith(searchTerm))
                .ToListAsync();
            if(productosEncontrados.Count == 0)
            {
                ViewData["Mensaje"] = "No se encontraron productos";
                return View("~/Views/Productos/NoProductos.cshtml");
            }
            return View("~/Views/Productos/VistaBusqueda.cshtml", productosEncontrados);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
