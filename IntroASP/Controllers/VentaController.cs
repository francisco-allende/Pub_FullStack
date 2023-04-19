using IntroASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroASP.Controllers
{
    public class VentaController : Controller
    {
        private readonly PubAspContext _context;
        public VentaController(PubAspContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ventas.ToListAsync()); //archivo Razor
        }
    }
}
