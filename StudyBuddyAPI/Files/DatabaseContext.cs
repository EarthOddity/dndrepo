using Microsoft.EntityFrameworkCore;

public class DatabaseContext: DbContext 
{
    public DbSet<User> Users { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Moderator> Moderators { get; set; }
    public DbSet<Bachelor> Bachelors { get; set; }
    public DbSet<Calendar> Calendars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=studybuddy.db");
    }
}