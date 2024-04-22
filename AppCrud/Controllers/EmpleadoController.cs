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
        public async Task <IActionResult> Lista()
        {
            List<Empleado>lista = await _appDbContext.Empleados.ToListAsync();
            return View(lista);

        }
    }
}
