
public class SubjectService
{
    private static List<Subject> subjects = new List<Subject>();
    public void AddSubject(Subject subject)
    {
        subjects.Add(subject);
    }

    public Subject GetSubjectById(int id)
    {
        return subjects.FirstOrDefault(s => s.Id == id);
    }
    public Subject GetSubjectByName(string name)
    {
        return subjects.FirstOrDefault(s => s.Name == name);
    }

    public IEnumerable<Subject> GetAllSubjects()
    {
        return subjects;
    }
    public void UpdateSubject(Subject updatedSubject)
    {
        var subject = GetSubjectById(updatedSubject.Id);
        if (subject != null)
        {
            subject.Name = updatedSubject.Name;
            subject.Description = updatedSubject.Description;
        }
    }
    public bool DeleteSubject(int Id)
    {
        var subject = GetSubjectById(Id);
        if (subject != null)
        {
            subjects.Remove(subject);
            return true;
        }
        return false;
    }


}


