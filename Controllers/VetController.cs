using Microsoft.AspNetCore.Mvc;
using VetPetRejestration.Data;
using Microsoft.AspNetCore.Authorization;

namespace VetPetRejestration.Controllers
{
    [Authorize(Roles = "Vet")]
    public class VetController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<VetController> _logger;
        public VetController(ApplicationDbContext dbContext, ILogger<VetController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View(_dbContext.Registration.Where(active => active.IsActive==true).OrderBy(date => date.Date));
        }
    }
}
