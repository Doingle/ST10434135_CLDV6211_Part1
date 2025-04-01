using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ST10434135_CLDV6211_Part1.Data;
using ST10434135_CLDV6211_Part1.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ST10434135_CLDV6211_Part1.Controllers
{
    public class VenueController : Controller
    {
        // initializing the database context
        private readonly AppDbContext _context;

        // constructor to initialize the database context
        public VenueController(AppDbContext context)
        {
            _context = context; 
        }

        //---------------------------------------------------------------------------------//
        // this async method gets all venues from the database and returns the view
        public async Task<IActionResult> Index()
        {
            return View(await _context.Venues.ToListAsync());
        }

        //---------------------------------------------------------------------------------//
        // this async method retrieves the venue details by id and returns the view
        public async Task<IActionResult> Details(int? id)
        {
            // this if statement checks if the id is null
            if (id == null)
            {
                return NotFound();
            }

            // this query retrieves the venue details by id
            var venue = await _context.Venues
                .FirstOrDefaultAsync(m => m.VenueID == id);
            // this if statement checks if the venue is null
            if (venue == null)
            {
                return NotFound();
            }

            return View(venue);
        }

        //---------------------------------------------------------------------------------//
        // this method returns the view to create a new venue
        public IActionResult Create()
        {
            return View();
        }

        //---------------------------------------------------------------------------------//
        // this method creates a new venue and saves it to the database, it then redirects to the index page
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VenueID,VenueName,Location,Capacity,ImageURL")] Venues venue)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venue);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(venue);
        }

        //---------------------------------------------------------------------------------//
        // this async method retrieves the venue details by id and returns the view
        public async Task<IActionResult> Edit(int? id)
        {
            // this if statement checks if the id is null
            if (id == null)
            {
                return NotFound();
            }

            // this query retrieves the venue details by id
            var venue = await _context.Venues.FindAsync(id);

            // this if statement checks if the venue is null
            if (venue == null)
            {
                return NotFound();
            }
            return View(venue);
        }

        //---------------------------------------------------------------------------------//
        // this async method updates the venue details and saves it to the database, it then redirects to the index page
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VenueID,VenueName,Location,Capacity,ImageURL")] Venues venue)
        {
            // this if statement checks if the id is not equal to the venue id
            if (id != venue.VenueID)
            {
                return NotFound();
            }

            // this if statement checks if the model state is valid
            if (ModelState.IsValid)
            {
                //this try catch updates the venue details and saves it to the database, if there is an error it returns a not found error
                try
                {
                    _context.Update(venue);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VenueExists(venue.VenueID))
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
            return View(venue);
        }

        //---------------------------------------------------------------------------------//
        // this async method retrieves the venue details by id and returns the view
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venue = await _context.Venues
                .FirstOrDefaultAsync(m => m.VenueID == id);
            if (venue == null)
            {
                return NotFound();
            }

            return View(venue);
        }

        //---------------------------------------------------------------------------------//
        // this async method deletes the venue and saves it to the database, it then redirects to the index page
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venue = await _context.Venues.FindAsync(id);
            _context.Venues.Remove(venue);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //---------------------------------------------------------------------------------//
        // this method checks if the venue exists
        private bool VenueExists(int id)
        {
            return _context.Venues.Any(e => e.VenueID == id);
        }
    }
}
//---------------------------------------------------------EOF---------------------------------------------------------//
