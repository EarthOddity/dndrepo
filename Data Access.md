### **How We Implemented the StudyBuddy Database** 💾✨  

At StudyBuddy, we needed a reliable database to store user profiles, teaching materials, and reviews. Here’s a simple look at how we set it up and made it work.

---

### **Step 1: Choosing the Right Tool**  
We used **Entity Framework Core (EF Core)**, an **Object-Relational Mapping (ORM)** tool. It helps us interact with the database using C# code, so we don’t have to write complex SQL queries.

---

### **Step 2: Creating the Database**  
EF Core allows us to define **entities** (classes) that represent our data. EF Core then converts these classes into database tables. This process is called Code First—we define the code, and EF Core generates the database schema for us.
