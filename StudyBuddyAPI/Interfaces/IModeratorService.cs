public interface IModeratorService
{
   Task<IEnumerable<Moderator>> GetAllModerators();
    Task<Moderator> GetModeratorById(int id);
    Task<Moderator> AddModerator(Moderator moderator);
    Task UpdateModerator(int id, Moderator updatedModerator);
    Task AssignSection(int id, string section);
    Task DeleteModerator(int id);
}