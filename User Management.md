### 🚀 StudyBuddy Project Update: Enhancing Security and User Experience!

We’re excited to share the latest progress on **StudyBuddy**, focusing on two key areas: security and user experience! Our team has implemented robust **authentication** and **authorization** features to ensure a secure, reliable environment for our student community. Here’s a quick look at what’s new:

---

### 🔒 **Secure Access with Authentication**
We’ve introduced an advanced **authentication system** using **JSON Web Tokens (JWT)**. This ensures that every user—whether a student, tutor, or moderator—can securely log in and access their personalized StudyBuddy experience.

**Why it matters:**  
Students and tutors can safely create profiles, upload materials, and manage bookings, knowing their data is protected and their identities verified.

---

### 🛡️ **Role-Based Authorization for Enhanced Control**
Our new **role-based authorization** system controls access based on user roles:
- **Students:** Access materials, find tutors, and leave reviews.
- **Tutors:** Upload notes, manage availability, and respond to student needs.
- **Moderators:** Oversee platform activity, ensuring a safe, supportive environment by managing user access and monitoring content.

**Example:**  
Only moderators can delete inappropriate reviews, while students can filter tutors by subject, language, or availability.

The following part includes the implementation of our login page, including the login credentials and the option to log in as a moderator. There is a separate page for the user and the moderator profile. While registering, one can choose a role to be assigned to.

 private int id ;
    private string email = "";
    private string password = "";
    private string errorLabel = "";
    private bool isModerator = false;
    private async Task LoginAsync()
    {   
        errorLabel = "";
        try
        {
            Console.WriteLine(isModerator);
            await authService.LoginAsync(id, password, isModerator);
            

            if(!isModerator)
                navMgr.NavigateTo("/user-profile");
            else
                navMgr.NavigateTo("/moderator-profile");
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            errorLabel = $"Error: {e.Message}";
        }
        
    }
    private async Task Logout()
    {
        await authService.LogoutAsync();
        navMgr.NavigateTo("/login");
    }

    private void GoToRegister()
    {
        navMgr.NavigateTo("/register");
    }
    
}

Thank you for being part of the StudyBuddy journey! 🌟
