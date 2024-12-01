public class BachelorService : IBachelorService
{
    private readonly DatabaseContext context;

    public BachelorService(DatabaseContext context)
    {
        context = context;
    }

    public async Task<IEnumerable<Bachelor>> GetAllBachelors()
    {
        return await context.Bachelors.ToListAsync();
    }

    public async Task<Bachelor> GetBachelorById(int id)
    {
        var bachelor = await context.Bachelors.FindAsync(id);
        return bachelor;
    }

    public async Task<Bachelor> CreateBachelor(Bachelor bachelor)
    {
        await context.Bachelors.AddAsync(bachelor);
        await context.SaveChangesAsync();
        return bachelor;
    }

    public async Task UpdateBachelor(int id, Bachelor updatedBachelor)
    {
        var bachelor = await context.Bachelors.FindAsync(id);
        if (bachelor == null)
            throw new KeyNotFoundException($"Bachelor with ID {id} not found");

        context.Entry(bachelor).CurrentValues.SetValues(updatedBachelor);
        await context.SaveChangesAsync();
    }

    public async Task<bool> DeleteBachelor(int id)
    {
        var bachelor = await context.Bachelors.FindAsync(id);
        if (bachelor != null)
        {
            context.Bachelors.Remove(bachelor);
            await context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public Task<bool> AddSubjectToBachelor(int bachelorId, Subject subject)
    {
        var bachelor = await context.Bachelors
           .Include(b => b.associatedSubjects)
           .FirstOrDefaultAsync(b => b.id == bachelorId);

        if (bachelor == null)
            return false;

        bachelor.associatedSubjects.Add(subject);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Subject>> GetSubjectsByBachelorId(int bachelorId)
    {
        var bachelor = await context.Bachelors
       .Include(b => b.associatedSubjects)
       .FirstOrDefaultAsync(b => b.id == bachelorId);

        return bachelor?.associatedSubjects ?? new List<Subject>();
    }

    public Task<Bachelor> GetBachelorByStudentId(int studentId)
    {
        return await _context.Students
            .Where(s => s.id == studentId)
            .Select(s => s.bachelor)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Bachelor>> SearchBachelors(string searchTerm)
    {
        return await _context.Bachelors
     .Where(b => b.programName.Contains(searchTerm))
     .ToListAsync();
    }
}