# EMS Core - Enquiry Management System

A comprehensive web-based Enquiry Management System built with ASP.NET Core 9.0 and Entity Framework Core, designed to streamline student enquiry tracking and follow-up processes for educational institutions.

## Features

### Core Functionality
- **Enquiry Management**: Track student enquiries with detailed information including contact details, course interest, and source
- **Staff Management**: Manage staff members who handle enquiries
- **Communication Logging**: Record all communications (emails, SMS, WhatsApp, notes) with enquirers
- **Follow-up System**: Schedule and track follow-up activities with automated reminders
- **Reporting Dashboard**: Comprehensive analytics and reporting capabilities
- **User Management**: Role-based access control with Admin, Staff, and Student roles

### Key Modules
- **Enquiries**: Complete enquiry lifecycle management with status tracking (New, In Progress, Converted, Dropped)
- **Staff**: Staff member management and assignment
- **Communication Log**: Centralized communication history
- **Follow-ups**: Scheduled follow-up management with reminder system
- **Reports**: Analytics dashboard with insights and metrics
- **User Management**: Identity and role management

## Technology Stack

- **Framework**: ASP.NET Core 9.0 (MVC)
- **Database**: SQLite with Entity Framework Core 9.0
- **Authentication**: ASP.NET Core Identity
- **UI**: Razor Views with Bootstrap
- **ORM**: Entity Framework Core

## Prerequisites

- .NET 9.0 SDK
- Visual Studio 2022 or VS Code
- SQLite (included with EF Core SQLite provider)

## Installation & Setup

### 1. Clone the Repository
```bash
git clone https://github.com/Shiven0204/EMS-EnquiryManagementSystem.git
cd EMSCore
```

### 2. Restore Dependencies
```bash
dotnet restore
```

### 3. Database Setup
The application uses SQLite with Entity Framework migrations. The database will be created automatically on first run.

```bash
# Apply migrations (if needed)
dotnet ef database update
```

### 4. Run the Application
```bash
dotnet run
```

The application will be available at `https://localhost:5001` or `http://localhost:5000`

## Default Login Credentials

The system automatically creates an admin user on first run:
- **Email**: admin@ems.com
- **Password**: Admin@123

## Database Schema

### Core Entities

#### Enquiry
- Student information (Name, Contact, Email)
- Course interest and enquiry source
- Priority levels (High, Medium, Low)
- Status tracking (New, In Progress, Converted, Dropped)
- Staff assignment

#### Staff
- Basic staff information (Name, Email, Phone)
- Used for enquiry assignment

#### CommunicationLog
- Communication history for each enquiry
- Support for multiple communication types (Email, SMS, WhatsApp, Notes)
- Internal/external communication tracking

#### FollowUp
- Scheduled follow-up activities
- Staff assignment and reminder system
- Notes and completion tracking

## Configuration

### Database Connection
Update the connection string in `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "EMSContext": "Data Source=ems.db"
  }
}
```

### Identity Settings
The application uses ASP.NET Core Identity with the following default roles:
- **Admin**: Full system access
- **Staff**: Enquiry management access
- **Student**: Limited access (if needed)

## Project Structure

```
EMSCore/
├── Controllers/          # MVC Controllers
├── Models/              # Data models and DbContext
├── Views/               # Razor views
├── Areas/Identity/      # Identity UI customization
├── Migrations/          # EF Core migrations
├── wwwroot/            # Static files (CSS, JS, images)
├── Properties/         # Launch settings
└── Program.cs          # Application entry point
```

## Development

### Adding New Migrations
```bash
dotnet ef migrations add <MigrationName>
dotnet ef database update
```

### Running in Development
```bash
dotnet run --environment Development
```

## Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Submit a pull request

## License

This project is licensed under the MIT License.

## Support

For support and questions, please contact the development team or create an issue in the repository.
