using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using VetPetRejestration.Data;

namespace VetPetRejestration.Controllers
{
    [Authorize(Roles = "Admin,Vet,User")]
    public class RedirectController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<RedirectController> _logger;
        public RedirectController(ApplicationDbContext dbContext, ILogger<RedirectController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public IActionResult Index()
        {
            var userRoles = ((ClaimsIdentity)User.Identity).Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value);
            var role = userRoles.FirstOrDefault(stringToCheck => stringToCheck.Contains("Admin"));
            if (role != null)
                return  RedirectToAction("Index", "Admin");
            role = userRoles.FirstOrDefault(stringToCheck => stringToCheck.Contains("Vet"));
            if (role != null)
                return RedirectToAction("Index", "Vet");
            role = userRoles.FirstOrDefault(stringToCheck => stringToCheck.Contains("User"));
            if (role != null)
                return RedirectToAction("Index", "User");
            return RedirectToAction("Index", "Home");
        }
    }
}
