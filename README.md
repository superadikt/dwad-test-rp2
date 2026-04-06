# DwadTestRp

A sample ASP.NET Core MVC project used for demo and knowledge sharing purposes.

## Tech Stack

- .NET 9
- ASP.NET Core MVC
- Swagger (Swashbuckle) for API documentation and testing

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)

### Run the Project

```bash
dotnet run
```

Once running, navigate to:

- **App**: http://localhost:5000
- **Swagger UI**: http://localhost:5000/swagger

## Project Structure

```
Controllers/
  HomeController.cs          # Default MVC controller
  Api/
    SampleApiController.cs   # Sample REST API with CRUD endpoints
Models/
  ErrorViewModel.cs
Views/                       # Razor views (Home, Shared layouts)
Program.cs                   # App entry point and middleware config
```

## Sample API Endpoints

| Method | Endpoint              | Description       |
|--------|-----------------------|-------------------|
| GET    | /api/SampleApi        | Get all items     |
| GET    | /api/SampleApi/{id}   | Get item by ID    |
| POST   | /api/SampleApi        | Create an item    |
| PUT    | /api/SampleApi/{id}   | Update an item    |
| DELETE | /api/SampleApi/{id}   | Delete an item    |

## Disclaimer

This project is for demonstration and knowledge sharing only. It is not intended for production use.
