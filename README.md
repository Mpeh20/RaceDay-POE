# RaceDay - Frontend MVC (Part 3)

## Prerequisites
- .NET 8 SDK
- Docker Desktop
- Part 2 API must be running and accessible. Update the `BaseUrl` in `appsettings.json` accordingly.

## How to Run Locally
1. Open a terminal in the project directory.
2. Run: `dotnet run`

## How to Run with Docker
1. Build the image: 
   `docker build -t raceday-mvc .`
2. Run the container:
   `docker run -d -p 8080:8080 -p 8081:8081 --name raceday-app raceday-mvc`
3. Access the app at: `http://localhost:8080`

## Git Commits (Requirement)
Ensure you push to a branch named `Part-3` or similar. Minimum 20 commits. Examples:
1. Initial MVC project setup
2. Added DTOs for API mapping
3. Configured HttpClient in Program.cs
4. Setup Session and Cookie Auth
5. Created AccountController login logic
6. Added Login and Register Views
7. Implemented Role-based Layout
8. Created OrganiserController
9. Added Organiser Dashboard view
10. Implemented Event Creation with file upload
11. Added Multipart form data handling in ApiService
12. Created ParticipantController
13. Added Participant Event Listing
14. Implemented Event Enrollment logic
15. Added MyEvents/Results view for Participants
16. Applied Bootswatch Cyborg theme
17. Added custom CSS for status colors
18. Created Dockerfile
19. Tested Docker container locally
20. Final README and bug fixes
