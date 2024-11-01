using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class EventController : ControllerBase
{
    private readonly EventService _eventService;

    public EventController(EventService eventService)
    {
        _eventService = eventService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
    {
        var events = await _eventService.GetAllEvents();
        return Ok(events);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Event>> GetEvent(int id)
    {
        var @event = await _eventService.GetEventById(id);
        if (@event == null)
        {
            return NotFound();
        }
        return Ok(@event);
    }

    [HttpPost]
    public async Task<ActionResult<Event>> CreateEvent(Event @event)
    {
        var newEvent = await _eventService.CreateEvent(@event);
        return CreatedAtAction(nameof(GetEvent), new { id = newEvent.id }, newEvent);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEvent(int id, Event @event)
    {
        var updated = await _eventService.UpdateEvent(id, @event);
        if (!updated)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpGet("range")]
    public async Task<ActionResult<IEnumerable<Event>>> GetEventsInRange([FromQuery] DateTime start, [FromQuery] DateTime end)
    {
        var events = await _eventService.GetEventsInRange(start, end);
        return Ok(events);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEvent(int id)
    {
        var deleted = await _eventService.DeleteEvent(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}