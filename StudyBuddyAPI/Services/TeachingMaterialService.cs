using Microsoft.EntityFrameworkCore;

public class TeachingMaterialService : ITeachingMaterialService
{
    private readonly DatabaseContext context;

    public TeachingMaterialService(DatabaseContext context)
    {
        this.context = context;
    }

    public async Task<TeachingMaterial> CreateTeachingMaterial(TeachingMaterial material)
    {
        await context.TeachingMaterials.AddAsync(material);
        await context.SaveChangesAsync();
        return material;
    }

    public async Task<IEnumerable<TeachingMaterial>> GetAllMaterials()
    {
        return await context.TeachingMaterials.ToListAsync();
    }

    public async Task<TeachingMaterial> GetMaterialById(int id)
    {
        return await context.TeachingMaterials.FirstOrDefaultAsync(id);
    }

    public Task<TeachingMaterial> GetMaterialByAuthor(Student author)
    {
        return await _context.TeachingMaterials
        .Include(m => m.author)
        .FirstOrDefaultAsync(m => m.author == author);
    }
    public Task<IEnumerable<TeachingMaterial>> GetMaterialByTitle(string title)
    {
        return await _context.TeachingMaterials
          .Where(m => m.title.Contains(title))
          .ToListAsync();
    }

    public async Task<bool> UpdateMaterial(int id, string description, bool isApproved, Student author)
    {
        var material = await context.TeachingMaterials.FindAsync(id);
        if (material != null)
        {
            material.description = description;
            material.isApproved = isApproved;
            material.author = author;
            await context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<bool> DeleteMaterial(int id)
    {
        var material = await context.TeachingMaterials.FindAsync(id);
        if (material == null)
        {
            context.TeachingMaterials.Remove(material);
            await context.SaveChangesAsync();
            return true;
        }
        return false;
    }


    public Task<IEnumerable<TeachingMaterial>> GetSavedMaterialsByUserId(int userId)
    {
        return await _context.SavedMaterials
            .Where(sm => sm.userId == userId)
            .Select(sm => sm.material)
            .ToListAsync();
    }

    public async Task<bool> ToggleSaveMaterial(int userId, int materialId)
    {
        var savedMaterial = await _context.SavedMaterials
                .FirstOrDefaultAsync(sm => sm.userId == userId && sm.materialId == materialId);

        if (savedMaterial != null)
        {
            _context.SavedMaterials.Remove(savedMaterial);
        }
        else
        {
            await _context.SavedMaterials.AddAsync(new SavedMaterial
            {
                userId = userId,
                materialId = materialId
            });
        }

        await _context.SaveChangesAsync();
        return true;
    }


    public Task<IEnumerable<TeachingMaterial>> SearchTeachingMaterials(string searchTerm)
    {
        return await _context.TeachingMaterials
                 .Where(m => m.title.Contains(searchTerm) ||
                            m.description.Contains(searchTerm))
                 .ToListAsync();
    }

}