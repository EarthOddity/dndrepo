public class Subject
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Bachelor> Bachelors { get; set; } =[];


    public Subject(int Id, string Name, string Description)
    {
        this.Id = Id;
        this.Name = Name;
        this.Description = Description;
    }
    public Subject()
    {
    }
}