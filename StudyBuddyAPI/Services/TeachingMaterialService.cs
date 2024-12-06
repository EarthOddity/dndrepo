using Microsoft.EntityFrameworkCore;

public class TeachingMaterialService : ITeachingMaterialService
{
    //private static List<Student> studentsList = new List<Student>();
    private readonly DatabaseContext context;

    public TeachingMaterialService(DatabaseContext context)
    {
        this.context = context;
    }

    public async Task<TeachingMaterial> CreateTeachingMaterial(TeachingMaterial material)
    {
        context.TeachingMaterials.AddAsync(material);
        await context.SaveChangesAsync();
        return await Task.FromResult(material);
    }

    public async Task<IEnumerable<TeachingMaterial>> GetAllMaterials()
    {
        return await Task.FromResult(context.TeachingMaterials.AsEnumerable());
    }

    public Task<TeachingMaterial> GetMaterialById(int id)
    {
        return Task.FromResult(context.TeachingMaterials.FirstOrDefault(m => m.Id == id));
    }

    public async Task<IEnumerable<TeachingMaterial>> GetMaterialByAuthor(Student author)
    {
        return await context.TeachingMaterials
            .Include(m => m.Author)
            .Where(m => m.Author != null && m.Author.Id == author.Id)
            .ToListAsync();
    }
    public Task<IEnumerable<TeachingMaterial>> GetMaterialByTitle(string title)
    {
        var material = context.TeachingMaterials.Where(m => m.Title == title).AsEnumerable();
        return Task.FromResult(material);
    }
    public async Task<bool> UpdateMaterial(int id, string title, string description, bool isApproved, Student author)
    {

        var material = context.TeachingMaterials.FirstOrDefault(r => r.Id == id);
        if (material != null)
        {
            material.Title = title;
            material.Description = description;
            material.IsApproved = isApproved;
            material.Author = author;
            await context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<bool> DeleteMaterial(int id)
    {
        Console.WriteLine("Deleting material with id: " + id);
        var material = context.TeachingMaterials.FirstOrDefault(material => material.Id == id);
        if (material == null)
        {
            return false;
        }
        context.TeachingMaterials.Remove(material);
        await context.SaveChangesAsync();
        return true;
    }


    public Task<IEnumerable<TeachingMaterial>> GetSavedMaterialsByUserId(int userId)
    {
        var savedMaterials = context.SavedMaterials
            .Where(sm => sm.UserId == userId)
            .Select(sm => sm.Material)
            .AsEnumerable();

        return Task.FromResult(savedMaterials);
    }

    public async Task<bool> ToggleSaveMaterial(int userId, int materialId)
    {
        var existingSave = await context.SavedMaterials
            .FirstOrDefaultAsync(sm => sm.UserId == userId && sm.MaterialId == materialId);

        if (existingSave != null)
        {
            // Unsave if already saved
            context.SavedMaterials.Remove(existingSave);
        }
        else
        {
            // Save if not already saved
            var savedMaterial = new SavedMaterial
            (
                Id: context.SavedMaterials.Any() ? context.SavedMaterials.Max(sm => sm.Id) + 1 : 1,
                UserId: userId,
                MaterialId: materialId,
                Material: context.TeachingMaterials.FirstOrDefault(m => m.Id == materialId),
                User: context.Students.FirstOrDefault(s => s.Id == userId)
            );
            await context.SavedMaterials.AddAsync(savedMaterial);
        }

        await context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<TeachingMaterial>> GetMaterialsBySubjectId(int subjectId)
    {
        return await context.TeachingMaterials
            .Where(m => m.SubjectId == subjectId)
            .ToListAsync();
    }

    public async Task<IEnumerable<TeachingMaterial>> SearchTeachingMaterials(string searchTerm)
    {
        return await context.TeachingMaterials
         .Include(m => m.Author)
         .Include(m => m.Subject)
         .Where(m => m.Title.Contains(searchTerm) ||
                     m.Description.Contains(searchTerm) ||
                     m.Subject.Name.Contains(searchTerm) ||
                     m.Author.Name.Contains(searchTerm))
         .ToListAsync();
    }

}