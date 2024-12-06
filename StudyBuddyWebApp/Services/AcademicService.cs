using System.Text.Json;

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
        var content = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Response content: {content}");
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
        var response = await _httpClient.GetAsync($"api/TeachingMaterial/author/{author.Id}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IEnumerable<TeachingMaterial>>();
    }

    public async Task<IEnumerable<TeachingMaterial>> GetMaterialByTitle(string title)
    {
        var response = await _httpClient.GetAsync($"api/TeachingMaterial/title/{title}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IEnumerable<TeachingMaterial>>();
    }

    public async Task<IEnumerable<TeachingMaterial>> GetMaterialsBySubjectId(int subjectId)
    {
        var response = await _httpClient.GetAsync($"api/TeachingMaterial/subject/{subjectId}");
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

    public async Task<bool> ToggleSaveMaterial(int userId, int materialId)
    {
        var response = await _httpClient.PostAsync($"api/TeachingMaterial/toggle-save?userId={userId}&materialId={materialId}", null);
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        return false;
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

    public async Task AddSubjectToBachelor(int bachelorId, int subjectId)
    {
        var response = await _httpClient.PostAsync($"api/Bachelor/{bachelorId}/add-subject/{subjectId}", null);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Failed to add subject. Status code: {response.StatusCode}");
        }
    }

    public async Task<List<Subject>> GetSubjectsByBachelorId(int bachelorId)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/Bachelor/{bachelorId}/subjects");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Raw JSON response: {content}");

            // Deserialize directly to List<Subject>
            var subjects = await response.Content.ReadFromJsonAsync<List<Subject>>();
            return subjects ?? new List<Subject>();
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"JSON Deserialization Error: {ex.Message}");
            Console.WriteLine($"Stack Trace: {ex.StackTrace}");
            return new List<Subject>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"General Error: {ex.Message}");
            return new List<Subject>();
        }

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

    // Subject Methods
    public async Task<IEnumerable<Subject>> GetAllSubjects()
    {
        var response = await _httpClient.GetAsync("api/Subject");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IEnumerable<Subject>>();
    }

    public async Task<Subject> GetSubjectById(int id)
    {
        var response = await _httpClient.GetAsync($"api/Subject/{id}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Subject>();
    }

    public async Task<Subject> GetSubjectByName(string name)
    {
        var response = await _httpClient.GetAsync($"api/Subject/name/{name}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Subject>();
    }

    public async Task<Subject> AddSubject(Subject subject)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Subject", subject);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Subject>();
    }

    public async Task UpdateSubject(Subject updatedSubject)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Subject/{updatedSubject.Id}", updatedSubject);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Failed to update subject. Status code: {response.StatusCode}");
        }
    }

    public async Task<bool> DeleteSubject(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/Subject/{id}");
        return response.IsSuccessStatusCode;
    }

    public async Task<IEnumerable<Subject>> SearchSubjectsByName(string searchTerm)
    {
        var response = await _httpClient.GetAsync($"api/Subject/search/{searchTerm}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IEnumerable<Subject>>();
    }

    // Review Methods
    public async Task<IEnumerable<Review>> GetAllReviews()
    {
        var response = await _httpClient.GetAsync("api/Review");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IEnumerable<Review>>();
    }

    public async Task<Review> GetReviewById(int id)
    {
        var response = await _httpClient.GetAsync($"api/Review/{id}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Review>();
    }

    public async Task<List<Review>> GetReviewsByAuthor(int authorId)
    {
        var response = await _httpClient.GetAsync($"api/Review/author/{authorId}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<List<Review>>();
    }

    public async Task<Review> AddReview(Review review)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Review", review);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Review>();
    }

    public async Task<bool> UpdateReview(int id, string reviewText, bool isApproved)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Review/{id}", new { reviewText, isApproved });
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteReview(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/Review/{id}");
        return response.IsSuccessStatusCode;
    }

    public async Task<IEnumerable<Review>> GetReviewsByMaterialId(int materialId)
    {
        var response = await _httpClient.GetAsync($"api/Review/material/{materialId}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IEnumerable<Review>>();
    }
}