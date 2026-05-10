# Guest Verification System

A comprehensive guest verification application that validates guests using mobile numbers. Only invited mobile numbers are allowed to verify.

## Features

- **Mobile Number Verification**: Simple verification using mobile numbers
- **Whitelist-Based Access**: Only pre-approved mobile numbers can verify
- **Modern Tech Stack**: React (latest) frontend + .NET (latest) backend
- **RESTful API**: Secure API endpoints for verification
- **Responsive UI**: Mobile-friendly interface

## Project Structure

```
guest-verification/
├── frontend/                 # React application
│   ├── src/
│   │   ├── components/
│   │   ├── pages/
│   │   ├── services/
│   │   ├── hooks/
│   │   └── App.jsx
│   ├── package.json
│   └── vite.config.js
���── backend/                  # .NET application
│   ├── GuestVerification.Api/
│   ├── GuestVerification.Core/
│   ├── GuestVerification.Data/
│   └── GuestVerification.sln
└── README.md
```

## Tech Stack

### Frontend
- **React 19+**: Latest React with hooks and functional components
- **Vite**: Fast build tool and dev server
- **Axios**: HTTP client for API calls
- **React Router**: Client-side routing
- **Tailwind CSS**: Utility-first CSS framework

### Backend
- **.NET 9**: Latest .NET framework
- **ASP.NET Core**: Web API framework
- **Entity Framework Core**: ORM for database access
- **SQL Server**: Database
- **AutoMapper**: Object mapping

## Getting Started

### Prerequisites
- Node.js 20+ (for frontend)
- .NET 9 SDK (for backend)
- SQL Server or compatible database

### Frontend Setup

```bash
cd frontend
npm install
npm run dev
```

The frontend will be available at `http://localhost:3000`

### Backend Setup

```bash
cd backend
dotnet restore
dotnet ef database update
dotnet run --project GuestVerification.Api
```

The backend API will be available at `http://localhost:5000`

## API Endpoints

### Guest Verification
- `POST /api/guests/verify` - Verify guest by mobile number
- `GET /api/guests/validate/{mobileNumber}` - Check if mobile is whitelisted

### Admin (Whitelist Management)
- `POST /api/admin/whitelist` - Add mobile to whitelist
- `DELETE /api/admin/whitelist/{mobileNumber}` - Remove from whitelist
- `GET /api/admin/whitelist` - Get all whitelisted numbers

## Environment Variables

### Frontend (.env)
```
VITE_API_URL=http://localhost:5000/api
```

### Backend (appsettings.json)
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=GuestVerificationDb;Trusted_Connection=true;"
  }
}
```

## Default Whitelisted Mobile Numbers

The application comes pre-configured with these test numbers:
- 9876543210
- 9123456789
- 9988776655
- 9112345678

## Database

The application uses Entity Framework Core with SQL Server. It automatically creates and seeds the database on first run.

## License

MIT

## Author

kapatel18git
