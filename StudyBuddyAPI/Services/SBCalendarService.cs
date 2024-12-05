using Microsoft.EntityFrameworkCore;

public class SBCalendarService : ISBCalendarService
{
    private readonly DatabaseContext _context;


    public SBCalendarService(DatabaseContext context)
    {
        _context = context;
    }


    public Task<IEnumerable<SBCalendar>> GetAllCalendars()
    {
        return Task.FromResult(_context.Calendars.Include(c => c.EventList).AsEnumerable());
    }

    public async Task<SBCalendar> GetCalendarById(int id)
    {
        var calendar = await _context.Calendars.Include(c => c.EventList).FirstOrDefaultAsync(c => c.Id == id);
        return calendar;
    }

    public async Task<SBCalendar> CreateCalendar(SBCalendar calendar)
    {
        _context.Calendars.Add(calendar);
        await _context.SaveChangesAsync();
        return calendar;
    }

    public async Task<SBCalendar> UpdateCalendar(int id, SBCalendar updatedCalendar)
    {
        var calendar = await _context.Calendars.FindAsync(id);
        if (calendar == null)
        {
            return null;
        }

        calendar.EventList = updatedCalendar.EventList;
        await _context.SaveChangesAsync();
        return calendar;
    }

    public async Task<bool> DeleteCalendar(int id)
    {
        var calendar = await _context.Calendars.FindAsync(id);
        if (calendar != null)
        {
            _context.Calendars.Remove(calendar);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<IEnumerable<SBEvent>> GetEventsByCalendarId(int calendarId)
    {
        var calendar = _context.Calendars.FirstOrDefault(c => c.Id == calendarId);
        return await Task.FromResult(calendar?.EventList.AsEnumerable() ?? Enumerable.Empty<SBEvent>());
    }


    public async Task<SBCalendar> AddEventToCalendar(int calendarId, SBEvent eventToAdd)
    {
        var calendar = await _context.Calendars.Include(c => c.EventList).FirstOrDefaultAsync(c => c.Id == calendarId);
        if (calendar != null && calendar.EventList != null)
        {
            calendar.EventList.Add(eventToAdd);
            await _context.SaveChangesAsync();

        }
        return calendar;
    }

    public async Task<SBCalendar> DeleteEventFromCalendar(int calendarId, int eventId)
    {
        var calendar = await _context.Calendars.Include(c => c.EventList).FirstOrDefaultAsync(c => c.Id == calendarId);
        if (calendar != null)
        {
            var eventToRemove = calendar.EventList.FirstOrDefault(e => e.Id == eventId);
            if (eventToRemove != null)
            {
                calendar.EventList.Remove(eventToRemove);
                await _context.SaveChangesAsync();
            }
        }
        return calendar;
    }

    public async Task<SBCalendar> GetCalendarByUserId(int userId)
    {
        return await _context.Calendars.Include(c => c.EventList).FirstOrDefaultAsync(c => c.OwnerId == userId);
    }

}