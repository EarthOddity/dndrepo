public class Moderator : User
{
    public string accessLevel { get; set; }
    public List<string> assignedSections { get; set; }
    public List<Review> bannedReviews { get; set; }

    public Moderator(int id, string name, string surname, string email, int phoneNumber, string accessLevel, List<string> assignedSections, List<Review> bannedReviews, string password) : base(id, name, surname, email, phoneNumber, password)
    {
        this.accessLevel = accessLevel;
        this.assignedSections = assignedSections;
        this.bannedReviews = bannedReviews;
    }
}