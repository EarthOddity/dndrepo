using Microsoft.EntityFrameworkCore;
public class BachelorService(DatabaseContext context) : IBachelorService
{
    private readonly DatabaseContext _context = context;

    public Task<IEnumerable<Bachelor>> GetAllBachelors()
    {
        return Task.FromResult(_context.Bachelors.AsEnumerable());
    }

    public async Task<Bachelor> GetBachelorById(int id)
    {
        var bachelor = _context.Bachelors.FirstOrDefault(b => b.Id == id);
        return await Task.FromResult(bachelor);
    }

    public async Task<Bachelor> CreateBachelor(Bachelor bachelor)
    {
        _context.Bachelors.AddAsync(bachelor);
        await _context.SaveChangesAsync();
        return bachelor;
    }

    public async Task UpdateBachelor(int id, Bachelor updatedBachelor)
    {
        var bachelor = await _context.Bachelors.FindAsync(id);
        if (bachelor != null)
        {
            _context.Entry(bachelor).CurrentValues.SetValues(updatedBachelor);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> DeleteBachelor(int id)
    {
        var bachelor = _context.Bachelors.FirstOrDefault(b => b.Id == id);
        if (bachelor != null)
        {
            _context.Bachelors.Remove(bachelor);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<bool> AddSubjectToBachelor(int bachelorId, Subject subject)
    {
        var bachelor = _context.Bachelors.FirstOrDefault(b => b.Id == bachelorId);
        if (bachelor != null)
        {
            bachelor.AssociatedSubjects.Add(subject);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<List<Subject>> GetSubjectsByBachelorId(int bachelorId)
    {
        var bachelor = await _context.Bachelors
            .Include(b => b.AssociatedSubjects)
            .FirstOrDefaultAsync(b => b.Id == bachelorId);
        return bachelor?.AssociatedSubjects.ToList() ?? new List<Subject>();
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
        var bachelors = _context.Bachelors.Where(b => b.ProgramName.Contains(searchTerm));
        return await Task.FromResult(bachelors);
    }
}