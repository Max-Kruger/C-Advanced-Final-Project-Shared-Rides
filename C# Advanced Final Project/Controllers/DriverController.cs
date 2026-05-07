using C__Advanced_Final_Project.Data;
using C__Advanced_Final_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace C__Advanced_Final_Project.Controllers
{
    [Authorize(Roles = "Driver")]
    public class DriverController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly EventContext _context;

        public DriverController(UserManager<User> userManager, EventContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var myDriverEntries = _context.Drivers
                .Where(d => d.DriverUserId == currentUser.Id)
                .ToList();

            var myEvents = myDriverEntries
                .Where(d => d.AttendingEventId != null)
                .Select(d => _context.Events.Find(d.AttendingEventId))
                .ToList();

            // Get events the driver has NOT signed up for yet
            var signedUpEventIds = myDriverEntries
                .Where(d => d.AttendingEventId != null)
                .Select(d => d.AttendingEventId)
                .ToList();

            ViewBag.AvailableEvents = _context.Events
                .Where(e => !signedUpEventIds.Contains(e.EventID))
                .ToList();

            return View(myEvents);
        }

        [HttpGet]
        public IActionResult SignUpForEvent(int id)
        {
            var e = _context.Events.Find(id);
            if (e == null) return NotFound();
            ViewBag.Event = e;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUpAsDriver(int eventId, int maxCapacity, string carMake, string carModel, string carColor)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            var existing = _context.Drivers
                .FirstOrDefault(d => d.DriverUserId == currentUser.Id
                                  && d.AttendingEventId == eventId);
            if (existing == null)
            {
                var driver = new Driver
                {
                    DriverUserId = currentUser.Id,
                    AttendingEventId = eventId,
                    MaxCapacity = maxCapacity,
                    remainingPassengers = maxCapacity,
                    CarMake = carMake,
                    CarModel = carModel,
                    CarColor = carColor
                };
                _context.Drivers.Add(driver);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> DropOut(int eventId)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var driver = _context.Drivers
                .FirstOrDefault(d => d.DriverUserId == currentUser.Id
                                  && d.AttendingEventId == eventId);
            if (driver != null)
            {
                _context.Drivers.Remove(driver);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }

}