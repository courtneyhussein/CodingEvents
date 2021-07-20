using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.Controllers
{
    public class EventsController : Controller

    {
        //static private List<string> Events = new List<string>();
       static private Dictionary<string, string> Events = new Dictionary<string, string>();


        [HttpGet]
        public IActionResult Index()
        {
        ViewBag.events = Events;

        return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/Events/Add")]
        public IActionResult NewEvent(string eventName, string eventDescription)
        {
            Events.Add(eventName, eventDescription);

            return Redirect("/Events");
        }


    }
}
