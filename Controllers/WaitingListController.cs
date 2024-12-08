using Microsoft.AspNetCore.Mvc;
using TrainReservationAPI.Data;
using TrainReservationAPI.Models;

namespace TrainReservationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WaitingListController : ControllerBase
    {
        private readonly TrainReservationContext _context;

        public WaitingListController(TrainReservationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllWaitingListEntries() => Ok(_context.WaitingLists.ToList());

        [HttpPost]
        public IActionResult AddToWaitingList(WaitingList waitingList)
        {
            _context.WaitingLists.Add(waitingList);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAllWaitingListEntries), new { id = waitingList.Waiting_List_ID }, waitingList);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveFromWaitingList(int id)
        {
            var entry = _context.WaitingLists.Find(id);
            if (entry == null) return NotFound();

            _context.WaitingLists.Remove(entry);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
