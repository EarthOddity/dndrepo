### **How We Implemented the StudyBuddy Database** 💾✨  

At StudyBuddy, we needed a reliable database to store different user profiles, calendars, events, subjects, bachelors, teaching materials and reviews. Here’s a simple look at how we set it up and made it work.

---

### **Step 1: Choosing the Right Tool**  
We used **Entity Framework Core (EF Core)**, an **Object-Relational Mapping (ORM)** tool. It helps us interact with the database using C# code, so we don’t have to write complex SQL queries.

---

### **Step 2: Implementing the Database**  
EF Core allows us to define **entities** (classes) that represent our data. EF Core then converts these classes into database tables. This process is called Code First—we define the code, and EF Core generates the database schema for us.

Since we already have File Context, it made it easy for us to switch to Database context, and then create a separate file that stored the mapping from our Models to the Database entities, as can be seen here:

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
    }
}


### **Step 3: Saving data**
We used CRUD operations (Create, Read, Update, Delete) to manage data.

New, combined files inside services for the WebApp were created, such as ProfileService, and AcademicService (combines handling for Bachelor, Subject, Teaching Material and Review). We also added Interfaces for them, though later we realised we could have also used services directly from the API.

### **Why This Matters:**
With EF Core, we have a flexible database that grows with StudyBuddy. It is very easy to update data by simply creating a new migration whenever the model is changed, and then updating the database through the terminal commands.

This setup makes it easy for users to save and manage data, such as accessing materials and tutors, editing events and leaving reviews, ensuring a smooth and secure learning experience. 🚀

More to come as we enhance our platform! Stay connected! 💡






