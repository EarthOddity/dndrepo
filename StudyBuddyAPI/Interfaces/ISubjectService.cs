public interface ISubjectService
{
    Task<IEnumerable<Subject>> GetAllSubjects();
    Task<Subject> GetSubjectById(int id);
    Task<Subject> GetSubjectByName(string name);
    Task<Subject> AddSubject(Subject subject);
    Task UpdateSubject(Subject updatedSubject);
    Task<bool> DeleteSubject(int id);
    Task<IEnumerable<string>> SearchSubjectsByName(string searchTerm);

}