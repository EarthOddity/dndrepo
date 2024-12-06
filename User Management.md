### 🚀 StudyBuddy Project Update: Enhancing Security and User Experience!

We’re excited to share the latest progress on **StudyBuddy**, focusing on two key areas: security and user experience! Our team has implemented robust **authentication** and **authorization** features to ensure a secure, reliable environment for our student community. Here’s a quick look at what’s new:

---

### 🔒 **Secure Access with Authentication**
We’ve introduced an **authentication system** using **JSON Web Tokens (JWT)**. This ensures that every user—whether they are a student, tutor, or moderator—can securely log in and access their personalized StudyBuddy experience.
Based on the role, the user then will be able to access and manage different views.

**Why it matters:**  
Students and tutors can safely create profiles, upload materials, and manage bookings, knowing their data is protected and their identities verified. Useer management ensures that the information of the users is always safe and allows the creators of the application to restric access to certain features when needed. 

---

### 🛡️ **Role-Based Authorization for Enhanced Control**
Our new **role-based authorization** system controls access based on user roles:
- **Students:** Access materials, find tutors, and leave reviews. This user has acess to materials and is able to save them. They can also acess their informationa and change it, as well as adding events to their calendar to schedule any tutoring they may need.
- **Moderators:** Oversee platform activity, ensuring a safe, supportive environment by managing user access and monitoring content.
- **Unknown User:** Not a role itself, but when a user is not logged in they can still acess materials and tutors but just with a reduced functionality, since they will not bee able to save them, leave reviews, etc. 

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

The JSON authentication works on a complex architecture that connects both ends od our application, the front-end a back-end. By sending Tokens that can only be decoded with a random key that is defined by our server, the information is always safe (as long as that key does not leak or the problem to P vs Np gets solved). 

As mentioned, we Authorize students based on certain policies that are assigned depending on the role. By using these policies we can retrict acess to certain section or pages of the application. 

Another very important step during the autentication process is the generation of claims. These are attributes of the user that is currently logged in that can be access any time while the user is atentitcated. This becomes useful when calling API methods that require searching by names, Ids ect. of the logged in user 



Thank you for being part of the StudyBuddy journey! 🌟
