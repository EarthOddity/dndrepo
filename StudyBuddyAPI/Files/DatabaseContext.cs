using Microsoft.EntityFrameworkCore;

public class DatabaseContext: DbContext 
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=studybuddy.db");
    }
}