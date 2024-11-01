public class CalendarService
{
    private static List<Calendar> _calendarsList = new List<Calendar>();

    public Task<IEnumerable<Calendar>> GetAllCalendars()
    {
        return Task.FromResult(_calendarsList.AsEnumerable());
    }

    public Task<Calendar> GetCalendarById(int id)
    {
        var calendar = _calendarsList.FirstOrDefault(c => c.id == id);
        return Task.FromResult(calendar);
    }

    public Task<Calendar> CreateCalendar(Calendar calendar)
    {
        _calendarsList.Add(calendar);
        return Task.FromResult(calendar);
    }

    public Task<bool> DeleteCalendar(int id)
    {
        var calendar = _calendarsList.FirstOrDefault(c => c.id == id);
        if (calendar != null)
        {
            _calendarsList.Remove(calendar);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    public Task<IEnumerable<Event>> GetEventsByCalendarId(int calendarId)
    {
        var calendar = _calendarsList.FirstOrDefault(c => c.id == calendarId);
        return Task.FromResult(calendar?.events.AsEnumerable() ?? Enumerable.Empty<Event>());
    }


    public Task<Calendar> AddEventToCalendar(int calendarId, Event eventToAdd)
    {
        var calendar = _calendarsList.FirstOrDefault(c => c.id == calendarId);
        if (calendar != null && calendar.events != null)
        {
            calendar.events.Add(eventToAdd);
        }
        return Task.FromResult(calendar);
    }

    public Task<Calendar> DeleteEventFromCalendar(int calendarId, int eventId)
    {
        var calendar = _calendarsList.FirstOrDefault(c => c.id == calendarId);
        if (calendar != null && calendar.events != null)
        {
            var eventToRemove = calendar.events.FirstOrDefault(e => e.id == eventId);
            if (eventToRemove != null)
            {
                calendar.events.Remove(eventToRemove);
            }
        }
        return Task.FromResult(calendar);
    }

}