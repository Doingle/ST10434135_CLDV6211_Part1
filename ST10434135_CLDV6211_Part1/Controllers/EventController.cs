using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ST10434135_CLDV6211_Part1.Data;
using ST10434135_CLDV6211_Part1.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ST10434135_CLDV6211_Part1.Controllers
{
    public class EventController : Controller
    {
        // this variable is used to get the database context
        private readonly AppDbContext _context;

        // this constructor initializes the database context
        public EventController(AppDbContext context)
        {
            _context = context;
        }

        //---------------------------------------------------------------------------------//
        // this method gets all events from the database and returns the view
        public async Task<IActionResult> Index()
        {
            return View(await _context.Events.ToListAsync());
        }

        //---------------------------------------------------------------------------------//
        // this method retrieves the event details by id and returns the view
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .FirstOrDefaultAsync(m => m.EventID == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        //---------------------------------------------------------------------------------//
        // this method gets the view to create a new event
        public IActionResult Create()
        {
            return View();
        }

        //---------------------------------------------------------------------------------//
        // this method creates a new event and saves it to the database, it then redirects to the index page
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventID,EventName,EventDate,Description,VenueID")] Events @event)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@event);
        }

        //---------------------------------------------------------------------------------//
        // this asynchronous method gets the event details by id and returns the view
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        //---------------------------------------------------------------------------------//
        // this asynchronous method updates the event details and saves it to the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventID,EventName,EventDate,Description,VenueID")] Events @event)
        {
            if (id != @event.EventID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.EventID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(@event);
        }

        //---------------------------------------------------------------------------------//
        // this asynchronous method gets the event details by id and returns the view
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .FirstOrDefaultAsync(m => m.EventID == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        //---------------------------------------------------------------------------------//
        // this asynchronous method deletes the event from the database, adds delete functionality
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Events.FindAsync(id);
            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //---------------------------------------------------------------------------------//
        // this method checks if the event exists. it's used for error handling
        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.EventID == id);
        }
    }
}
//------------------------------------------------------EOF------------------------------------------------------//
