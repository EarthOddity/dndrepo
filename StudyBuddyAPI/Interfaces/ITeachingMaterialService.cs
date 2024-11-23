public interface ITeachingMaterialService
{
    Task<IEnumerable<TeachingMaterial>> GetAllMaterials();
    Task<TeachingMaterial> GetMaterialById(int id);
    Task<TeachingMaterial> GetMaterialByAuthor(Student author);
    Task<TeachingMaterial> CreateTeachingMaterial(TeachingMaterial material);
    Task<bool> UpdateMaterial(int id, string description, bool isApproved, Student author);
    Task<bool> DeleteMaterial(int id);
    Task<IEnumerable<TeachingMaterial>> GetMaterialByTitle(string title);
    Task<IEnumerable<TeachingMaterial>> GetSavedMaterialsByUserId(int userId);
    Task<IEnumerable<TeachingMaterial>> SearchTeachingMaterials(string searchTerm);
}