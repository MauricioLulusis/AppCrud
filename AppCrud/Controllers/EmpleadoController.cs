using Microsoft.AspNetCore.Mvc;

using AppCrud.Data;
using AppCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace AppCrud.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public EmpleadoController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            List<Empleado> lista = await _appDbContext.Empleados.ToListAsync();
            return View(lista);

        }
        [HttpGet]  //el get devuelve una vista 
        public IActionResult Nuevo()
        {
            return View();
        }

        [HttpPost] //el post va a recibir los valores de la vista Nuevo
        public async Task<IActionResult> Nuevo(Empleado empleado)
        {
            await _appDbContext.Empleados.AddAsync(empleado);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int Id)
        {
            Empleado empleado = await _appDbContext.Empleados.FirstAsync(e => e.IdEmpleado == Id);
            return View(empleado);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(Empleado empleado)
        {
            _appDbContext.Empleados.Update(empleado);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }
        [HttpGet]
        public async Task<IActionResult> Eliminar(int Id)
        {
            Empleado empleado = await _appDbContext.Empleados.FirstAsync(e=>e.IdEmpleado==Id);
            _appDbContext.Empleados.Remove(empleado);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }
    }
}
