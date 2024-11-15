public class TeachingMaterialService
    {
        private static List<TeachingMaterial> _materials = new List<TeachingMaterial>();

        public Task<TeachingMaterial> CreateMaterial(TeachingMaterial material)
        {
            _materials.Add(material);
            return Task.FromResult(material);
        }

        public List<TeachingMaterial> GetAllMaterials()
        {
            return _materials;
        }

        public TeachingMaterial GetMaterialById(int id)
        {
            return _materials.FirstOrDefault(m => m.id == id);
        }

        public TeachingMaterial GetMaterialByAuthor(Student author)
        {
            return _materials.Find(m => 
                m.author != null &&
                m.author.Equals(author)
            );
        }
        public IEnumerable<TeachingMaterial> GetMaterialByTitle(string title){
            var material = _materials.Where(m => m.title == title);
            return material;
        }
        public bool UpdateMaterial(int id, string newDescription, bool newIsApproved, Student newAuthor)
        {
            var material = GetMaterialById(id);
            if (material == null) return false;

            material.description = newDescription;
            material.isApproved = newIsApproved;
            material.author = newAuthor;
            Console.WriteLine($"Updated: {id}");
            return true;
        }

        public bool DeleteMaterial(int id)
        {
            var material = GetMaterialById(id);
            if (material == null) return false;

            _materials.Remove(material);
            Console.WriteLine($"Deleted: {id}");
            return true;
        }
    }