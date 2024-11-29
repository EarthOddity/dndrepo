using Microsoft.EntityFrameworkCore;

public class DatabaseContext: DbContext 
{
    public DbSet<User> Users { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Moderator> Moderators { get; set; }
    public DbSet<Bachelor> Bachelors { get; set; }
    public DbSet<Calendar> Calendars { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<TeachingMaterial> TeachingMaterials { get; set; }
    public DbSet<SavedMaterial> SavedMaterials { get; set; }
    public DbSet<Review> Reviews { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=studybuddy.db");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().UseTpcMappingStrategy();
        modelBuilder.Entity<Student>().ToTable("Students");
        modelBuilder.Entity<Moderator>().ToTable("Moderators");
    }
}