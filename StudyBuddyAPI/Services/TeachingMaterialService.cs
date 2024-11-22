
public class TeachingMaterialService : ITeachingMaterialService
{
    //private static List<Student> studentsList = new List<Student>();
    private readonly FileContext context;

    public TeachingMaterialService(FileContext context)
    {
        this.context = context;
    }

    public async Task<TeachingMaterial> CreateTeachingMaterial(TeachingMaterial material)
    {
        context.TeachingMaterials.Add(material);
        return await Task.FromResult(material);
    }

    public async Task<IEnumerable<TeachingMaterial>> GetAllMaterials()
    {
        return await Task.FromResult(context.TeachingMaterials.AsEnumerable());
    }

    public Task<TeachingMaterial> GetMaterialById(int id)
    {
        return Task.FromResult(context.TeachingMaterials.FirstOrDefault(m => m.id == id));
    }

    public Task<TeachingMaterial> GetMaterialByAuthor(Student author)
    {
        var material = context.TeachingMaterials.Find(m =>
            m.author != null &&
            m.author.Equals(author)
        );
        return Task.FromResult(material);
    }
    public Task<IEnumerable<TeachingMaterial>> GetMaterialByTitle(string title)
    {
        var material = context.TeachingMaterials.Where(m => m.title == title);
        return Task.FromResult(material);
    }
    public async Task<bool> UpdateMaterial(int id, string description, bool isApproved, Student author)
    {
        var material = context.TeachingMaterials.FirstOrDefault(r => r.id == id);
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
        var material = context.TeachingMaterials.FirstOrDefault(r => r.id == id);
        if (material == null)
        {
            context.TeachingMaterials.Remove(material);
            await context.SaveChangesAsync();
            return true;
        }
        return false;


    }

    public Task<IEnumerable<TeachingMaterial>> SearchTeachingMaterials(string searchTerm)
    {
        var materials = context.TeachingMaterials.Where(m => m.title.Contains(searchTerm) || m.description.Contains(searchTerm));
        return Task.FromResult(materials);
    }

}