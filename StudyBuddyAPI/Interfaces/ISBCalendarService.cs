public interface ISBCalendarService
{
    Task<IEnumerable<SBCalendar>> GetAllCalendars();
    Task<SBCalendar> GetCalendarById(int id);
    Task<SBCalendar> CreateCalendar(Student student);
    Task<bool> DeleteCalendar(int id);
   /*  Task<IEnumerable<SBEvent>> GetEventsByCalendarId(int calendarId);
    Task<SBCalendar> AddEventToCalendar(int calendarId, SBEvent eventToAdd);
    Task<SBCalendar> DeleteEventFromCalendar(int calendarId, int eventId);
 */
}