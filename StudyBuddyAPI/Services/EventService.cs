public class EventService(FileContext context) : IEventService
{
    private readonly FileContext _context = context;

    public Task<IEnumerable<Event>> GetAllEvents()
    {
        return Task.FromResult(_context.Events.AsEnumerable());
    }

    public async Task<Event> GetEventById(int id)
    {
        var @event = _context.Events.FirstOrDefault(e => e.id == id);
        return await Task.FromResult(@event);
    }

    public async Task<Event> CreateEvent(Event @event)
    {
        _context.Events.Add(@event);
        await _context.SaveChangesAsync();
        return @event;
    }

    public async Task<bool> UpdateEvent(int id, Event updatedEvent)
    {
        var eventToUpdate = _context.Events.FirstOrDefault(e => e.id == id);
        if (eventToUpdate != null)
        {
            eventToUpdate.title = updatedEvent.title;
            eventToUpdate.description = updatedEvent.description;
            eventToUpdate.startTime = updatedEvent.startTime;
            eventToUpdate.endTime = updatedEvent.endTime;
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<bool> DeleteEvent(int id)
    {
        var @event = _context.Events.FirstOrDefault(b => b.id == id);
        if (@event != null)
        {
            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<IEnumerable<Event>> GetEventsInRange(DateTime start, DateTime end)
    {
        var eventsInRange = _context.Events.Where(e => e.startTime >= start && e.endTime <= end);
        return await Task.FromResult(eventsInRange.AsEnumerable());
    }

}