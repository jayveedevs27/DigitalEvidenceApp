# DigitalEvidenceApp (Blazor Server, .NET 8)

# Setup Instructions

# 1. Clone the repository
git clone https://github.com/your-repo/DigitalEvidenceApp.git
cd DigitalEvidenceApp

# 2. Install dependencies

Ensure you have:
.NET 8 SDK
SQL Server or compatible database instance

Restore NuGet packages:
dotnet restore

# 3. Configure the database

Edit appsettings.json:

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=DigitalEvidence;User Id=YOUR_USER;Password=YOUR_PASSWORD;"
  },
  "Serilog": {
    "MinimumLevel": "Information",
    "WriteTo": [
      { "Name": "Console" },
      { "Name": "File", "Args": { "path": "Logs/log-.txt", "rollingInterval": "Day" } }
    ]
  }
}

# 4. Run the application
dotnet run

The app will be available at:
https://localhost:60780/

##### Architecture Overview

## Blazor Server UI Layer — Razor Components handle rendering and event callbacks.

## DataAccess Layer — Encapsulates database operations using EF Core.

## Dependency Injection — Interfaces are injected into components/services.

## Serilog Logging — Centralized logging configuration in Program.cs for console & file output.

##### Why this architecture?

## Separation of Concerns — UI, business logic, and persistence layers are decoupled.

## Maintainability — Interfaces make the code testable and extensible.

## Real-time UI updates — Blazor Server with SignalR avoids page reloads.

📝 Logging Usage

We use Serilog for:

Console logs during development

File-based logs in production (Logs/log-.txt with daily rotation)

Recording key application events (data changes, errors, performance info)

Example in code:

public class DataAccess : IDataAccess
{
    private readonly ILogger _logger;

    public DataAccess(ILogger logger)
    {
        _logger = logger;
    }

    public async Task SaveEvidenceAsync(Evidence evidence)
    {
        _logger.Information("Saving evidence record {CaseId}", evidence.CaseId);
        // DB save logic...
    }
}

Tech Stack

.NET 8 Blazor Server
Entity Framework Core
SQL Server
Serilog for structured logging