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

        public IActionResult Index(string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["FirstNameSorting"] =
                string.IsNullOrEmpty(sortOrder) ? "firstname" : "";

            ViewData["AgeSorting"] =
                string.IsNullOrEmpty(sortOrder) ? "age" : "";

            ViewData["LastNameSorting"] =
                string.IsNullOrEmpty(sortOrder) ? "lastname" : "";
            if(searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var people = repo.GetAll();

            if (!string.IsNullOrEmpty(searchString))
            {
                people = people.Where(p => p.LastName.ToLower().Contains(searchString.ToLower())
                || p.FirstName.ToLower().Contains(searchString.ToLower())).ToList().AsQueryable();
            }

            switch (sortOrder)
            {
                case "age":
                    people = people.OrderBy(p => p.Age);
                    break;
                case "firstname":
                    people = people.OrderBy(p => p.FirstName);
                    break;
                case "lastname":
                    people = people.OrderBy(p => p.LastName);
                    break;
                default:
                    people = people.OrderBy(p => p.Id);
                    break;

            }

            int pageSize = 3;
            var model = PaginatedList<PersonDto>.Create(people, pageNumber ?? 1, pageSize);
            return View(model);
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
