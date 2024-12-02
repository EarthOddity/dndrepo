
public class AcademicService : IAcademicService
{
    private readonly HttpClient _httpClient;

    public AcademicService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Teaching Material Methods
    public async Task<IEnumerable<TeachingMaterial>> GetAllMaterials()
    {
        var response = await _httpClient.GetAsync("api/TeachingMaterial");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IEnumerable<TeachingMaterial>>();
    }

    public async Task<TeachingMaterial> GetMaterialById(int id)
    {
        var response = await _httpClient.GetAsync($"api/TeachingMaterial/{id}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TeachingMaterial>();
    }

    public async Task<TeachingMaterial> CreateMaterial(TeachingMaterial material)
    {
        var response = await _httpClient.PostAsJsonAsync("api/TeachingMaterial", material);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TeachingMaterial>();
    }

    public async Task UpdateMaterial(int id, TeachingMaterial material)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/TeachingMaterial/{id}", material);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Failed to update material. Status code: {response.StatusCode}");
        }
    }

    public async Task DeleteMaterial(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/TeachingMaterial/{id}");
        response.EnsureSuccessStatusCode();
    }

    public async Task<IEnumerable<TeachingMaterial>> GetMaterialByAuthor(Student author)
    {
        var response = await _httpClient.GetAsync($"api/TeachingMaterial/author/{author.id}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IEnumerable<TeachingMaterial>>();
    }

    public async Task<IEnumerable<TeachingMaterial>> GetMaterialByTitle(string title)
    {
        var response = await _httpClient.GetAsync($"api/TeachingMaterial/title/{title}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IEnumerable<TeachingMaterial>>();
    }

    public async Task<IEnumerable<TeachingMaterial>> SearchMaterials(string searchTerm)
    {
        var response = await _httpClient.GetAsync($"api/TeachingMaterial/search/{searchTerm}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IEnumerable<TeachingMaterial>>();
    }

    public async Task<IEnumerable<TeachingMaterial>> GetSavedMaterialsByUserId(int userId)
    {
        var response = await _httpClient.GetAsync($"api/TeachingMaterial/saved/{userId}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IEnumerable<TeachingMaterial>>();
    }

    public async Task ToggleSaveMaterial(int userId, int materialId)
    {
        var response = await _httpClient.PostAsync($"api/TeachingMaterial/toggle-save?userId={userId}&materialId={materialId}", null);
        response.EnsureSuccessStatusCode();
    }

    // Bachelor Methods
    public async Task<IEnumerable<Bachelor>> GetAllBachelors()
    {
        var response = await _httpClient.GetAsync("api/Bachelor");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IEnumerable<Bachelor>>();
    }

    public async Task<Bachelor> GetBachelorById(int id)
    {
        var response = await _httpClient.GetAsync($"api/Bachelor/{id}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Bachelor>();
    }

    public async Task<Bachelor> CreateBachelor(Bachelor bachelor)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Bachelor", bachelor);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Bachelor>();
    }

    public async Task UpdateBachelor(int id, Bachelor bachelor)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Bachelor/{id}", bachelor);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Failed to update bachelor. Status code: {response.StatusCode}");
        }
    }

    public async Task DeleteBachelor(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/Bachelor/{id}");
        response.EnsureSuccessStatusCode();
    }

    public async Task AddSubjectToBachelor(int bachelorId, Subject subject)
    {
        var response = await _httpClient.PostAsJsonAsync($"api/Bachelor/{bachelorId}/subjects", subject);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Failed to add subject. Status code: {response.StatusCode}");
        }
    }

    public async Task<List<Subject>> GetSubjectsByBachelorId(int bachelorId)
    {
        var response = await _httpClient.GetAsync($"api/Bachelor/{bachelorId}/subjects");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<List<Subject>>();
    }

    public async Task<Bachelor> GetBachelorByStudentId(int studentId)
    {
        var response = await _httpClient.GetAsync($"api/Bachelor/student/{studentId}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Bachelor>();
    }

    public async Task<IEnumerable<Bachelor>> SearchBachelors(string searchTerm)
    {
        var response = await _httpClient.GetAsync($"api/Bachelor/search/{searchTerm}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IEnumerable<Bachelor>>();
    }
}