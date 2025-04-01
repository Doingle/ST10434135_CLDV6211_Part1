using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ST10434135_CLDV6211_Part1.Data;
using ST10434135_CLDV6211_Part1.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ST10434135_CLDV6211_Part1.Controllers
{
    public class BookingController : Controller
    {
        // getting the database context
        private readonly AppDbContext _context;

        // constructor to initialize the database context
        public BookingController(AppDbContext context)
        {
            _context = context;
        }

        //---------------------------------------------------------------------------------//
        // this action method gets all bookings from the database and returns the view
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bookings.ToListAsync());
        }

        //---------------------------------------------------------------------------------//
        // this action method retrieves the booking details by id and returns the view
        public async Task<IActionResult> Details(int? id)
        // this if statement checks if the id is null
        {
            if (id == null)
            {
                return NotFound();
            }

            // this query retrieves the booking details by id
            var booking = await _context.Bookings
                .FirstOrDefaultAsync(m => m.BookingID == id);
            // this if statement checks if the booking is null
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        //---------------------------------------------------------------------------------//
        // this method returns the view to create a new booking
        public IActionResult Create()
        {
            return View();
        }

        // this method creates a new booking and saves it to the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingID,EventID,VenueID,BookingDate,SpecialistID")] Bookings booking)
        {
            // this if statement checks if the model state is valid
            if (ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(booking);
        }

        // retrieve the booking details by id and return the view to edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        //---------------------------------------------------------------------------------//
        // this method updates the booking details and saves it to the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingID,EventID,VenueID,BookingDate,SpecialistID")] Bookings booking)
        {
            // this if statement checks if the id is not equal to the booking id
            if (id != booking.BookingID)
            {
                return NotFound();
            }

            // this if statement checks if the model state is valid
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.BookingID))
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
            return View(booking);
        }

        // retrieve the booking details by id and return the view to delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .FirstOrDefaultAsync(m => m.BookingID == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        //---------------------------------------------------------------------------------//
        // this method deletes the booking from the database
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //---------------------------------------------------------------------------------//
        // this method checks if the booking exists in the database 
        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.BookingID == id);
        }
    }
}

//-------------------------------------EOF-------------------------------------//
