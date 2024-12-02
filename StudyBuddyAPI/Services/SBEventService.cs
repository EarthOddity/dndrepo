public class SBEventService(FileContext context) : ISBEventService
{
    private readonly FileContext _context = context;

    public Task<IEnumerable<SBEvent>> GetAllEvents()
    {
        return Task.FromResult(_context.Events.AsEnumerable());
    }


    public async Task<SBEvent> GetEventById(int id)
    {
        var @event = _context.Events.FirstOrDefault(e => e.id == id);
        if (@event == null)
        {
            throw new KeyNotFoundException($"Event with id {id} not found.");
        }
        return await Task.FromResult(@event);
    }
    public async Task<SBEvent> CreateEvent(SBEvent @event)
    {
        _context.Events.Add(@event);
        await _context.SaveChangesAsync();
        return @event;
    }

    public async Task<bool> UpdateEvent(int id, SBEvent updatedEvent)
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

    public async Task<IEnumerable<SBEvent>> GetEventsInRange(DateTime start, DateTime end)
    {
        var eventsInRange = _context.Events.Where(e => e.startTime >= start && e.endTime <= end);
        return await Task.FromResult(eventsInRange.AsEnumerable());
    }

}