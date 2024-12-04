### **How We Implemented the StudyBuddy Database** 💾✨  

At StudyBuddy, we needed a reliable database to store user profiles, teaching materials, and reviews. Here’s a simple look at how we set it up and made it work.

---

### **Step 1: Choosing the Right Tool**  
We used **Entity Framework Core (EF Core)**, an **Object-Relational Mapping (ORM)** tool. It helps us interact with the database using C# code, so we don’t have to write complex SQL queries.

---

### **Step 2: Implementing the Database**  
EF Core allows us to define **entities** (classes) that represent our data. EF Core then converts these classes into database tables. This process is called Code First—we define the code, and EF Core generates the database schema for us.

### **Step 3: Saving data**
We used CRUD operations (Create, Read, Update, Delete) to manage data.

### **Why This Matters:**
With EF Core, we have a flexible database that grows with StudyBuddy. This setup makes it easy for students to access materials and tutors, ensuring a smooth and secure learning experience. 🚀

More to come as we enhance our platform! Stay connected! 💡





