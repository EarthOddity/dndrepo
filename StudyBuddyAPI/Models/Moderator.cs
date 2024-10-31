namespace StudyBuddyAPI.Models
{
    public class Moderator : User
    {
        public List<Review> NotApprovedReviews { get; set; }


    }
}