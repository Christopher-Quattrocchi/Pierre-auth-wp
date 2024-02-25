# SillyStringz Factory Management System

## Table of Contents
- [About](#about)
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Installation](#installation)
- [Setting Up SQL](#setting-up-sql)
- [Known Bugs](#known-bugs)
- [License](#license)
- [Contact](#contact)

## About
This MVC web application is designed to manage the operations of a bakery. Treats and Flavors can be assigned to each other (many to many). Only registered, logged in users can affect the bakery, but any user can view.

## Features
- **Treats**: Create and manage treat profiles.
- **Flavors**: Create and manage flavor profiles.
- **Association**: Link flavors and treats (many to many).
- **Authentication**: User must be logged in for full functionality

## Technologies Used
- **Language**: C#
- **Framework**: .NET 5.0 or .NET 6.0
- **IDE**: Visual Studio 2019 or 2022
- **Database Management**: Entity Framework Core, Microsoft.EntityFrameworkCore.SqlServer
- **Version Control**: Git

## Installation
Follow these steps to get a local copy up and running:

1. **Clone the Repository**
   ```bash
   git clone https://github.com/Christopher-Quattrocchi/Pierre-auth-wp.git

2. **Navigate to the Project Directory**
cd Bakery.Solutions
cd Bakery

3. **Restore Dependencies**
dotnet restore

4. **Build the Project**
dotnet build

5. **Run the Project**
dotnet run

Access the application through a web browser at the indicated URL, typically `http://localhost:5000`.

## Setting up the SQL Database

This project uses a SQL database to store and manage data. Follow the instructions below to set up the database environment:

### Prerequisites

- If needed, install SQL Workbench: [official website](https://www.mysql.com/products/workbench/).

1. **Open SQL Workbench** and connect to your MySQL server.

2. **Import the Database Schema**:
   - In the top menu, navigate to `Server` > `Data Import`.
   - Choose "Import from Self-Contained File" and select the `chris_quattrocchi3.sql` file located in your project directory.
   - Under "Default Target Schema", either select an existing schema or create a new one to import the tables into.
   - Click `Start Import` at the bottom right to execute the script and create the tables in your database.

3. **Configure Connection String**:
   - In your application's `appsettings.json` file, update the connection string to match your database name and credentials:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=yourDatabaseName;Uid=yourUsername;Pwd=yourPassword;"
     }
   }

## Apply Migrations:
dotnet ef database update

## Known Bugs
Log off doesn't work properly

## License
This project is licensed under the MIT License.

## Contact
chrisquattrocchi@gmail.com