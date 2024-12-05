public class CalendarService : ICalendarService
{
    private readonly HttpClient _httpClient;

    public CalendarService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<IEnumerable<SBCalendar>> GetAllCalendars()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/SBCalendar");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<IEnumerable<SBCalendar>>();
            if (result == null)
            {
                throw new NullReferenceException("Failed to retrieve calendars.");
            }
            return result;
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"Failed to retrieve calendars. {ex.Message}");
        }
    }

    public async Task<SBCalendar> GetCalendarById(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/SBCalendar/{id}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<SBCalendar>();
            if (result == null)
            {
                throw new NullReferenceException("Failed to retrieve calendar. No calendar with that id exists.");
            }
            return result;
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"Failed to retrieve calendar. {ex.Message}");
        }
    }

   /*  public async Task<SBCalendar> CreateCalendar(Student student)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/SBCalendar", student);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<SBCalendar>(); ;
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"Failed to create calendar. {ex.Message}");
        }
    } */

    public async Task<SBCalendar> UpdateCalendar(int calendarId, SBCalendar updatedCalendar)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"api/SBCalendar/{calendarId}", updatedCalendar);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<SBCalendar>();
            if (result == null)
            {
                throw new NullReferenceException("Failed to retrieve calendar. No calendar with that id exists.");
            }
            return result;
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"Failed to update calendar. {ex.Message}");
        }
    }

    public async Task<bool> DeleteCalendar(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"api/SBCalendar/{id}");
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"Failed to delete calendar. {ex.Message}");
        }
    }

    /* // Event -> calendar methods
    public async Task<SBCalendar> AddEventToCalendar(int calendarId, SBEvent eventToAdd)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync($"api/SBCalendar/{calendarId}/event", eventToAdd);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<SBCalendar>();
            if (result == null)
            {
                throw new NullReferenceException("Failed to retrieve calendar. No calendar with that id exists.");
            }
            return result;
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"Failed to add event to calendar. {ex.Message}");
        }
    }

    public async Task<SBCalendar> DeleteEventFromCalendar(int calendarId, int eventId)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"api/SBCalendar/{calendarId}/events/{eventId}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<SBCalendar>();
            if (result == null)
            {
                throw new NullReferenceException("Failed to retrieve calendar for deletion. No calendar with that id exists.");
            }
            return result;
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"Failed to delete event from calendar. {ex.Message}");
        }
    } */

    // Event methods
    public async Task<SBEvent> GetEventById(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/SBEvent/{id}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<SBEvent>();
            if (result == null)
            {
                throw new NullReferenceException("Failed to retrieve event. No event with that id exists.");
            }
            return result;
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"Failed to retrieve event. {ex.Message}");
        }
    }

    public async Task<SBEvent> CreateEvent(SBEvent @event)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/SBEvent", @event);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<SBEvent>();
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"Failed to create event. {ex.Message}");
        }

    }

    public async Task<SBEvent> UpdateEvent(SBEvent @event)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"api/SBEvent/{@event.id}", @event);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<SBEvent>();
            if (result == null)
            {
                throw new NullReferenceException("Failed to update event. No event with that id exists.");
            }
            return result;
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"Failed to update event. {ex.Message}");
        }
    }

    public async Task<bool> DeleteEvent(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"api/SBEvent/{id}");
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"Failed to delete event. {ex.Message}");
        }
    }

    public async Task<IEnumerable<SBEvent>> GetEventsByCalendarId(int calendarId)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/SBEvent/calendar/{calendarId}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<IEnumerable<SBEvent>>();
            if (result == null)
            {
                throw new NullReferenceException("Failed to retrieve events. No events with that calendar id exists.");
            }
            return result;
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"Failed to retrieve events. {ex.Message}");
        }
    }

    // Get calendar by user id
    public async Task<SBCalendar> GetCalendarByUserId(int studentId)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/Student/{studentId}/calendar");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<SBCalendar>();
            if (result == null)
            {
                throw new NullReferenceException("Failed to retrieve calendar for student. No calendar with that student id exists.");
            }
            return result;
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"Failed to retrieve calendar for student. {ex.Message}");
        }
    }

}