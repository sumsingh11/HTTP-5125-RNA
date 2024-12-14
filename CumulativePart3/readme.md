# Cumulative Part 3: Teacher, Student, and Course Management System.


## Overview

This project is the third assignment of the Cumulative Assessment for Back-End Web Development subject. It aims to develop a web-based Teacher, Student, and Course Management System utilizing ASP.NET Core and MySQL. The system now includes features for updating teacher, student, and course details and robust error handling to manage invalid input scenarios.


## Features
### Core Functionality
- **View Teachers**: Displays the list of teachers and their details.
- **View Students**: Displays the list of students and their details.
- **View Courses**: Displays the list of courses and their details.
- **Insert Teachers**: Allow adding new teachers to the system.
- **Insert Students**: Allow adding a new students to the system.
- **Insert Courses**: Allow adding a new courses to the system.
- **Delete Teachers**: Allow deleting a teachers from the system.
- **Delete Students**: Allow deleting a students from the system.
- **Delete Courses**: Allow deleting a courses from the system.
- **Update Teachers**: Allow updating a existing teacher information.
- **Update Students**: Allow updating a existing student information.
- **Update Courses**: Allow updating an existing course information.


### Enhanced Error Handling
- **Empty Fields**:
  - Teacher Name, Student Name, and Course Name cannot be empty.
- **Invalid Dates**:
  - Start Date and Finish Date cannot be in the future dates.


## Technologies Used
- **HTML/CSS**: For building the front-end of the application.
- **ASP.NET Core**: For building the web application and API.
- **MySQL**: For database management and storage.


## Setup
To run this project lin local machine, follow the steps below:

### Prerequisites
- A suitable IDE (Visual Studio or VS Code)
- .NET 6.0 SDK or higher
- MySQL Server


### Clone the Repository
```bash
git clone https://github.com/sumsingh11/HTTP-5125-RNA.git
```

### Configure the Database
1. Create a MySQL database for the project.
2. Update the `appsettings.json` file with your database connection details.
3. Use the provided SQL script to create the required tables: Teachers, Students, and Courses.


## Testing
### API Testing
- First verify the HTTP PUT methods for updating teachers, students, and courses using tools like Postman or CURL.
- Include the following test cases:
  - Update with valid data.
  - Attempt to update with empty names.
  - Attempt to update with future dates.

### UI Testing
- Testing the web pages for updating teachers, students, and courses by manually entering valid and invalid data.
- Ensuring correct error messages are displayed for invalid input.

## Error Handling Examples
### Server-Side Validation
- Reject updates for:
  - Empty Teacher Name.
  - Future Start Date or Finish Date.
  - Negative Salary for teachers.

### Client-Side Validation
- Display error messages when:
  - Required fields are left empty.
  - Dates are in the future.