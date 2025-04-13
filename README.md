# HospitalRoster
📝 Description
The Hospital Roster Application is a comprehensive scheduling system designed for healthcare facilities to manage staff shifts, department assignments, and work schedules efficiently. This full-stack application features:

.NET Core 7/8 API backend with JWT authentication

Angular 19 frontend with responsive UI

SQL Server database for data persistence

ASP.NET Core Identity for user management

Role-based access control for different staff types

The application helps hospital administrators:

Create and manage staff schedules

Assign shifts to doctors, nurses, and other healthcare professionals

Track department staffing needs

Approve/reject shift requests

Generate reports on staff availability

🚀 Features
Core Functionality
User Authentication & Authorization

JWT-based secure login

Role-based access (Admin, Doctor, Nurse, Staff)

Password reset functionality

Roster Management

Monthly/weekly shift views

Drag-and-drop shift assignment

Shift swapping requests

Approval workflow

Staff Management

Add/edit staff profiles

Department assignments

Leave management

Reporting

Staff workload analysis

Department coverage reports

Export to PDF/Excel

Technical Highlights
Clean architecture with separation of concerns

Responsive design with Bootstrap 5

API documentation with Swagger

Automated database migrations

Caching for improved performance

🛠️ Installation
Prerequisites
.NET 7/8 SDK

Node.js 18+

SQL Server 2019+

Angular CLI 19+

Visual Studio 2022 (recommended) or VS Code

Backend Setup
Clone the repository

bash
Copy
git clone https://github.com/SudheerNayak/HospitalRoster.git
cd HospitalRoster.API
Configure the database:

Update connection string in appsettings.json

json
Copy
"ConnectionStrings": {
  "DefaultConnection": "Server=MSI;Database=HospitalRosterDB;Trusted_Connection=True;"
}
Apply database migrations:

bash
Copy
dotnet ef database update
Run the API:

bash
Copy
dotnet run
Frontend Setup
Navigate to the Angular project:

bash
Copy
cd ../HospitalRoster.UI
Install dependencies:

bash
Copy
npm install
Configure environment:

Update src/environments/environment.ts with your API URL

typescript
Copy
export const environment = {
  production: false,
  apiUrl: 'http://localhost:5000/api'
};
Run the Angular app:

bash
Copy
ng serve
Access the application at http://localhost:4200

📂 Project Structure
Copy
HospitalRoster/
├── HospitalRoster.API/          # .NET Core Web API
│   ├── Controllers/             # API endpoints
│   ├── Data/                    # Database context
│   ├── DTOs/                    # Data transfer objects
│   ├── Migrations/              # Database migrations
│   ├── Models/                  # Domain models
│   ├── Services/                # Business logic
│   ├── appsettings.json         # Configuration
│   └── Program.cs               # Startup configuration
│
├── HospitalRoster.UI/           # Angular frontend
│   ├── src/
│   │   ├── app/                 # Application code
│   │   │   ├── core/            # Core services
│   │   │   ├── features/        # Feature modules
│   │   │   ├── shared/          # Shared components
│   │   │   └── styles.css       # Global styles
│   │   ├── assets/              # Static assets
│   │   └── environments/        # Environment configs
│   └── angular.json             # Angular config
│
└── README.md                    # This file
🔐 Default Credentials
Role	Username	Password
Admin	admin@hospital.com	Admin@123
Doctor	doctor@hospital.com	Doctor@123
Nurse	nurse@hospital.com	Nurse@123
🌐 API Documentation
Access Swagger documentation at http://localhost:5000/swagger when the API is running.

🧪 Testing
Run unit tests:

bash
Copy
# API tests
cd HospitalRoster.API
dotnet test

# Angular tests
cd ../HospitalRoster.UI
ng test
🤝 Contributing
Fork the project

Create your feature branch (git checkout -b feature/AmazingFeature)

Commit your changes (git commit -m 'Add some amazing feature')

Push to the branch (git push origin feature/AmazingFeature)

Open a Pull Request

📄 License
Distributed under the MIT License. See LICENSE for more information.

✉️ Contact
Sudheer Nayak- sudhirnayak1605@gmail.com

Project Link: https://github.com/SudheerNayak/HospitalRoster

🎉 Acknowledgments
Bootstrap for UI components

Font Awesome for icons

JWT for authentication
