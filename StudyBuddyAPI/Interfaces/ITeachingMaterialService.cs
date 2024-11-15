public interface {
    Task<IEnumerable<TeachingMaterial>> GetAllMaterials();
    Task<TeachingMaterial> GetMaterialById(int id);
    Task<TeachingMaterial> CreateTeachingMaterial (TeachingMaterial material);
    Task UpdateMaterial(int id, string newDescription, bool newIsApproved, Student newAuthor);
    Task DeleteMaterial(int id);
    Task<IEnumerable<TeachingMaterial>> GetMaterialByTitle(string title);
    }