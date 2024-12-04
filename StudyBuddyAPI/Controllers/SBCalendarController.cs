using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class SBCalendarController : ControllerBase
{
    private readonly ISBCalendarService _calendarService; //injecting dependencies to access the methods of CalendarService without directly creating an instance in te controller -> easier to manage dependencies and test the controller

    public SBCalendarController(ISBCalendarService calendarService)
    {
        _calendarService = calendarService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SBCalendar>>> GetCalendars()
    {
        var calendars = await _calendarService.GetAllCalendars();
        return Ok(calendars);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SBCalendar>> GetCalendar(int id)
    {
        var calendar = await _calendarService.GetCalendarById(id);
        if (calendar == null)
        {
            return NotFound();
        }
        return Ok(calendar);
    }

    [HttpPost]
    public async Task<ActionResult<SBCalendar>> CreateCalendar(SBCalendar calendar)
    {
        var newCalendar = await _calendarService.CreateCalendar(calendar);
        return CreatedAtAction(nameof(GetCalendar), new { id = newCalendar.id }, newCalendar);
    }

    [HttpPost("{calendarId}/events")]
    public async Task<ActionResult> AddEventToCalendar(int calendarId, SBEvent @event) // need the @ to distinguish it from the event keyword
    {
        var calendar = await _calendarService.AddEventToCalendar(calendarId, @event);
        if (!calendar)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{calendarId}/events/{eventId}")]
    public async Task<IActionResult> DeleteEvent(int calendarId, int eventId)
    {
        var updatedCalendar = await _calendarService.DeleteEventFromCalendar(calendarId, eventId);
        if (updatedCalendar == null)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCalendar(int id)
    {
        var deleted = await _calendarService.DeleteCalendar(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpGet("{id}/events")]
    public async Task<ActionResult<IEnumerable<SBEvent>>> GetEventsByCalendarId(int id)
    {
        var events = await _calendarService.GetEventsByCalendarId(id);
        return Ok(events);
    }
}