# 📚 School Management System - ASP.NET Core 9 API

This project is a **School Management System** built with **ASP.NET Core 9** and **SQL Server** using **Clean Architecture** principles. It shares architectural similarities with the Clinic Management project but is fully adapted to the education domain. The system manages students, teachers, classes, subjects, schedules, and grades.

---

## 🏗️ Architecture

The project follows **Clean Architecture**, ensuring separation of concerns:

* **API Layer** – Handles HTTP requests and responses.
* **Application Layer** – Contains business logic and use cases.
* **Domain Layer** – Holds entities and core rules.
* **Infrastructure Layer** – Deals with data persistence (EF Core, SQL Server).

---

## 🗃️ Database Design Overview

![Database Diagram](./path/to/your/image.png) <!-- Replace with actual image path if using GitHub -->

The system is centered around the following tables:

### Tables and Relationships:

* **Students**

  * Basic student details: name, email, address, etc.
  * Linked to `StudentSubjects` (for grades).
  * Linked to `Classes`.

* **Subjects**

  * Includes subject metadata.
  * Related to students, teachers, and class schedules.

* **Teachers**

  * Teacher personal information.
  * Associated with subjects via `SubjectTeachers`.

* **Classes**

  * Class number and stage.
  * Connected to students and `ClassSchedules`.

* **StudentSubjects**

  * Mapping table: many-to-many between students and subjects.
  * Contains `MidTermScore` and `FinalScore`.

* **SubjectTeachers**

  * Many-to-many between teachers and subjects.

* **ClassSchedules**

  * Links class, subject, teacher, and schedules.
  * Stores day of week and time.

---

## 🚀 Features

* ✅ Add/Edit/Delete Students, Teachers, Classes, Subjects.
* ✅ Assign Subjects to Teachers and Students.
* ✅ Record Midterm and Final Scores.
* ✅ Define Class Schedules.
* ✅ Query classes by subject, stage, or teacher.
* ✅ Filter students by class, subject, or performance.
* ✅ Secure and scalable RESTful endpoints.

---

## 🛠️ Tech Stack

* **Backend Framework**: ASP.NET Core 9 Web API
* **Database**: SQL Server
* **ORM**: Entity Framework Core
* **Architecture**: Clean Architecture
* **IDE**: Visual Studio 2022
* **API Documentation**: Swagger (Swashbuckle)

---

## 📦 Project Setup

1. **Clone the repository:**

   ```bash
   git clone https://github.com/your-username/SchoolManagementAPI.git
   cd SchoolManagementAPI
   ```

2. **Update `appsettings.json` with your SQL Server connection string.**

3. **Run EF Core migrations:**

   ```bash
   dotnet ef database update
   ```

4. **Launch the API:**

   ```bash
   dotnet run
   ```

5. **Access Swagger UI at:**

   ```
   https://localhost:{PORT}/swagger
   ```

---

## 📂 Folder Structure

```
SchoolManagementAPI/
│
├── Domain/
├── Application/
├── Infrastructure/
├── API/
├── README.md
├── .gitignore
└── ...
```

---

## 🔐 Authentication & Authorization

You can easily integrate **JWT authentication** or **ASP.NET Identity** to manage roles like:

* Admin
* Teacher
* Student

(Current project structure supports plug-and-play extension.)

---

## ✨ Future Enhancements

* [ ] Add user authentication and role-based access.
* [ ] Generate report cards and student transcripts.
* [ ] Export schedules as calendar events.
* [ ] Notifications for class updates or schedule changes.

---

## 🤝 Contribution

Feel free to fork, raise issues, or create pull requests. Your contributions are welcome!

---

## 📜 License

This project is licensed under the MIT License.
