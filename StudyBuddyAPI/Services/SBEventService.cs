using Microsoft.EntityFrameworkCore;

public class SBEventService : ISBEventService
{
    private readonly DatabaseContext _context;
    public SBEventService(DatabaseContext context)
    {
        _context = context;
    }

    public Task<IEnumerable<SBEvent>> GetAllEvents()
    {
        return Task.FromResult(_context.Events.AsEnumerable());
    }


    public async Task<SBEvent> GetEventById(int id)
    {
        var @event = await _context.Events.FirstOrDefaultAsync(e => e.Id == id);
        if (@event == null)
        {
            throw new KeyNotFoundException($"Event with id {id} not found.");
        }
        return @event;
    }
    public async Task<SBEvent> CreateEvent(SBEvent @event)
    {
        _context.Events.Add(@event);
        await _context.SaveChangesAsync();
        return @event;
    }

    public async Task<SBEvent> UpdateEvent(int id, SBEvent updatedEvent)
    {
        var eventToUpdate = _context.Events.FirstOrDefault(e => e.Id == id);
        if (eventToUpdate != null)
        {
            eventToUpdate.Title = updatedEvent.Title;
            eventToUpdate.Description = updatedEvent.Description;
            eventToUpdate.StartTime = updatedEvent.StartTime;
            eventToUpdate.EndTime = updatedEvent.EndTime;
            await _context.SaveChangesAsync();
            return updatedEvent;
        }
        return null;
    }

    public async Task<bool> DeleteEvent(int id)
    {
        var @event = _context.Events.FirstOrDefault(b => b.Id == id);
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
        var eventsInRange = _context.Events.Where(e => e.StartTime >= start && e.EndTime <= end);
        return await Task.FromResult(eventsInRange.AsEnumerable());
    }

}