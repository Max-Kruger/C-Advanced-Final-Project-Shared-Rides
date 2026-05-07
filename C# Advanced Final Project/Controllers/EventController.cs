using C__Advanced_Final_Project.Data;
using C__Advanced_Final_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace C__Advanced_Final_Project.Controllers
{
    public class EventController : Controller

    {

        private readonly  UserManager<User> _userManager;
 
        private EventContext context {  get; set; }

        public EventController(UserManager<User> userManager, EventContext context)
        {
            _userManager = userManager;
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> EventList()
        {
            var events = context.Events.ToList();
            if (User.IsInRole("Driver"))
            {
                var currentUser = await _userManager.GetUserAsync(User);
                var signedUpEventIds = context.Drivers
                    .Where(d => d.DriverUserId == currentUser.Id && d.AttendingEventId != null)
                    .Select(d => d.AttendingEventId)
                    .ToList();
                ViewBag.SignedUpEventIds = signedUpEventIds;
            }
            return View(events);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> MyEvents()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            // Add this check
            if (currentUser == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var events = context.FetchMyEvents(currentUser);
            return View("EventList", events);
        }
        [HttpGet]
        public IActionResult ViewEvent(int id) { 
            
            ViewBag.Event = context.Events.Find(id);
            context.BuildDrivers();
            ViewBag.Drivers = context.Drivers.Where(d => d.AttendingEventId == id).ToList();
            ViewBag.UserID =  _userManager.GetUserId(User);

            return View(new Guest {AttendingEventId = id });
        }

        [HttpPost]
        public async Task<IActionResult> ViewEventAsync(Guest g) {

            ModelState.Remove(nameof(Guest.GuestUser));
            ModelState.Remove(nameof(Guest.GuestUserID));
            ModelState.Remove(nameof(Guest.AssignedDriver));
            //g.GuestUserID = _userManager.GetUserId(User);
            g.GuestUser = await _userManager.GetUserAsync(User);


            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("Address", g.Address);


                context.AddOrUpdateDB(g);

                return RedirectToAction("EventList", "Event");
            }
            else
            {
                ViewBag.Event = context.Events.Find(g.AttendingEventId);
                ViewBag.Drivers = context.Drivers.Where(d => d.AttendingEventId == g.AttendingEventId).Include(d=> d.DriverUser).ToList();
                ViewBag.UserID = _userManager.GetUserId(User);

                return View(g);
            }


        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Event());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var e = context.Events.Find(id);
            return View(e);

        }
        [HttpPost]
        public IActionResult Edit(Event e) {

            if (ModelState.IsValid) { 
                
                if( e.EventID == 0){
                    context.Events.Add(e);
                }
                else
                {
                    context.Events.Update(e);
                }
                context.SaveChanges();
                return RedirectToAction("EventList");
            
            
            
            
            }
            else
            {
                ViewBag.Action = (e.EventID == 0) ? "Add" : "Edit";
                return View(e);
            }
        }
            
        }
            
}

