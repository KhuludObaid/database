using Microsoft.AspNetCore.Mvc;
using TrainReservationAPI.Data;
using TrainReservationAPI.Models;

namespace TrainReservationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainController : ControllerBase
    {
        private readonly TrainReservationContext _context;

        public TrainController(TrainReservationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllTrains() => Ok(_context.Trains.ToList());

        [HttpGet("{id}")]
        public IActionResult GetTrainById(int id)
        {
            var train = _context.Trains.Find(id);
            return train == null ? NotFound() : Ok(train);
        }

        [HttpPost]
        public IActionResult CreateTrain(Train train)
        {
            _context.Trains.Add(train);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetTrainById), new { id = train.Train_ID }, train);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTrain(int id, Train train)
        {
            if (id != train.Train_ID) return BadRequest();
            var existing = _context.Trains.Find(id);
            if (existing == null) return NotFound();

            existing.Name = train.Name;
            existing.Capacity = train.Capacity;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTrain(int id)
        {
            var train = _context.Trains.Find(id);
            if (train == null) return NotFound();

            _context.Trains.Remove(train);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
