public interface ICalendarService
{
    Task<IEnumerable<SBCalendar>> GetAllCalendars();
    Task<SBCalendar> GetCalendarById(int id);
    //Task<SBCalendar> CreateCalendar(SBCalendar calendar);
    Task<SBCalendar> UpdateCalendar(int calendarId, SBCalendar updatedCalendar);
    Task<bool> DeleteCalendar(int id);
    Task<SBEvent> GetEventById(int id);
    Task<SBEvent> CreateEvent(SBEvent @event);
    Task<SBEvent> UpdateEvent(SBEvent @event);
    Task<bool> DeleteEvent(int id);
/*     Task<SBCalendar> AddEventToCalendar(int calendarId, SBEvent eventToAdd);
    Task<SBCalendar> DeleteEventFromCalendar(int calendarId, int eventId); */
    //Task<SBCalendar> GetCalendarByUserId(int studentId);
    Task<IEnumerable<SBEvent>> GetEventsByCalendarId(int calendarId);
    Task<int> GetCalendarIdByStudentId(int studentId);

}