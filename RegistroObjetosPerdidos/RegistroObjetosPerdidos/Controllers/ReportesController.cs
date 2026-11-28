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


        // Mostrar el formulario de edición
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reporte = await _context.Reportes.FindAsync(id);

            if (reporte == null)
            {
                return NotFound();
            }

            return View(reporte);
        }

        // Guardar los cambios del reporte
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Reporte reporte)
        {
            if (id != reporte.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Reportes.Update(reporte);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(reporte);
        }

        // Mostrar el formulario para cambiar el estado
        public async Task<IActionResult> UpdateStatus(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reporte = await _context.Reportes.FindAsync(id);

            if (reporte == null)
            {
                return NotFound();
            }

            return View(reporte);
        }

        // Guardar el nuevo estado
        [HttpPost]
        public async Task<IActionResult> UpdateStatus(int id, Reporte reporte)
        {
            var reporteExistente = await _context.Reportes.FindAsync(id);

            if (reporteExistente == null)
            {
                return NotFound();
            }

            if (reporte.Estado != "Pendiente" &&
                reporte.Estado != "Reclamado" &&
                reporte.Estado != "Devuelto")
            {
                return BadRequest();
            }

            reporteExistente.Estado = reporte.Estado;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }

}