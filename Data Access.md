### **How We Implemented the StudyBuddy Database** 💾✨  

At StudyBuddy, we needed a reliable database to store user profiles, teaching materials, and reviews. Here’s a simple look at how we set it up and made it work.

---

### **Step 1: Choosing the Right Tool**  
We used **Entity Framework Core (EF Core)**, an **Object-Relational Mapping (ORM)** tool. It helps us interact with the database using C# code, so we don’t have to write complex SQL queries. 

Why EF Core?

Code First Development: We define entities (C# classes), and EF Core generates the database schema for us.
Cross-Platform Support: As a part of .NET, EF Core is lightweight and cross-platform.
Efficient Relationships: EF Core makes it simple to define and manage complex relationships between tables.
We paired EF Core with SQLite, a lightweight database engine, making it ideal for a growing application like StudyBuddy.

The implementation process was an evolution, begingin first with the implementation of ca file context. However, when we were ready, we just needed to pass the newly created DatabaseContext to the same methods and it will work almost out of the box. The databaseContext is the class that sets up the database using the EFC framework and it wil be passed to the services of the API to be able to store the information. 

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
---

### **Step 2: Implementing the Database**  
EF Core allows us to define **entities** (classes) that represent our data. EF Core then converts these classes into database tables. This process is called Code First—we define the code, and EF Core generates the database schema for us. With the DatabaseContext that we showed before, EFC has an idea of how what tables to create, however, for out connections to work we need to set relationships. In out case we followed some conventions when implementing the model that tell EFC the relationships between tables as well as multiplicity. 

Our model is also a bit particulat in the sense that it includes inheritance, which cannot be included in a database itself. TO tackle this, we used the TPC solution (Table per Concrete Type), which basically does not create a table for the abstract class (superclass), but two separate tables for the subclasses making sure they have their own attribubes aswell as the ones inherited from the superclass. 

### **Step 3: Saving data**
We used CRUD operations (Create, Read, Update, Delete) to manage data, as well as LINQ queries. An important detail that is woth mentioning is the imporant of the SavesChangesAsync() method. This method makes sure that the data is recorded in the database and stays there permanently. 

### **Why This Matters:**
With EF Core, we have a flexible database that grows with StudyBuddy. This setup makes it easy for students to access materials and tutors, ensuring a smooth and secure learning experience. Besides, a database allows for persistent data storage and, compared to just files, it provides the corretc structure and relationships between the obejcts in the model. 🚀


More to come as we enhance our platform! Stay connected! 💡






