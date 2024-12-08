using Microsoft.AspNetCore.Mvc;
using TrainReservationAPI.Data;
using TrainReservationAPI.Models;

namespace TrainReservationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly TrainReservationContext _context;

        public ReservationController(TrainReservationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllReservations() => Ok(_context.Reservations.ToList());

        [HttpGet("{id}")]
        public IActionResult GetReservationById(int id)
        {
            var reservation = _context.Reservations.Find(id);
            return reservation == null ? NotFound() : Ok(reservation);
        }

        [HttpPost]
        public IActionResult CreateReservation(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetReservationById), new { id = reservation.Reservation_No }, reservation);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateReservation(int id, Reservation reservation)
        {
            if (id != reservation.Reservation_No) return BadRequest();
            var existing = _context.Reservations.Find(id);
            if (existing == null) return NotFound();

            existing.Status = reservation.Status;
            existing.Expiry_Date = reservation.Expiry_Date;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult CancelReservation(int id)
        {
            var reservation = _context.Reservations.Find(id);
            if (reservation == null) return NotFound();

            reservation.Status = "Canceled";
            _context.SaveChanges();
            return NoContent();
        }
    }
}
