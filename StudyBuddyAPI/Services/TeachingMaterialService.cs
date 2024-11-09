
public class TeachingMaterialService
{
    private readonly List<TeachingMaterial> materials = new List<TeachingMaterial>();

    // Add a new TeachingMaterial
    public void AddMaterial(TeachingMaterial material)
    {
        materials.Add(material);
        Console.WriteLine($"Added: {material.Title}");
    }

    // Retrieve all TeachingMaterials
    public List<TeachingMaterial> GetAllMaterials()
    {
        return materials;
    }

    // Retrieve a TeachingMaterial by Title
    public TeachingMaterial GetMaterialByTitle(string title)
    {
        return materials.Find(m => m.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
    }

    // Retrieve a TeachingMaterial by Author
    // public TeachingMaterial GetMaterialByAuthor(Student author)
    // {
    //     return materials.Find(m =>
    //         m.Author != null &&
    //         m.Author.IsTutor == author.IsTutor &&
    //         m.Author.Language.Equals(author.Language, StringComparison.OrdinalIgnoreCase) &&
    //         m.Author.Semester == author.Semester &&
    //         m.Author.Bachelor == author.Bachelor
    //     );
    // }


    // Update an existing TeachingMaterial by Title
    public bool UpdateMaterial(string title, string newDescription, bool newIsApproved, Student newAuthor)
    {
        var material = GetMaterialByTitle(title);
        if (material == null) return false;

        material.Description = newDescription;
        material.IsApproved = newIsApproved;
        material.Author = newAuthor;
        Console.WriteLine($"Updated: {title}");
        return true;
    }

    // Delete a TeachingMaterial by Title
    public bool DeleteMaterial(string title)
    {
        var material = GetMaterialByTitle(title);
        if (material == null) return false;

        materials.Remove(material);
        Console.WriteLine($"Deleted: {title}");
        return true;
    }

/*     public async Task<IEnumerable<string>> SearchTeachingMaterials(string searchTerm)
    {
        var result = await Task.Run(() =>
        {
            return context.TeachingMaterials
                .Where(tm => tm.Name.Contains(searchTerm))
                .Select(tm => tm.Name)
                .ToList();
        });

        return result;
    }*/
}
