using C__Advanced_Final_Project.Data;
using Microsoft.AspNetCore.Mvc;

namespace C__Advanced_Final_Project.Controllers
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
