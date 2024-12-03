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
    Task<bool> ToggleSaveMaterial(int userId, int materialId);

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

    // Subject methods
    Task<IEnumerable<Subject>> GetAllSubjects();
    Task<Subject> GetSubjectById(int id);
    Task<Subject> GetSubjectByName(string name);
    Task<Subject> AddSubject(Subject subject);
    Task UpdateSubject(Subject updatedSubject);
    Task<bool> DeleteSubject(int id);
    Task<IEnumerable<Subject>> SearchSubjectsByName(string searchTerm);

    // Review methods
    Task<IEnumerable<Review>> GetAllReviews();
    Task<Review> GetReviewById(int id);
    Task<List<Review>> GetReviewsByAuthor(int authorId);
    Task<Review> AddReview(Review review);
    Task<bool> UpdateReview(int id, string reviewText, bool isApproved);
    Task<bool> DeleteReview(int id);
    Task<IEnumerable<Review>> GetReviewsByMaterialId(int materialId);
}