public interface IAcademicService
{
    // TeachingMaterial methods
    Task<IEnumerable<TeachingMaterial>> GetAllMaterials();
    Task<TeachingMaterial> GetMaterialById(int id);
    Task<TeachingMaterial> CreateMaterial(TeachingMaterial material);
    Task UpdateMaterial(int id, TeachingMaterial material);
    Task DeleteMaterial(int id);
    Task<IEnumerable<TeachingMaterial>> GetMaterialByAuthor(Student author);
    Task<IEnumerable<TeachingMaterial>> GetMaterialByTitle(string title);
    Task<IEnumerable<TeachingMaterial>> SearchMaterials(string searchTerm);
    Task<IEnumerable<TeachingMaterial>> GetSavedMaterialsByUserId(int userId);
    Task ToggleSaveMaterial(int userId, int materialId);

    // Bachelor methods
    Task<IEnumerable<Bachelor>> GetAllBachelors();
    Task<Bachelor> GetBachelorById(int id);
    Task<Bachelor> CreateBachelor(Bachelor bachelor);
    Task UpdateBachelor(int id, Bachelor bachelor);
    Task DeleteBachelor(int id);
    Task AddSubjectToBachelor(int bachelorId, Subject subject);
    Task<List<Subject>> GetSubjectsByBachelorId(int bachelorId);
    Task<Bachelor> GetBachelorByStudentId(int studentId);
    Task<IEnumerable<Bachelor>> SearchBachelors(string searchTerm);
}