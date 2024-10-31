
namespace StudyBuddyAPI.Models;
public class TeachingMaterial
{
    public string Title { get; set; }
    public string Description { get; set; }

    public TeachingMaterial(string title, string description)
    {
        Title = title;
        Description = description;
    }
}