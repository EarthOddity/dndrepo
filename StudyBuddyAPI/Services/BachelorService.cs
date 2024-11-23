public class BachelorService(FileContext context) : IBachelorService
{
    private readonly FileContext _context = context;

    public Task<IEnumerable<Bachelor>> GetAllBachelors()
    {
        return Task.FromResult(_context.Bachelors.AsEnumerable());
    }

    public async Task<Bachelor> GetBachelorById(int id)
    {
        var bachelor = _context.Bachelors.FirstOrDefault(b => b.id == id);
        return await Task.FromResult(bachelor);
    }

    public async Task<Bachelor> CreateBachelor(Bachelor bachelor)
    {
        _context.Bachelors.Add(bachelor);
        await _context.SaveChangesAsync();
        return bachelor;
    }

    public async Task UpdateBachelor(int id, Bachelor updatedBachelor)
    {
        var index = _context.Bachelors.FindIndex(b => b.id == id);
        if (index != -1)
        {
            _context.Bachelors[index] = updatedBachelor;
            await _context.SaveChangesAsync();

        }
    }

    public async Task<bool> DeleteBachelor(int id)
    {
        var bachelor = _context.Bachelors.FirstOrDefault(b => b.id == id);
        if (bachelor != null)
        {
            _context.Bachelors.Remove(bachelor);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public Task<bool> AddSubjectToBachelor(int bachelorId, Subject subject)
    {
        var bachelor = _context.Bachelors.FirstOrDefault(b => b.id == bachelorId);
        if (bachelor != null)
        {
            bachelor.associatedSubjects.Add(subject);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    public async Task<List<Subject>> GetSubjectsByBachelorId(int bachelorId)
    {
        var bachelor = _context.Bachelors.FirstOrDefault(b => b.id == bachelorId);
        if (bachelor != null)
        {
            return await Task.FromResult(bachelor.associatedSubjects);
        }
        return await Task.FromResult(new List<Subject>());
    }

    public Task<Bachelor> GetBachelorByStudentId(int studentId)
    {
        var bachelor = context.Students
            .Where(s => s.id == studentId)
            .Select(s => s.bachelor)
            .FirstOrDefault();

        return Task.FromResult(bachelor);
    }

    public async Task<IEnumerable<Bachelor>> SearchBachelors(string searchTerm)
    {
        var bachelors = _context.Bachelors.Where(b => b.programName.Contains(searchTerm));
        return await Task.FromResult(bachelors);
    }
}