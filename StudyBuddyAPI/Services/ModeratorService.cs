
public class ModeratorService(DatabaseContext context): IModeratorService{
    //private static List<Moderator> moderatorsList = new List<Moderator>();
    private static List<Review> reviews = new List<Review>();

    private readonly DatabaseContext context = context;
    static ModeratorService()
    {
    }
    public Task<IEnumerable<Moderator>> GetAllModerators()
    {
        return Task.FromResult(context.Moderators.AsEnumerable());
    }

    public async Task<Moderator> AddModerator(Moderator moderator)
    {
        context.Moderators.Add(moderator);
        await context.SaveChangesAsync();
        return moderator;
    }

    public async Task UpdateModerator(int id, Moderator updatedModerator)
    {
        var moderator = context.Moderators.FirstOrDefault(m => m.id == id);
        if (moderator != null)
        {
            moderator.name = updatedModerator.name;
            moderator.surname = updatedModerator.surname;
            moderator.email = updatedModerator.email;
            moderator.phoneNumber = updatedModerator.phoneNumber;
            moderator.assignedSections = updatedModerator.assignedSections;
            await context.SaveChangesAsync();
        }
        
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

    public async Task AssignSection(int id, string section)
    {
        var moderator = context.Moderators.FirstOrDefault(m => m.id == id);
        if (moderator != null && !moderator.assignedSections.Contains(section))
        {
            moderator.assignedSections.Add(section);
            await context.SaveChangesAsync();
        }
    }

    public Task<Moderator> GetModeratorById(int id)
    {
        var moderator = context.Moderators.FirstOrDefault(m => m.id == id);
        return Task.FromResult(moderator);
    }

    public async Task DeleteModerator(int id)
    {
        var moderator = context.Moderators.FirstOrDefault(m => m.id == id);
        context.Moderators.Remove(moderator);
        await context.SaveChangesAsync();
    }
}