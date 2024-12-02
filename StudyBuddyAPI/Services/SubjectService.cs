
public class SubjectService(DatabaseContext context) : ISubjectService
{
    //private static List<Subject> subjects = new List<Subject>();

    private readonly DatabaseContext context = context;
    static SubjectService()
    {
    }
    public async Task<Subject> AddSubject(Subject subject)
    {
        context.Subjects.AddAsync(subject);
        await context.SaveChangesAsync();
        return subject;
    }

    public Task<Subject> GetSubjectById(int id)
    {
        var subject = context.Subjects.FirstOrDefault(s => s.id == id);
        return Task.FromResult(subject);
    }
    public Task<Subject> GetSubjectByName(string name)
    {
        var subject = context.Subjects.FirstOrDefault(s => s.name == name);
        return Task.FromResult(subject);
    }

    public Task<IEnumerable<Subject>> GetAllSubjects()
    {
        return Task.FromResult(context.Subjects.AsEnumerable());
    }
    public async Task UpdateSubject(Subject updatedSubject)
    {
        var subjectToUpdate = context.Subjects.FirstOrDefault(s => s.id == updatedSubject.id);
        if (subjectToUpdate != null)
        {
            subjectToUpdate.name = updatedSubject.name;
            subjectToUpdate.description = updatedSubject.description;
            await context.SaveChangesAsync();
        }
    }

    public async Task<bool> DeleteSubject(int id)
    {
        var subject = context.Subjects.FirstOrDefault(subject => subject.id == id);
        if (subject != null)
        {
            context.Subjects.Remove(subject);
            await context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<IEnumerable<Subject>> SearchSubjectsByName(string searchTerm)
    {
        var subjects = context.Subjects
            .Where(s => s.name.ToLower().Contains(searchTerm.ToLower()));
        return await Task.FromResult(subjects);
    }

}


