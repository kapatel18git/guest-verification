# Guest Verification API

ASP.NET Core 9 API for guest verification using mobile numbers.

## Setup

### Prerequisites
- .NET 9 SDK
- SQL Server (LocalDB or Full)

### Installation

1. Update connection string in `GuestVerification.Api/appsettings.json`
2. Create and apply migrations:
   ```bash
   cd GuestVerification.Api
   dotnet ef database update
   ```

3. Run the application:
   ```bash
   dotnet run --project GuestVerification.Api
   ```

The API will be available at `https://localhost:5001` or `http://localhost:5000`

## Database Migrations

Create new migration:
```bash
dotnet ef migrations add MigrationName -p GuestVerification.Data -s GuestVerification.Api
```

Apply migrations:
```bash
dotnet ef database update -p GuestVerification.Data -s GuestVerification.Api
```

## API Documentation

Swagger UI available at: `/swagger/index.html`

## Default Whitelisted Numbers
- 9876543210
- 9123456789
- 9988776655
- 9112345678

## Project Structure

- **GuestVerification.Api** - ASP.NET Core Web API
- **GuestVerification.Core** - Business logic and DTOs
- **GuestVerification.Data** - Entity Framework Core DbContext
