public interface IEventService
{
    Task<IEnumerable<Event>> GetAllEvents();
    Task<Event> GetEventById(int id);
    Task<Event> CreateEvent(Event @event);
    Task<bool> UpdateEvent(int id, Event updatedEvent);
    Task<bool> DeleteEvent(int id);
    Task<IEnumerable<Event>> GetEventsInRange(DateTime start, DateTime end);
}