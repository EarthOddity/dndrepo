
public interface IBachelorService
{
    Task<IEnumerable<Bachelor>> GetAllBachelors();
    Task<Bachelor> GetBachelorById(int id);
    Task<Bachelor> CreateBachelor(Bachelor bachelor);
    Task UpdateBachelor(int id, Bachelor updatedBachelor);
    Task<bool> DeleteBachelor(int id);
    Task<bool> AddSubjectToBachelor(int bachelorId, int subjectId);
    Task<List<Subject>> GetSubjectsByBachelorId(int bachelorId);
    Task<Bachelor> GetBachelorByStudentId(int studentId);
    Task<IEnumerable<Bachelor>> SearchBachelors(string searchTerm);
}
