# UserManagementAPI

UserManagementAPI is a beginner-friendly ASP.NET Core Web API project for managing users with full CRUD functionality. It uses an in-memory list instead of a database, making it simple to run, test, and understand.

## Features

- Full CRUD endpoints for users
- Model validation using Data Annotations
- Automatic validation responses with `[ApiController]`
- Custom logging middleware for request method and path
- Swagger UI for interactive API testing
- Clean and minimal folder structure

## Technologies Used

- C#
- ASP.NET Core Web API
- .NET 10.0 SDK and target framework
- Swagger / Swashbuckle

## API Endpoints

- `GET /api/users` - Get all users
- `GET /api/users/{id}` - Get a user by ID
- `POST /api/users` - Create a new user
- `PUT /api/users/{id}` - Update an existing user
- `DELETE /api/users/{id}` - Delete a user

## Validation

The `User` model requires:

- `Name` to be provided
- `Email` to be provided
- `Email` to be in a valid email format

If invalid data is sent, ASP.NET Core automatically returns a `400 Bad Request` response because the controller uses `[ApiController]`.

## Middleware

The custom `LoggingMiddleware` logs the HTTP request method and path for every incoming request.

## Copilot Usage

GitHub Copilot helped generate and debug parts of the code during development. It was used as an assistant for scaffolding, endpoint logic, validation patterns, and general troubleshooting, while the final structure and review were organized to keep the project clean and beginner-friendly.

## How to Run the Project

1. Make sure the .NET SDK is installed.
2. Open a terminal in the project folder:

```powershell
cd UserManagementAPI
```

3. Restore dependencies:

```powershell
dotnet restore
```

4. Run the API:

```powershell
dotnet run
```

5. Open Swagger in the browser using the URL shown in the terminal, usually:

```text
https://localhost:<port>/swagger
```

## Project Structure

```text
UserManagementAPI/
|-- Controllers/
|   `-- UsersController.cs
|-- Middleware/
|   `-- LoggingMiddleware.cs
|-- Models/
|   `-- User.cs
|-- Program.cs
|-- README.md
`-- UserManagementAPI.csproj
```
