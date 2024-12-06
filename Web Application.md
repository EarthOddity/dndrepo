# 🌟 Project Update: Web Application Development

## Introduction 🎉
We're thrilled to share our progress on the web application that will bring the StudyBuddy platform to life! This application is designed with a user-centric approach, ensuring that students, tutors, and moderators can navigate and interact effortlessly.

---

## 🖥️ Key Features Implemented:
This section demonstrates how our requirements have been implemented into the project. The main pages of our web application include Home, Materials, Tutors, Review Management and Profile Page. 

### 1. **User Authentication & Profiles 🔒**
   - **Student Registration/Login:** Secure user authentication to protect personal data.  
   - **Profile Management:** Students and tutors can create and update profiles with ease.

### 2. **Tutor Matching & Filtering 🤝**
   - **Advanced Filters:** Students can filter tutors based on career, language, availability, and more.  
   - **Tutor Profiles:** Detailed profiles showcasing tutor expertise, availability, and ratings.

### 3. **Material Repository 📂**
   - **Upload & Download Materials:** Tutors can upload teaching materials; students can access and review them.
   - **Save Materials:** Students can save their favourite materials and have them displayed in a separate section called Saved Materials.
         private async Task LoadUserData()
    {
        if (!currentUserId.HasValue) return;

        try
        {
            savedMaterials = (await AcademicService.GetSavedMaterialsByUserId(currentUserId.Value)).ToList();
            savedMaterialIds = new HashSet<int>(savedMaterials.Select(m => m.Id));

            var userBachelor = await AcademicService.GetBachelorByStudentId(currentUserId.Value);
            if (userBachelor != null)
            {
                userSubjects = (await AcademicService.GetSubjectsByBachelorId(userBachelor.Id)).ToList();
            }
            else
            {
                Console.WriteLine("No bachelor found for user");
                userSubjects = new List<Subject>();
            }
        }
        catch (Exception ex)
        {
            error = $"Error loading user data: {ex.Message}";
            Console.WriteLine($"LoadUserData error: {ex.Message}");
            savedMaterials = new List<TeachingMaterial>();
            userSubjects = new List<Subject>();
        }
    }

   private async Task ToggleSaveMaterial(int materialId)
    {
        if (!currentUserId.HasValue)
        {
            NavigationManager.NavigateTo("/login");
            return;
        }

        try
        {
            var success = await AcademicService.ToggleSaveMaterial(currentUserId.Value, materialId);
            if (success)
            {
                await LoadUserData();
                StateHasChanged();
            }
        }
        catch (Exception ex)
        {
            error = $"Error toggling save state: {ex.Message}";
            Console.WriteLine($"Error: {ex.Message}");
        }
    }


### 4. **Booking System 📅**
   - **Tutor Availability:** View real-time availability and book sessions directly through the calendar.  
   - **Session Management:** Tutors can manage bookings and students can track upcoming sessions.

### 5. **Review System ⭐**
   - **Leave & Read Reviews:** Students can share their feedback on tutors and materials, ensuring quality and transparency.  
   - **Moderation Tools:** Moderators can monitor and manage reviews to maintain a respectful environment.

---

## Next Steps 🛠️
- Integrate the web application with the back-end services.  
- Perform end-to-end testing to ensure smooth functionality across all modules. 
