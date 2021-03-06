using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VetPetRejestration.Data;
using Microsoft.AspNetCore.Identity;
using VetPetRejestration.Models;
using System.Collections;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace VetPetRejestration.Controllers
{
    [Authorize(Roles = "User")]
    public class PetsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<PetsController> _logger;
        private static List<Pet> petsList = new List<Pet>();
        public string? Message { get; set; }

        //private readonly User _user;
        public PetsController(ApplicationDbContext dbContext, ILogger<PetsController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;

        }
        // GET: PetsController
        public ActionResult ShowAllPets()
        {
            var userIdentity = User.Identity?.Name;
            var userAnimals = _dbContext.Users.Include(p => p.Pets.Where(v => v.Visible==true)).FirstOrDefault(x => x.Email == userIdentity);
            if (userAnimals != null)
                return View(userAnimals.Pets);
            else
                return View();
        }

        public ActionResult AllVisits(int id) {
            try
            {
                var userIdentity = User.Identity?.Name;
                var visits = _dbContext.Pets
                    .Include(r => r.Registration)
                    .FirstOrDefault(i => i == _dbContext.Users
                    .Include(p => p.Pets).FirstOrDefault(x => x.Email
                    .Equals(userIdentity)).Pets.Where((x) => x.Visible.Equals(true))
                    .FirstOrDefault(x => x.Id.Equals(id))).Registration;
                return View(visits);
            }
            catch
            {
                return RedirectToAction(nameof(ShowAllPets));
            }
            
        }

        public ActionResult RegistrationAdd() { 
            return View(new Registration()); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistrationAdd(Registration registration, int id)
        {
            try
            {
                var userIdentity = User.Identity?.Name;
                var animal = _dbContext.Users.Include(p => p.Pets).FirstOrDefault(x => x.Email == userIdentity).Pets.FirstOrDefault(p => p.Id == id);
                if(animal != null)
                {
                    registration.Id = 0;
                    registration.Description = "";
                    registration.IsActive = true;
                    registration.WasHappend = false;
                    animal.Registration.Add(registration);
                    _dbContext.SaveChanges();
                }
                return RedirectToAction(nameof(ShowAllPets));
            }catch
            {
                return View();
            }
        }

        // GET: PetsController/Details/5
        public ActionResult Details(int id)
        {
            var userIdentity = User.Identity?.Name;
            var userAnimals = _dbContext.Users.Include(p => p.Pets).FirstOrDefault(x => x.Email == userIdentity);
            if(userAnimals != null)
            {
                var specificPet = userAnimals.Pets.FirstOrDefault(x => x.Id == id);
                return View(specificPet);
            }else
                return View();
        }
            

        // GET: PetsController/Create
        public ActionResult Create()
        {
            return View(new Pet());
        }

        // POST: PetsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pet pet)
        {
            try
            {
                var userIdentity = User.Identity?.Name;
                var userAnimals = _dbContext.Users.Include(p => p.Pets).FirstOrDefault(x => x.Email == userIdentity);
                if( userAnimals != null)
                {
                    pet.Visible=true;
                    userAnimals.Pets.Add(pet);
                    _dbContext.SaveChanges();
                    Message = $"{DateTime.UtcNow.ToLongTimeString()} User {userIdentity} add new object to Pet";
                    _logger.LogInformation(Message);
                    return RedirectToAction(nameof(ShowAllPets));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: PetsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PetsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PetsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PetsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
