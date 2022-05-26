using Application.Dto;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPersonRepository repo;

        public PeopleController(IPersonRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            return View(repo.GetAll());
        }

        // Details
        public IActionResult Details(int Id)
        {
            var person = repo.Get(Id);
            if(person is null)
            {
                return NotFound();
            }
            return View(person);
        }

        // Create 
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PersonDto personDto)
        {
            if (!ModelState.IsValid)
            {
                return View(personDto);
            }

            if (repo.Add(personDto))
            {
                return RedirectToAction("Index");
            }

            return View(personDto);
        }

        // Edit
        public IActionResult Edit(int Id)
        {
            var person = repo.Get(Id);
            return View(person);
        }

        [HttpPost]
        public IActionResult Edit(int Id, PersonDto personDto)
        {
            if (repo.Update(Id, personDto))
            {
                return RedirectToAction("Index");
            }
            return View(personDto);
        }

        // Delete
        public IActionResult Delete(int Id)
        {
            var person = repo.Get(Id);
            return View(person);
        }

        [HttpPost]
        public IActionResult Delete(int Id, PersonDto personDto)
        {
            if (repo.Delete(Id))
            {
                return RedirectToAction("Index");
            }
            return View(personDto);
        }


    }
}
