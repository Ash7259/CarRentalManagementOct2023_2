using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRentalManagementOct2023_2.Server.Data;
using CarRentalManagementOct2023_2.Shared.Domain;
using CarRentalManagementOct2023_2.Server.IRepository;

namespace CarRentalManagement.Server.Controllers
{
    [Route("api/Bookings")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //Refactored
        //punlicbookingsController(ApplicationDbContext context)
        public BookingsController(IUnitOfWork unitOfWork)
        {
            //Refactored
            //_context = context;
            this._unitOfWork = unitOfWork;
        }

        // GET: api/bookings
        [HttpGet]
        //Refactored
        //public async Task<ActionResult<IEnumerable<booking>>> Getbookings()
        public async Task<IActionResult> Getbookings()
        {
            //Refactored
            //return await _context.bookings.ToListAsync();
            var bookings = await _unitOfWork.Bookings.GetAll();
            return Ok(bookings);
        }

        // GET: api/bookings/5
        [HttpGet("{id}")]
        //Refactored
        //public async Task<ActionResult<booking>> Getbooking(int id)
        public async Task<ActionResult<Booking>> Getbooking(int id)
        {
            //Refactored
            //var booking = await _context.bookings.FindAsync(id);
            var booking = await _unitOfWork.Bookings.Get(q => q.Id == id);

            if (booking == null)
            {
                return NotFound();
            }

            //Refactored
            return Ok(booking);
        }

        // PUT: api/bookings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putbooking(int id, Booking booking)
        {
            if (id != booking.Id)
            {
                return BadRequest();
            }

            //Refactored
            //_context.Entry(booking).State = EntityState.Modified;
            _unitOfWork.Bookings.Update(booking);

            try
            {
                //Refactored
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //Refactored
                //if (!bookingExists(id))
                if (!await BookingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/bookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Booking>> Postbooking(Booking booking)
        {
            //Refactored
            //_context.bookings.Add(booking);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Bookings.Insert(booking);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("Getbooking", new { id = booking.Id }, booking);
        }

        // DELETE: api/bookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletebooking(int id)
        {
            //Refactored
            //var booking = await _context.bookings.FindAsync(id);
            var booking = await _unitOfWork.Bookings.Get(q => q.Id == id);
            if (booking == null)
            {
                return NotFound();
            }

            //Refactored
            //_context.bookings.Remove(booking);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Bookings.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //Refactored
        //private bool bookingExists(int id)
        private async Task<bool> BookingExists(int id)
        {
            //Refactored
            //return _context.bookings.Any(e => e.Id == id);
            var booking = await _unitOfWork.Bookings.Get(q => q.Id == id);
            return booking != null;
        }
    }
}