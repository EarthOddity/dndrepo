public interface ICalendarService
{
    Task<IEnumerable<Calendar>> GetAllCalendars();
    Task<Calendar> GetCalendarById(int id);
    Task<Calendar> CreateCalendar(Calendar calendar);
    Task<bool> DeleteCalendar(int id);
    Task<IEnumerable<Event>> GetEventsByCalendarId(int calendarId);
    Task<Calendar> AddEventToCalendar(int calendarId, Event eventToAdd);
    Task<Calendar> DeleteEventFromCalendar(int calendarId, int eventId);

}