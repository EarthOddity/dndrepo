public class Subject
{
    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public List<Bachelor> bachelors { get; set; } =[];


    public Subject(int id, string name, string description)
    {
        this.id = id;
        this.name = name;
        this.description = description;
    }
    public Subject()
    {
    }
}