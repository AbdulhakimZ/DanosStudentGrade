# Student Grade Management System

A full-stack web application for managing and visualizing student grades with interactive charts and Excel export capabilities.

## 📋 Table of Contents
- [About the Project](#about-the-project)
- [Features](#features)
- [Technology Stack](#technology-stack)
- [Getting Started](#getting-started)
- [API Documentation](#api-documentation)
- [Usage Guide](#usage-guide)
- [Project Structure](#project-structure)

## 🎯 About the Project

This application provides a comprehensive solution for managing student grades across multiple courses. It calculates student averages, course averages, and presents the data through an intuitive web interface with data visualization and export capabilities.

### Key Capabilities
- **Student Grade Management**: Store and retrieve student grades for multiple courses
- **Automatic Calculations**: Real-time calculation of student and course averages
- **Data Visualization**: Interactive bar charts showing course performance
- **Excel Export**: Export student data to `.xlsx` format for offline analysis
- **RESTful API**: Platform-agnostic JSON API accessible from any client

## ✨ Features

- 📊 **Interactive Dashboard** - View student averages in a clean, modern table
- 📈 **Course Analytics** - Visualize average grades per course with Chart.js
- 📥 **Excel Export** - Download student data as Excel spreadsheet
- 🎨 **Modern UI** - Beautiful gradient buttons and responsive design
- 🔄 **Real-time Updates** - Load fresh data from the API with one click
- 🌐 **Cross-Platform API** - RESTful JSON API works with any programming language

## 🛠️ Technology Stack

### Backend
- **ASP.NET Core 10.0** - Web API framework
- **Entity Framework Core** - ORM for database operations
- **SQL Server** - Relational database
- **C# 12** - Programming language

### Frontend
- **Angular 16** - Frontend framework
- **TypeScript** - Type-safe JavaScript
- **Chart.js** - Data visualization library
- **XLSX** - Excel file generation
- **CSS3** - Modern styling with gradients and animations

## 🚀 Getting Started

### Prerequisites
- [.NET 10.0 SDK](https://dotnet.microsoft.com/download)
- [Node.js 18+](https://nodejs.org/)
- [SQL Server](https://www.microsoft.com/sql-server) (LocalDB or Express)

### Installation

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd DanosStudentGrade
   ```

2. **Configure the Database**
   
   Update the connection string in `DanosStudentGrade.Server/appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=.;Database=DanosDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"
     }
   }
   ```

3. **Install Backend Dependencies**
   ```bash
   cd DanosStudentGrade.Server
   dotnet restore
   ```

4. **Install Frontend Dependencies**
   ```bash
   cd ../danosstudentgrade.client
   npm install
   ```

### Running the Application

#### Option 1: Run Both Services Separately

**Terminal 1 - Backend:**
```bash
cd DanosStudentGrade.Server
dotnet run
```
The API will start at `http://localhost:5053`

**Terminal 2 - Frontend:**
```bash
cd danosstudentgrade.client
npm start
```
The Angular app will start at `https://localhost:13590` (or another available port)

#### Option 2: Run from Visual Studio
1. Open `DanosStudentGrade.slnx`
2. Press F5 to run both projects simultaneously

### First Run
On the first run, the application will:
- Create the database automatically
- Run migrations to set up tables
- Seed initial test data (3 students, 6 grade records)

## 📡 API Documentation

### Base URL
```
http://localhost:5053/api
```

### Endpoints

#### Get Dashboard Data
Returns all student averages and course averages.

**Request:**
```http
GET /api/grades
```

**Response:** `200 OK`
```json
{
  "studentAverages": [
    {
      "studentName": "Abdulhakim Zeinu",
      "averageGrade": 87.5
    },
    {
      "studentName": "Bob Smith",
      "averageGrade": 80.0
    },
    {
      "studentName": "Charlie Abera",
      "averageGrade": 89.5
    }
  ],
  "courseAverages": [
    {
      "courseName": "Math",
      "averageGrade": 81.5
    },
    {
      "courseName": "Physics",
      "averageGrade": 89.0
    },
    {
      "courseName": "Chemistry",
      "averageGrade": 86.5
    }
  ]
}
```

### Using the API from Different Languages

**cURL:**
```bash
curl http://localhost:5053/api/grades
```

**Python:**
```python
import requests
response = requests.get('http://localhost:5053/api/grades')
data = response.json()
print(data['studentAverages'])
```

**JavaScript/Node.js:**
```javascript
fetch('http://localhost:5053/api/grades')
  .then(res => res.json())
  .then(data => console.log(data));
```

**Java:**
```java
HttpClient client = HttpClient.newHttpClient();
HttpRequest request = HttpRequest.newBuilder()
    .uri(URI.create("http://localhost:5053/api/grades"))
    .build();
HttpResponse<String> response = client.send(request, HttpResponse.BodyHandlers.ofString());
```

## 📖 Usage Guide

### Student List Page

1. **Load Data**
   - Click the purple "Load Data" button
   - Student names and average grades appear in the table

2. **Export to Excel**
   - After loading data, click the pink "Export to Excel" button
   - A file named `StudentGrades.xlsx` will download
   - Open in Excel, Google Sheets, or any spreadsheet application

### Course Averages Page

1. Navigate to "Course Averages" using the top navigation
2. View the bar chart showing average grade per course
3. Chart loads automatically on page load

## 📁 Project Structure

```
DanosStudentGrade/
├── DanosStudentGrade.Server/          # Backend API
│   ├── Controllers/
│   │   └── GradesController.cs        # API endpoints
│   ├── Data/
│   │   └── AppDbContext.cs            # EF Core context & seed data
│   ├── Models/
│   │   ├── Student.cs                 # Student entity
│   │   ├── Grade.cs                   # Grade entity (composite key)
│   │   └── DashboardData.cs           # DTOs
│   ├── Services/
│   │   └── StudentGradeService.cs     # Business logic
│   └── Program.cs                     # App configuration
│
└── danosstudentgrade.client/          # Frontend Angular app
    ├── src/app/
    │   ├── services/
    │   │   └── api.service.ts         # HTTP client service
    │   ├── student-list/              # Student list component
    │   ├── course-chart/              # Chart component
    │   └── app.module.ts              # App configuration
    └── src/proxy.conf.js              # Dev proxy config
```

## 🗄️ Database Schema

### Students Table
| Column | Type | Description |
|--------|------|-------------|
| Id | int | Primary key |
| Name | nvarchar | Student name |

### Grades Table
| Column | Type | Description |
|--------|------|-------------|
| Student_Id | int | Foreign key (composite PK) |
| Course_Id | int | Course identifier (composite PK) |
| Course_Name | nvarchar | Course name |
| GradeValue | float | Numeric grade |

**Composite Primary Key:** (Student_Id, Course_Id)

## 🎨 UI Features

- **Modern Gradient Buttons** - Purple and pink gradients with hover effects
- **Smooth Animations** - Buttons lift on hover with shadow transitions
- **Responsive Table** - Clean design with hover effects on rows
- **Professional Typography** - Segoe UI font family
- **Color-Coded Headers** - Gradient headers matching button theme

## 🔧 Development

### Adding New Students/Grades
Edit `DanosStudentGrade.Server/Data/AppDbContext.cs` and modify the seed data in `OnModelCreating()`.

### Creating Migrations
```bash
cd DanosStudentGrade.Server
dotnet ef migrations add MigrationName
dotnet ef database update
```

## 📝 License

This project is licensed under the MIT License - see the LICENSE.txt file for details.

## 👤 Author

Abdulhakim Zeinu

---

**Note:** This is a demonstration project showcasing full-stack development with ASP.NET Core and Angular.
