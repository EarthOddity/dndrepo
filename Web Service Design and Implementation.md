# 🚀 Project Update: Web Services Development

## Introduction ✨
We've made significant strides in developing the core web services that will power our StudyBuddy platform. These services will lay the foundation for seamless user interactions, allowing students, tutors, and moderators to collaborate effectively.

---

## 🌐 Web Services Implemented:
We've created and configured the following core services, each aligned with specific entities and functionalities:

1. **Bachelor Service** 🎓  
   Manages information about various bachelor's programs, ensuring students can filter tutors and materials based on their field of study.

2. **Calendar Service** 📅  
   Facilitates session scheduling and availability management for tutors. It ensures that students can find open slots and book sessions effortlessly.

3. **Event Service** 📆  
   Handles events like workshops or group study sessions, promoting community interaction and learning opportunities.

4. **Moderator Service** 🛡️  
   Provides tools for moderators to monitor user activity, manage access rights, and maintain a safe learning environment.

5. **Review Service** ⭐  
   Enables students to leave and read reviews about tutors and shared materials, fostering trust and quality assurance.

6. **Student Service** 👩‍🎓  
   Manages student profiles, ensuring secure registration, profile updates, and authentication.

7. **Subject Service** 📚  
   Centralizes subject-related data, allowing tutors to link their materials and students to filter resources effectively.

8. **Teaching Material Service** 📝  
   Allows tutors to upload notes, presentations, and other resources. Students can access, review, and download these materials.

---

## 🛠️ Controller Development:
We've also created controllers for each service, ensuring smooth interaction between the front end and back end. Controllers handle incoming requests, process data, and return appropriate responses, making the system robust and user-friendly. 
Something worth mention is that the Student controller, is the one making sure that when a student is registered, a calendar is also created and associated with that student. This way the database mantains its integrity. 

---

### An example of working with our API endpoints:

### Get all bachelors
GET http://localhost:5044/api/Bachelor
Accept: application/json

### Get bachelor by id
GET http://localhost:5044/api/Bachelor/3
Accept: application/json

### Create new bachelor
POST http://localhost:5044/api/Bachelor
Content-Type: application/json

{
    "programName": "Computer Science",
    "description": "Study of computation and information",
    "associatedSubjects": []
}

### Update bachelor
PUT http://localhost:5044/api/Bachelor/1
Content-Type: application/json

{
    "id": 1,
    "programName": "Software Engineering",
    "description": "Updated program description",
    "associatedSubjects": []
}

### Delete bachelor
DELETE http://localhost:5044/api/Bachelor/1
Accept: application/json

## File Context & Database Context
We started the project by using a filecontext to simulate how a database should work this was done to later facilitate the implementation of a database.
Once the web app was mostly finished and we wanted to test the components and how they were interacting is when we decided to change the context to a database. This context was created using the entity framework and SQLite. The model classess we had were completed with some extra object references to other clasess to represent the relationships between the different clasess and the database was implemented. 
Evidently, we put the database file in gitignore to avoid any possible problems but a base can be located in the main branch.

## Next Steps 🚀
- Integration of these services with the web application.  
- Comprehensive unit and integration testing to ensure reliability.  
- Enhancing documentation for better developer experience.

Stay tuned for our next update, where we'll share insights on our web application development journey!  
