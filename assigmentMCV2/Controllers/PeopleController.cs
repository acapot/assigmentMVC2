using assigmentMVC2.Models;
using assigmentMVC2.Models.Repos;
using assigmentMVC2.Models.Services;
using assigmentMVC2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace assigmentMVC2.Controllers
{
    public class PeopleController : Controller
    {
        IPeopleService _peopleService;
        public PeopleController(IPeopleService peopleService)
        {
            // _peopleService = new PeopleService(new PeopleRepo());
            _peopleService = peopleService;
        }

        public IActionResult Index()
        {
            return View(_peopleService.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new PersonView());
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(PersonView createPerson)
        {
            if (ModelState.IsValid)
            {

                try// STEP1 
                {
                    _peopleService.Create(createPerson);
                }
                catch (ArgumentException exception)
                {
                    // Add our own message
                    ModelState.AddModelError("Person & cities", exception.Message);// Key And value
                    return View(createPerson);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(createPerson);
        }
        public IActionResult Details(int id)
        {
            Person person = _peopleService.FindById(id);
            if (person == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        //remove item from Delete View        
        public IActionResult Delete(int id)
        {
            Person person = _peopleService.FindById(id);
            //_peopleService.Remove(id);
            if (person == null)
            {
                return RedirectToAction(nameof(Details));
                //return NotFound();//404
            }
            else
            {
                _peopleService.Remove(id);
            }

            return RedirectToAction(nameof(Index));
        }

        //Only to go to delete view
        public IActionResult DeleteView(int id)
        {
            Person person = _peopleService.FindById(id);
            return View("~/Views/People/Delete.cshtml", person);
        }

        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(int id)
        {
            Person person = _peopleService.FindById(id);

            if (person == null)
            {
                return RedirectToAction(nameof(Index));
                //return NotFound();//404
            }
            PersonView editPerson = new PersonView()
            {
                PersonName = person.PersonName,
                PhoneNumber = person.PhoneNumber,
                CityCode = person.CityId
            };

            return View(editPerson);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(int id, PersonView editPerson)
        {

            if (ModelState.IsValid)
            {
                _peopleService.Edit(id, editPerson);
                return RedirectToAction(nameof(Index));
                //return NotFound();//404
            }

            return View(editPerson);
        }


        //************************ Used for AJAX  ***************************************
        public IActionResult PartialViewPeople()
        {
            return PartialView("_AjaxPersonList", _peopleService.GetAll());
        }

        [HttpPost]
        public IActionResult AjaxPartialViewDetails(int id)
        {
            Person person = _peopleService.FindById(id);
            if (person != null)
            {
                return PartialView("_AjaxPersonDetails", person);
            }
            return NotFound();
        }
        public IActionResult AjaxDelete(int id)
        {
            Person person = _peopleService.FindById(id);
            if (_peopleService.Remove(id))
            {
                return PartialView("_AjaxPersonList", _peopleService.GetAll());
            }
            return NotFound();
        }


        //*********************************************
        public IActionResult LastPersonArrivel()
        {
            Person person = _peopleService.LastAdded();
            if (person != null)
            {
                return PartialView("_PersonRow", person);
            }
            return NotFound();// for Fun 418 normal use 404 

        }
        public IActionResult LastPersonArrivelJSON() // getLastPersonJSON
        {
            Person person = _peopleService.LastAdded();
            if (person != null)
            {
                return Json(person);
            }
            return NotFound();//404 /418
        }
        public IActionResult AjaxPersonList()
        {
            List<Person> person = _peopleService.GetAll();
            if (person != null)
            {
                return PartialView("_PersonList", person);

            }
            return BadRequest();

        }

    }
}
