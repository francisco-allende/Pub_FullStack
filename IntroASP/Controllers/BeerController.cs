using IntroASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroASP.Controllers
{
    public class BeerController : Controller
    {
        private readonly PubAspContext _context;

        public BeerController(PubAspContext context)
        {
            _context= context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Beers.ToListAsync()); //archivo Razor
        }
    }
}
