public class BachelorService
{
    private static List<Bachelor> _bachelorsList = new List<Bachelor>();
    public Task<IEnumerable<Bachelor>> GetAllBachelors()
    {
        return Task.FromResult(_bachelorsList.AsEnumerable());
    }

    public Task<Bachelor> GetBachelorById(int id)
    {
        var bachelor = _bachelorsList.FirstOrDefault(b => b.id == id);
        return Task.FromResult(bachelor);
    }

    public Task<Bachelor> CreateBachelor(Bachelor bachelor)
    {
        _bachelorsList.Add(bachelor);
        return Task.FromResult(bachelor);
    }

    public Task UpdateBachelor(int id, Bachelor updatedBachelor)
    {
        var index = _bachelorsList.FindIndex(b => b.id == id);
        if (index != -1)
        {
            _bachelorsList[index] = updatedBachelor;
        }
        return Task.CompletedTask;
    }

    public Task<bool> DeleteBachelor(int id)
    {
        var bachelor = _bachelorsList.FirstOrDefault(b => b.id == id);
        if (bachelor != null)
        {
            _bachelorsList.Remove(bachelor);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    public Task<bool> AddSubjectToBachelor(int bachelorId, Subject subject)
    {
        var bachelor = _bachelorsList.FirstOrDefault(b => b.id == bachelorId);
        if (bachelor != null)
        {
            bachelor.associatedSubjects.Add(subject);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    public Task<List<Subject>> GetSubjectsByBachelorId(int bachelorId)
    {
        var bachelor = _bachelorsList.FirstOrDefault(b => b.id == bachelorId);
        if (bachelor != null)
        {
            return Task.FromResult(bachelor.associatedSubjects);
        }
        return Task.FromResult(new List<Subject>());
    }

/*  public async Task<IEnumerable<string>> SearchBachelors(string searchTerm)
    {
        var result = await Task.Run(() =>
        {
            return context.Bachelors
                .Where(b => b.Name.Contains(searchTerm))
                .Select(b => b.Name)
                .ToList();
        });

        return result;
    }*/
}