public class CalendarService(FileContext context) : ICalendarService
{
    private readonly FileContext _context = context;

    public Task<IEnumerable<Calendar>> GetAllCalendars()
    {
        return Task.FromResult(_context.Calendars.AsEnumerable());
    }

    public async Task<Calendar> GetCalendarById(int id)
    {
        var calendar = _context.Calendars.FirstOrDefault(c => c.id == id);
        return await Task.FromResult(calendar);
    }

    public async Task<Calendar> CreateCalendar(Calendar calendar)
    {
        _context.Calendars.Add(calendar);
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

    public async Task<IEnumerable<Event>> GetEventsByCalendarId(int calendarId)
    {
        var calendar = _context.Calendars.FirstOrDefault(c => c.id == calendarId);
        return await Task.FromResult(calendar?.events.AsEnumerable() ?? Enumerable.Empty<Event>());
    }


    public async Task<Calendar> AddEventToCalendar(int calendarId, Event eventToAdd)
    {
        var calendar = _context.Calendars.FirstOrDefault(c => c.id == calendarId);
        if (calendar != null && calendar.events != null)
        {
            calendar.events.Add(eventToAdd);
            await _context.SaveChangesAsync();

        }
        return await Task.FromResult(calendar);
    }

    public async Task<Calendar> DeleteEventFromCalendar(int calendarId, int eventId)
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