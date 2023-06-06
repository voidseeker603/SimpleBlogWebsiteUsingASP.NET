using Microsoft.AspNetCore.Mvc;
using MvcCoreTut.Models.Domain;

namespace MvcCoreTut.Controllers
{
    public class PersonController : Controller
    {
        private readonly DatabaseContext _ctx;
        public PersonController(DatabaseContext ctx)
        {
            _ctx = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddPerson()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try { 

                _ctx.Person.Add(person);
                _ctx.SaveChanges();
                TempData["msg"] = "Added Sucessfully";
                return RedirectToAction("AddPerson");

            }
            catch (Exception ex)
            {
                TempData["msg"] = "Could not be Added";
                return View();

            }
           
            
        }
		[HttpPost]
		public IActionResult EditPerson(Person person)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			try
			{

				_ctx.Person.Update(person);
				_ctx.SaveChanges();
				
				return RedirectToAction("DisplayPersons");

			}
			catch (Exception ex)
			{
				TempData["msg"] = "Could not be Update";
				return View();

			}


		}
		public IActionResult DisplayPersons()
        {
            var persons = _ctx.Person.ToList();
            return View(persons);
        }
        public IActionResult EditPerson(int id)
        {
            var person = _ctx.Person.Find(id);
            return View(person);

        }
        public IActionResult DeletePerson(int id)
        {
            try {
                var person = _ctx.Person.Find(id);
                if (person != null)
                {
                    _ctx.Person.Remove(person);
                    _ctx.SaveChanges();
                }
            }
            catch (Exception ex) { }
            return RedirectToAction("DisplayPersons");
        }
    }
}
