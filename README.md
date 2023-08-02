<h1 align="center"><img src="https://raw.githubusercontent.com/shoaibulhaque/Elibrary-Management/master/WebApplication1/book_inventory/PhotoRoom-20230717_205230.png" width="150"></h1> <h1 align="center">BookStack</h1> <p align="center"> <a href="https://dotnet.microsoft.com/apps/aspnet"> <img src="https://img.shields.io/badge/ASP.NET-Core-5C2D91?logo=asp.net&logoColor=white&style=flat-square" alt="ASP.NET Core"> </a> <a href="https://docs.microsoft.com/en-us/dotnet/csharp/"> <img src="https://img.shields.io/badge/C%23-239120?logo=c-sharp&logoColor=white&style=flat-square" alt="C#"> </a> <a href="https://getbootstrap.com/"> <img src="https://img.shields.io/badge/Bootstrap-563D7C?logo=bootstrap&logoColor=white&style=flat-square" alt="Bootstrap"> </a> <a href="https://www.microsoft.com/en-us/sql-server"> <img src="https://img.shields.io/badge/SQL%20Server-CC2927?logo=microsoft-sql-server&logoColor=white&style=flat-square" alt="SQL Server"> </a> </p>

<p align="center">
  <a href="https://github.com/shoaibulhaque/Elibrary-Management/tree/master">
    <img src="https://img.shields.io/badge/GitHub-181717?logo=github&logoColor=white&style=flat-square" alt="GitHub">
  </a>
  <a href="https://github.com/shoaibulhaque/Elibrary-Management/tree/master/database">
    <img src="https://img.shields.io/badge/See%20Database-181717?logo=github&logoColor=white&style=flat-square" alt="See Database">
  </a>
</p>

## BookStack

BookStack is an online library management system that allows users to browse, read, and manage books in a digital catalog.

## Overview
BookStack is a web application developed as a university project. It provides the following functionalities:

- Member signup and login: Users can create their accounts and log in to access the library catalog.
- Book search and viewing: Users can search for books based on title, author, publisher, or category, and view detailed book information, including availability.
- Admin login for librarians: Librarians can log in as admins and access the admin dashboard.
- Managing book inventory: Admins can add, edit, or delete books from the library catalog.
- Managing book authors and publishers: Admins can add, edit, or delete author and publisher information in the database.
- Managing member accounts: Admins can view, edit, or delete member accounts in the database.
- Book issuance and returns: Admins can issue books to members and record return dates.

## Tech Stack
BookStack utilizes the following technologies:

- Backend: ASP.NET with C#
- Database: SQL Server
- Frontend UI: Bootstrap

## Getting Started
To set up the BookStack project on your local machine for development and testing purposes, follow these steps:

### Prerequisites
You will need the following tools and frameworks:

- Visual Studio 2019
- SQL Server
- .NET Core SDK

### Installation
1. Clone the repository:
```bash
https://github.com/shoaibulhaque/Elibrary-Management.git
```
2. Setup the database:
   - Run the SQL script in the `database/` folder to create the necessary database and tables.
   - Configure the connection strings in the `appsettings.json` file to point to your SQL Server instance.
3. Build and run the application using Visual Studio 2019.
4. Code files are located in `WebApplication1/` folder

**By following these steps, you will have BookStack up and running on your local machine, allowing you to develop and test the application.**



