# 🌟 Project Update: Web Application Development

## Introduction 🎉
We're thrilled to share our progress on the web application that will bring the StudyBuddy platform to life! This application is designed with a user-centric approach, ensuring that students, tutors, and moderators can navigate and interact effortlessly.

---

## 🖥️ Key Features Implemented:
This section demonstrates how our requirements have been implemented into the project. The main pages of our web application include Home, Materials, Tutors, Review Management and Profile Page.
The front-end started to be developed by splitting the work into components and assigning several to each group member.

### 1. **User Authentication & Profiles 🔒**
   - **Student Registration/Login:** Secure user authentication to protect personal data, as well as manage views based on access.  
   - **Profile Management:** Students and tutors can create and update their profiles with ease.

### 2. **Searching and Filtering 🤝**
   - **Looking up materials, tutors and filtering by subjects:** For ease of use, the users are able to look up materials and tutors, as well as filter the materials found and the saved ones by subjects relevant to them.

### 3. **Event (Tutoring Session) View📅**
   - **Add Calendar and Event Components:** Create new events for sessions, as well as update already existing ones and remove them from your upcoming events (calendarDay) section.

Snippet from Event.razor:

---

@code {
    [Parameter] public int calendarId { get; set; }
    [Parameter] public int? eventId { get; set; }
    private SBEvent newEvent = new SBEvent();
    private string errorMessage = "";
    private string successMessage = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        if (eventId.HasValue)
        {
            newEvent = await EventService.GetEventById(eventId.Value);
            if (newEvent == null)
            {
                errorMessage = "Event not found!";
            }
        }
        else
        {
            newEvent.CalendarId = calendarId;
        }
    }

    private async Task CreateOrUpdateEvent()
    {
        try
        {
            if (eventId.HasValue)
            {
                // Update the existing event
                await EventService.UpdateEvent(newEvent);
                successMessage = "Event updated successfully!";
            }
            else
            {
                // Create a new event
                await EventService.CreateEvent(newEvent);
                successMessage = "Event created successfully!";
            }

            StateHasChanged();

            // Wait 2 seconds before redirecting
            await Task.Delay(2000);
            NavigationManager.NavigateTo("/");
        }
        catch (Exception ex)
        {
            errorMessage = $"Error: {ex.Message}";
            StateHasChanged();
        }
    }

    private void Cancel()
    {
        NavigationManager.NavigateTo("/");
    }
}

### 4. **Material Repository 📂**
   - **View Materials:** Tutors and students can enter new teaching materials, which others can access and review.
   - **Save Favourite Materials:** Students can save their favourite materials and have them displayed in a separate section called Saved Materials.
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

### 5. **Review System ⭐**
   - **Leave & Read Reviews:** Students can share their feedback on tutors and materials, ensuring quality and transparency, as well as giving room for improvement to the people providing their resources and/or services as a tutor.  
   - **Moderation Tools:** Moderators can monitor and manage reviews to maintain a respectful environment, and ensure that no inappropriate or rude comments are left.


---

## Next Steps 🛠️
- Integrate the web application with the back-end services.  
- Perform end-to-end testing to ensure smooth functionality across all modules. 
