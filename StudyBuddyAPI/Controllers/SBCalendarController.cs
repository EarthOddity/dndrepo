using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class SBCalendarController : ControllerBase
{
    private readonly ISBCalendarService _calendarService;

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
    [HttpGet("student/{studentId}")]
    public async Task<ActionResult<SBCalendar>> GetCalendarByStudentId(int studentId)
    {
        var calendar = await _calendarService.getCalendarIdByStudentId(studentId);
        if (calendar == null)
        {
            return NotFound();
        }
        return Ok(calendar);
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
    public async Task<ActionResult<SBCalendar>> CreateCalendar(Student student)
    {
        var newCalendar = await _calendarService.CreateCalendar(student);
        return CreatedAtAction(nameof(GetCalendar), new { id = newCalendar.Id }, newCalendar);
    }

    /*     [HttpPost("{calendarId}/event")]
        public async Task<ActionResult<SBCalendar>> AddEvent(int calendarId, SBEvent @event) // need the @ to distinguish it from the event keyword
        {
            var calendar = await _calendarService.AddEventToCalendar(calendarId, @event);
            if (calendar == null)
            {
                return NotFound();
            }
            return Ok(calendar);
        }
     */

    /*     [HttpDelete("{calendarId}/events/{eventId}")]
        public async Task<IActionResult> DeleteEvent(int calendarId, int eventId)
        {
            var updatedCalendar = await _calendarService.DeleteEventFromCalendar(calendarId, eventId);
            if (updatedCalendar == null)
            {
                return NotFound();
            }
            return NoContent();
        } */

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

    /*     [HttpGet("{id}/events")]
        public async Task<ActionResult<IEnumerable<SBEvent>>> GetEventsByCalendarId(int id)
        {
            var events = await _calendarService.GetEventsByCalendarId(id);
            return Ok(events);
        } */
}