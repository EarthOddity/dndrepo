public class Moderator : User
{
    public string AccessLevel { get; set; }
    public List<string> AssignedSections { get; set; }
    public List<Review> BannedReviews { get; set; }
    public Moderator() : base()
    {
        this.AccessLevel = string.Empty;
        this.AssignedSections = new List<string>();
        this.BannedReviews = new List<Review>();
    }

    public Moderator(int id, string name, string surname, string email, int phoneNumber, string accessLevel, List<string> assignedSections, List<Review> bannedReviews, string password) : base(id, name, surname, email, phoneNumber, password)
    {
        this.AccessLevel = accessLevel;
        this.AssignedSections = assignedSections;
        this.BannedReviews = bannedReviews;
    }
    public Moderator(int id, string password) : base(id, password)
    {
        this.AccessLevel = string.Empty;
        this.AssignedSections = new List<string>();
        this.BannedReviews = new List<Review>();
    }
}