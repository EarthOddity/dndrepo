public record DataContainer
{
    public List<Student> Students { get; set; } = [];
    public List<Moderator> Moderators { get; set; } = [];
    public List<Subject> Subjects { get; set; } = [];
    public List<Bachelor> Bachelors { get; set; } = [];
    public List<SBCalendar> Calendars { get; set; } = [];
    public List<SBEvent> Events { get; set; } = [];
    public List<Review> Reviews { get; set; } = [];
    public List<TeachingMaterial> TeachingMaterials { get; set; } = [];
    public List<SavedMaterial> SavedMaterials { get; set; } = [];

}