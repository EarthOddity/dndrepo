public record DataContainer{
    public List<Student> Students { get; set; } = [];
    public List<Moderator> Moderators { get; set; } = [];
    public List<Subject> Subjects { get; set; } = [];
}