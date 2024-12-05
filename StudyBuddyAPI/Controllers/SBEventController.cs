using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class SBEventController : ControllerBase
{
    private readonly ISBEventService _eventService;

    public SBEventController(ISBEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SBEvent>>> GetEvents()
    {
        var events = await _eventService.GetAllEvents();
        return Ok(events);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SBEvent>> GetEvent(int id)
    {
        var @event = await _eventService.GetEventById(id);
        if (@event == null)
        {
            return NotFound();
        }
        return Ok(@event);
    }
    [HttpGet("calendar/{calendarId}")]
    public async Task<ActionResult<IEnumerable<SBEvent>>> GetEventsByCalendarId(int calendarId)
    {
        var events = await _eventService.GetEventsByCalendarId(calendarId);
        return Ok(events);
    }
    [HttpPost]
    public async Task<ActionResult<SBEvent>> CreateEvent(SBEvent @event)
    {
        var newEvent = await _eventService.CreateEvent(@event);
        return CreatedAtAction(nameof(GetEvent), new { id = newEvent.id }, newEvent);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEvent(int id, SBEvent @event)
    {
        var updated = await _eventService.UpdateEvent(id, @event);
        if (!updated)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpGet("range")]
    public async Task<ActionResult<IEnumerable<SBEvent>>> GetEventsInRange([FromQuery] DateTime start, [FromQuery] DateTime end)
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