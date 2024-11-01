
public class ModeratorService{
    private static List<Moderator> moderatorsList = new List<Moderator>();
    private static List<Review> reviews = new List<Review>();


    static ModeratorService(){
    }
      public Task<IEnumerable<Moderator>> GetAllModerators()
    {
        return Task.FromResult(moderatorsList.AsEnumerable());
    }

    public Task AddModerator(Moderator moderator)
    {
        moderatorsList.Add(moderator);
        return Task.CompletedTask;
    }

    /*public Task BanReview(int id, Review review){
        var moderator = moderatorsList.FirstOrDefault(m => m.id == id);
        var _review = reviews.FirstOrDefault(r => r.Id == reviewId);

        if(moderator != null){
            moderator.bannedReviews.Add(review);
            reviews.Remove(_review); // We will have to remove it from the actual database here with a Delete method from the review service 
        }
        return Task.CompletedTask;
    }*/

    public Task AssignSection(int id, string section){
        var moderator = moderatorsList.FirstOrDefault(m => m.id == id);
        if(moderator != null && !moderator.assignedSections.Contains(section)){
            moderator.assignedSections.Add(section);
        }
        return Task.CompletedTask;
    }

     public Task<Moderator> GetModeratorById(int id){
        var moderator = moderatorsList.FirstOrDefault(m => m.id == id);
        return Task.FromResult(moderator);
     }

     public Task deleteModerator(int id){
        var moderator = moderatorsList.FirstOrDefault(m => m.id == id);
        moderatorsList.Remove(moderator);
        return Task.CompletedTask;
     }
}