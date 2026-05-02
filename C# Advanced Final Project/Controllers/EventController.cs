using EventPlanner.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanner.Controllers
{
    public class EventController : Controller
    {
        private EventContext context {  get; set; }

        public IActionResult EventList()
        {
            var events = context.Events.ToList();

            return View(events);
        }
    }
}
