
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
        var subject = context.Subjects.FirstOrDefault(s => s.Id == id);
        return Task.FromResult(subject);
    }
    public Task<Subject> GetSubjectByName(string name)
    {
        var subject = context.Subjects.FirstOrDefault(s => s.Name == name);
        return Task.FromResult(subject);
    }

    public Task<IEnumerable<Subject>> GetAllSubjects()
    {
        return Task.FromResult(context.Subjects.AsEnumerable());
    }
    public async Task UpdateSubject(Subject updatedSubject)
    {
        var subjectToUpdate = context.Subjects.FirstOrDefault(s => s.Id == updatedSubject.Id);
        if (subjectToUpdate != null)
        {
            subjectToUpdate.Name = updatedSubject.Name;
            subjectToUpdate.Description = updatedSubject.Description;
            await context.SaveChangesAsync();
        }
    }

    public async Task<bool> DeleteSubject(int id)
    {
        var subject = context.Subjects.FirstOrDefault(subject => subject.Id == id);
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
            .Where(s => s.Name.ToLower().Contains(searchTerm.ToLower()));
        return await Task.FromResult(subjects);
    }

}


