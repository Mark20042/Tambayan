using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Tambayan.Data;


namespace Tambayan.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Fetch all posts ordered by newest post first
            var allPosts =  await _context.Posts
                .Include(p => p.User)         
                .Include(p => p.Images)      
                .OrderByDescending(p => p.DateCreated) 
                .ToListAsync();

           
            return View(allPosts);
        }

    
    }
}
