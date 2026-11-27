using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistroObjetosPerdidos.Data;
using RegistroObjetosPerdidos.Models;

namespace RegistroObjetosPerdidos.Controllers
{
    public class ReportesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Mostrar todos los reportes
        public async Task<IActionResult> Index()
        {
            var reportes = await _context.Reportes.ToListAsync();
            return View(reportes);
        }


        // Mostrar el formulario para registrar un objeto
        public IActionResult Create()
        {
            return View();
        }

        // Guardar el nuevo reporte
        [HttpPost]
        public async Task<IActionResult> Create(Reporte reporte)
        {
            if (ModelState.IsValid)
            {
                _context.Reportes.Add(reporte);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(reporte);
        }

    }

}