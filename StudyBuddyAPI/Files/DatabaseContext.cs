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
        modelBuilder.Entity<Student>().ToTable("Students").Property(s => s.id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Moderator>().ToTable("Moderators").Property(s => s.id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Bachelor>().ToTable("Bachelors").Property(b => b.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<SBCalendar>().ToTable("Calendars");
        modelBuilder.Entity<SBEvent>().ToTable("Events");

        modelBuilder.Entity<TeachingMaterial>()
       .HasOne(t => t.subject)
       .WithMany()
       .HasForeignKey(t => t.subjectId);

        modelBuilder.Entity<TeachingMaterial>()
            .HasOne(t => t.subject)
            .WithMany()
            .HasForeignKey(t => t.subjectId);

        modelBuilder.Entity<Student>()
            .HasOne(s => s.calendar)
            .WithOne(c => c.Owner)
            .HasForeignKey<SBCalendar>(c => c.OwnerId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<SBEvent>()
            .Property(e => e.Timestamp)
            .IsRequired()
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAddOrUpdate();

        // Configure many-to-many relationship between SBCalendar and SBEvent
        modelBuilder.Entity<SBCalendar>()
            .HasMany(c => c.EventList)
            .WithMany(e => e.Calendars)
            .UsingEntity<Dictionary<string, object>>(
                "SBCalendarSBEvent",
                j => j.HasOne<SBEvent>().WithMany().HasForeignKey("EventListId"),
                j => j.HasOne<SBCalendar>().WithMany().HasForeignKey("CalendarsId"));
    }
}
