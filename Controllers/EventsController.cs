using CodingEvents.Data;
using CodingEvents.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.Controllers
{
    public class EventsController : Controller

    {
        [HttpGet]
        public IActionResult Index()
        {
        ViewBag.events = EventData.GetAll();

        return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        //[HttpPost]
        //[Route("/Events/Add")]
        //public IActionResult NewEvent(string eventName, string eventDescription)
        //{
        //    EventData.Add(new Event(eventName, eventDescription));

        //    return Redirect("/Events");
        //}


        //Using model binding. Make sure the form names match the Event class's properties. Case does not matter. See above fore what it is replacing.
        [HttpPost]
        [Route("/Events/Add")]
        public IActionResult NewEvent(Event newEvent)
        {
            EventData.Add(newEvent);

            return Redirect("/Events");
        }

        public IActionResult Delete()
        {
            ViewBag.events = EventData.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventsIds)
        {
            foreach (int eventId in eventsIds)
            {
                EventData.Remove(eventId);
            }
            return Redirect("/Events");
        }

    }
}
