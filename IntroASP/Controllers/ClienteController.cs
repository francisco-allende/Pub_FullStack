using IntroASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroASP.Controllers
{
    public class ClienteController : Controller
    {
        private readonly PubAspContext _context;
        public ClienteController(PubAspContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clients.ToListAsync()); //archivo Razor
        }
    }
}
