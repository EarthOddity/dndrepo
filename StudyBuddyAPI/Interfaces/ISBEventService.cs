public interface ISBEventService
{
    Task<IEnumerable<SBEvent>> GetAllEvents();
    Task<SBEvent> GetEventById(int id);
    Task<SBEvent> CreateEvent(SBEvent @event);
    Task<SBEvent> UpdateEvent(int id, SBEvent updatedEvent);
    Task<bool> DeleteEvent(int id);
    Task<IEnumerable<SBEvent>> GetEventsInRange(DateTime start, DateTime end);
}