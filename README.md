# Contact Management API

Backend application for managing Contact with common basic API features built with ASP.NET Core.

## Tech Stacks

- ASP.NET Core
- SQL Server

**Author's System Environment:**

- .NET 8
- SQL Server 16
- Visual Studio 2022
- OS Windows 10 64-bit

## .NET Implemented Features

- Database context dependency injection
- Controller API
- EF Core CRUD
- EF Core migration
- DTO
- Pagination

## Quickstart

- **Clone** repository

    ```bash
    git clone https://github.com/fuadmln/dotnet-contact-api
    ```

- **Create** database in SQL Server
- Set **database connection string** </br>
Open `/src/appsettings.json` and edit `"DefaultConnection"` value with your database configuration.
- **Run migration** </br>
    with Package Manager Tools:

    ```bash
    update-database
    ```

    with .NET CLI:

    ```bash
    dotnet ef database update
    ```

- **Running project**

    Build and run project via Visual Studio </br>
    or, Run via CLI:

    ```bash
    cd project_folder_name

    dotnet run
    ```

- **Using Swagger** </br>

    Visit <https://localhost/swagger/>
