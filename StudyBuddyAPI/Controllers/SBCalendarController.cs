using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class SBCalendarController(ISBCalendarService _calendarService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SBCalendar>>> GetAllCalendars()
    {
        var calendars = await _calendarService.GetAllCalendars();
        return Ok(calendars);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SBCalendar>> GetCalendarById(int id)
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
        if (calendar == null)
        {
            return BadRequest("Calendar data is required.");
        }
        await _calendarService.CreateCalendar(calendar);
        return CreatedAtAction(nameof(GetCalendarById), new { id = calendar.Id }, calendar);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCalendar(int id, SBCalendar updatedCalendar)
    {
        var success = await _calendarService.UpdateCalendar(id, updatedCalendar) != null;
        if (!success)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCalendar(int id)
    {
        var success = await _calendarService.DeleteCalendar(id);
        if (!success)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpPost("{calendarId}/event")]
    public async Task<ActionResult<SBCalendar>> AddEventToCalendar(int calendarId, SBEvent eventToAdd)
    {
        var calendar = await _calendarService.AddEventToCalendar(calendarId, eventToAdd);
        if (calendar == null)
        {
            return NotFound();
        }
        return Ok(calendar);
    }

    [HttpDelete("{calendarId}/events/{eventId}")]
    public async Task<IActionResult> DeleteEventFromCalendar(int calendarId, int eventId)
    {
        var calendar = await _calendarService.DeleteEventFromCalendar(calendarId, eventId);
        if (calendar == null)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpGet("user/{userId}")]
    public async Task<ActionResult<SBCalendar>> GetCalendarByUserId(int userId)
    {
        var calendar = await _calendarService.GetCalendarByUserId(userId);
        if (calendar == null)
        {
            return NotFound();
        }
        return Ok(calendar);
    }
}