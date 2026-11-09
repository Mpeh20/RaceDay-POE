# RaceDay - MVC Frontend (Part 3)

## Prerequisites
- .NET 8 SDK
- Docker Desktop
- Part 2 API running (Update `appsettings.json` with the correct API URL)

## How to Run Locally
1. Open a terminal in the project folder.
2. Run: `dotnet run`
3. Navigate to `https://localhost:xxxx`

## How to Run with Docker
To build and start the application using Docker, run the following command in the root directory (where the Dockerfile is located):

```bash
docker build -t raceday-mvc .
docker run -d -p 8080:8080 -p 8081:8081 --name raceday-app raceday-mvc
