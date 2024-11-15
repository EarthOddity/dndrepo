public class TeachingMaterial
{
    public int id {get; set;}
    public string title { get; set; }
    public string description { get; set; }

    public Student author { get; set; }

    public bool isApproved { get; set; }


    public TeachingMaterial(int id, string title, string description, Student author, bool isApproved)
    {
        this.id = id;
        this.title = title;
        this.description = description;
        this.author = author;
        this.isApproved = isApproved;
    }
}