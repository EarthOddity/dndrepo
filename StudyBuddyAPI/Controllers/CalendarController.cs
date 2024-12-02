using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class CalendarController : ControllerBase
{
    private readonly CalendarService _calendarService; //injecting dependencies to access the methods of CalendarService without directly creating an instance in te controller -> easier to manage dependencies and test the controller

    public CalendarController(CalendarService calendarService)
    {
        _calendarService = calendarService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Calendar>>> GetCalendars()
    {
        var calendars = await _calendarService.GetAllCalendars();
        return Ok(calendars);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Calendar>> GetCalendar(int id)
    {
        var calendar = await _calendarService.GetCalendarById(id);
        if (calendar == null)
        {
            return NotFound();
        }
        return Ok(calendar);
    }

    [HttpPost]
    public async Task<ActionResult<Calendar>> CreateCalendar(Calendar calendar)
    {
        var newCalendar = await _calendarService.CreateCalendar(calendar);
        return CreatedAtAction(nameof(GetCalendar), new { id = newCalendar.id }, newCalendar);
    }

    [HttpPost("{calendarId}/event")]
    public async Task<ActionResult<Calendar>> AddEvent(int calendarId, Event @event) // need the @ to distinguish it from the event keyword
    {
        var calendar = await _calendarService.AddEventToCalendar(calendarId, @event);
        if (calendar == null)
        {
            return NotFound();
        }
        return Ok(calendar);
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
    public async Task<ActionResult<IEnumerable<Event>>> GetEventsByCalendarId(int id)
    {
        var events = await _calendarService.GetEventsByCalendarId(id);
        return Ok(events);
    }
}