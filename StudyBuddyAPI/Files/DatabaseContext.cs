using Microsoft.EntityFrameworkCore;

public class DatabaseContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Moderator> Moderators { get; set; }
    public DbSet<Bachelor> Bachelors { get; set; }
    public DbSet<SBCalendar> Calendars { get; set; }
    public DbSet<SBEvent> Events { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<TeachingMaterial> TeachingMaterials { get; set; }
    public DbSet<SavedMaterial> SavedMaterials { get; set; }
    public DbSet<Review> Reviews { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=studybuddy.db");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().UseTpcMappingStrategy();
        modelBuilder.Entity<Student>().ToTable("Students").Property(s => s.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Moderator>().ToTable("Moderators").Property(s => s.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<TeachingMaterial>()
       .HasOne(t => t.Subject)
       .WithMany()
       .HasForeignKey(t => t.SubjectId);
        modelBuilder.Entity<SBCalendar>().ToTable("Calendars");
        modelBuilder.Entity<SBEvent>().ToTable("Events");

    }
}