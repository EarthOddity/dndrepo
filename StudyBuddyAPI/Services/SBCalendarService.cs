using Microsoft.EntityFrameworkCore;

public class SBCalendarService(DatabaseContext context) : ISBCalendarService
{
    private readonly DatabaseContext _context = context;
    static SBCalendarService(){}

    public Task<IEnumerable<SBCalendar>> GetAllCalendars()
    {
        return Task.FromResult(_context.Calendars.AsEnumerable());
    }

    public async Task<SBCalendar> GetCalendarById(int id)
    {
        var calendar = await _context.Calendars.FirstOrDefaultAsync(c => c.id == id);
        return await Task.FromResult(calendar);
    }

    public async Task<SBCalendar> CreateCalendar(Student student)
    {
        var calendar = new SBCalendar(student);
        await _context.Calendars.AddAsync(calendar);
        await _context.SaveChangesAsync();
        return calendar;
    }

    public async Task<bool> DeleteCalendar(int id)
    {
        var calendar = _context.Calendars.FirstOrDefault(c => c.id == id);
        if (calendar != null)
        {
            _context.Calendars.Remove(calendar);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<IEnumerable<SBEvent>> GetEventsByCalendarId(int calendarId)
    {
        var calendar = _context.Calendars.FirstOrDefault(c => c.id == calendarId);
        return await Task.FromResult(calendar?.events.AsEnumerable() ?? Enumerable.Empty<SBEvent>());
    }


    public async Task<SBCalendar> AddEventToCalendar(int calendarId, SBEvent eventToAdd)
    {
        var calendar = _context.Calendars.FirstOrDefault(c => c.id == calendarId);
        if (calendar != null && calendar.events != null)
        {
            calendar.events.Add(eventToAdd);
            await _context.SaveChangesAsync();

        }
        return await Task.FromResult(calendar);
    }

    public async Task<SBCalendar> DeleteEventFromCalendar(int calendarId, int eventId)
    {
        var calendar = _context.Calendars.FirstOrDefault(c => c.id == calendarId);
        if (calendar != null && calendar.events != null)
        {
            var eventToRemove = calendar.events.FirstOrDefault(e => e.id == eventId);
            if (eventToRemove != null)
            {
                calendar.events.Remove(eventToRemove);
                await _context.SaveChangesAsync();

            }
        }
        return await Task.FromResult(calendar);
    }

}