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

    public Moderator(int Id, string Name, string Surname, string Email, int PhoneNumber, string AccessLevel, List<string> AssignedSections, List<Review> BannedReviews, string Password) : base(Id, Name, Surname, Email, PhoneNumber, Password)
    {
        this.AccessLevel = AccessLevel;
        this.AssignedSections = AssignedSections;
        this.BannedReviews = BannedReviews;
    }
    public Moderator(int Id, string Password) : base(Id, Password)
    {
        this.AccessLevel = string.Empty;
        this.AssignedSections = new List<string>();
        this.BannedReviews = new List<Review>();
    }
}