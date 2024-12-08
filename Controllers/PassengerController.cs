using Microsoft.AspNetCore.Mvc;
using TrainReservationAPI.Data;
using TrainReservationAPI.Models;

namespace TrainReservationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PassengerController : ControllerBase
    {
        private readonly TrainReservationContext _context;

        public PassengerController(TrainReservationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllPassengers() => Ok(_context.Passengers.ToList());

        [HttpGet("{id}")]
        public IActionResult GetPassengerById(int id)
        {
            var passenger = _context.Passengers.Find(id);
            return passenger == null ? NotFound() : Ok(passenger);
        }

        [HttpPost]
        public IActionResult CreatePassenger(Passenger passenger)
        {
            _context.Passengers.Add(passenger);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetPassengerById), new { id = passenger.Passenger_ID }, passenger);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePassenger(int id, Passenger passenger)
        {
            if (id != passenger.Passenger_ID) return BadRequest();
            var existing = _context.Passengers.Find(id);
            if (existing == null) return NotFound();

            existing.Name = passenger.Name;
            existing.Email = passenger.Email;
            existing.Miles_Travelled = passenger.Miles_Travelled;
            existing.Loyalty_Class = passenger.Loyalty_Class;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePassenger(int id)
        {
            var passenger = _context.Passengers.Find(id);
            if (passenger == null) return NotFound();

            _context.Passengers.Remove(passenger);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
