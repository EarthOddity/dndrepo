public class SavedMaterial
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int MaterialId { get; set; }
    public TeachingMaterial Material { get; set; }
    public Student User { get; set; }

    public SavedMaterial()
    {
    }
    public SavedMaterial(int Id, int UserId, int MaterialId, TeachingMaterial Material, Student User)
    {
        this.Id = Id;
        this.UserId = UserId;
        this.MaterialId =MaterialId;
        this.Material = Material;
        this.User = User;
    }
}