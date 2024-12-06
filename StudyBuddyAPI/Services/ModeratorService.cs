
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
        var moderator = context.Moderators.FirstOrDefault(m => m.Id == id);
        if (moderator != null)
        {
            moderator.Name = updatedModerator.Name;
            moderator.Surname = updatedModerator.Surname;
            moderator.Email = updatedModerator.Email;
            moderator.PhoneNumber = updatedModerator.PhoneNumber;
            moderator.AssignedSections = updatedModerator.AssignedSections;
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
        var moderator = context.Moderators.FirstOrDefault(m => m.Id == id);
        if (moderator != null && !moderator.AssignedSections.Contains(section))
        {
            moderator.AssignedSections.Add(section);
            await context.SaveChangesAsync();
        }
    }

    public Task<Moderator> GetModeratorById(int id)
    {
        var moderator = context.Moderators.FirstOrDefault(m => m.Id == id);
        return Task.FromResult(moderator);
    }

    public async Task DeleteModerator(int id)
    {
        var moderator = context.Moderators.FirstOrDefault(m => m.Id == id);
        context.Moderators.Remove(moderator);
        await context.SaveChangesAsync();
    }
}