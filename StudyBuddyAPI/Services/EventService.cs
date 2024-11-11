public class EventService
{
    private static List<Event> _eventsList = new List<Event>();

    public Task<IEnumerable<Event>> GetAllEvents()
    {
        return Task.FromResult(_eventsList.AsEnumerable());
    }

    public Task<Event> GetEventById(int id)
    {
        var @event = _eventsList.FirstOrDefault(e => e.id == id);
        return Task.FromResult(@event);
    }

    public Task<Event> CreateEvent(Event @event)
    {
        _eventsList.Add(@event);
        return Task.FromResult(@event);
    }

    public Task<bool> UpdateEvent(int id, Event updatedEvent)
    {
        var eventToUpdate = _eventsList.FirstOrDefault(e => e.id == id);
        if (eventToUpdate != null)
        {
            eventToUpdate.title = updatedEvent.title;
            eventToUpdate.description = updatedEvent.description;
            eventToUpdate.startTime = updatedEvent.startTime;
            eventToUpdate.endTime = updatedEvent.endTime;
            return Task.FromResult(true);

        }
        return Task.FromResult(false);
    }

    public Task<bool> DeleteEvent(int id)
    {
        var @event = _eventsList.FirstOrDefault(b => b.id == id);
        if (@event != null)
        {
            _eventsList.Remove(@event);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    public Task<IEnumerable<Event>> GetEventsInRange(DateTime start, DateTime end)
    {
        var eventsInRange = _eventsList.Where(e => e.startTime >= start && e.endTime <= end);
        return Task.FromResult(eventsInRange.AsEnumerable());
    }

}