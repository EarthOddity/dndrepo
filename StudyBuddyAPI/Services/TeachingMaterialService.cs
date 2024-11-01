{
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
      public TeachingMaterial GetMaterialByAuthor(Student author)
{
    return materials.Find(m =>
        m.Author != null &&
        m.Author.isTutor == author.isTutor &&
        m.Author.language.Equals(author.language, StringComparison.OrdinalIgnoreCase) &&
        m.Author.bachelor == author.bachelor
    );
}


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
    }
}
