public class ProfileService : IProfileService
{
    private readonly HttpClient _httpClient;

    public ProfileService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Student> GetStudentProfile(int id)
    {
        var response = await _httpClient.GetAsync($"api/Student/{id}");
        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return null; //for now
        }
        return await response.Content.ReadFromJsonAsync<Student>();
    }

    public async Task UpdateStudentProfile(int id, Student student)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Student/{id}", student);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Failed to update student. Status code: {response.StatusCode}");
        }
    }

    public async Task DeleteStudentProfile(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/Student/{id}");
        response.EnsureSuccessStatusCode();
    }

    public async Task<Moderator> GetModeratorProfile(int id)
    {
        var response = await _httpClient.GetAsync($"api/Moderator/{id}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Moderator>();
    }

    public async Task UpdateModeratorProfile(int id, Moderator moderator)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Moderator/{id}", moderator);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Failed to update moderator. Status code: {response.StatusCode}");
        }
    }

    public async Task DeleteModeratorProfile(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/Moderator/{id}");
        response.EnsureSuccessStatusCode();
    }
}