using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Data;
using WebApplication1.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IActionResult> Index()
        {//OFERTAS: productos marca nike, PRODUCTOSB: productos precio menor a 5
            var ofertas = await _context.Producto
                .Where(td => td.marca == "nike")
                .ToListAsync();
            var productosB = await _context.Producto
                .Where(td => td.precio < 5)
                .ToListAsync();
            return View(productosB);
        }

        [HttpPost]
        public async Task<IActionResult> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                // Si el t�rmino de b�squeda est� vac�o, podr�as redirigir a la p�gina principal o mostrar un mensaje de error.
                return RedirectToAction("Index");
            }

            // L�gica para buscar productos por el t�rmino de b�squeda
            var productosEncontrados = await _context.Producto
                .Where(p => p.nombre.Contains(searchTerm))
                .ToListAsync();

            return View("Index",productosEncontrados);
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
