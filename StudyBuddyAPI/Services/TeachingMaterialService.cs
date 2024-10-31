namespace StudyBuddyAPI.Services
{
    public class TeachingMaterialService
    {
        private readonly List<TeachingMaterial> materials = new List<TeachingMaterial>();

        public void AddMaterial(TeachingMaterial material)
        {
            materials.Add(material);
            Console.WriteLine($"Added: {material.Title}");
        }

        public List<TeachingMaterial> GetAllMaterials()
        {
            return materials;
        }

        public TeachingMaterial GetMaterialByTitle(string title)
        {
            return materials.Find(m => m.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }

        public TeachingMaterial GetMaterialByAuthor(Student author)
        {
            return materials.Find(m => 
                m.Author != null &&
                m.Author.Equals(author)
            );
        }

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