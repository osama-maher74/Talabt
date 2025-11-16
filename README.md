Talabat API

Talabat is a modular, production-ready ASP.NET Core Web API built using Clean Architecture (Onion Architecture). It demonstrates enterprise development concepts such as the Unit of Work pattern, Specification pattern, Redis-based basket storage, ASP.NET Identity for authentication, JWT bearer tokens, global exception handling, automatic database migrations, and a scalable project structure suitable for real-world applications.

Highlights

• Clean Onion Architecture
• Repository + Unit of Work Pattern
• Specification Pattern for advanced querying
• Redis basket repository
• ASP.NET Identity with roles
• JWT Authentication
• AutoMapper
• SQL Server + EF Core
• Swagger/OpenAPI for documentation
• Global error handling middleware
• Automatic migration & seeding

Architecture & Project Structure

src/
• APIs → LinkDev.Talabat.APIs
• Application → LinkDev.Talabat.Application
• Domain → LinkDev.Talabat.Domain
• Infrastructure → LinkDev.Talabat.Infrastracture + Persistence
test/ → Optional testing project

API project includes:
• Middlewares (Exception handler)
• Extintions (Extensions for services/middleware)
• Controllers
• Helpers (Mapping, pagination)

Key Technologies & Patterns

• ASP.NET Core 7/8
• Entity Framework Core
• SQL Server
• Redis (StackExchange.Redis)
• Unit Of Work + Generic Repository
• Specification Pattern
• AutoMapper
• JWT + Identity
• Swagger

Getting Started
Prerequisites

• .NET 6/7/8 SDK
• SQL Server
• Redis
• Optional Docker

Configuration (appsettings.json)

ConnectionStrings → SQL Server
Redis → localhost:6379
RedisSettings → TTL
JwtSettings → Issuer, Audience, Key (long and secure)

Example:

{
"ConnectionStrings": {
"StoreContext": "Server=.;Database=TalabatStoreDb;Trusted_Connection=True",
"IdentityContext": "Server=.;Database=TalabatIdentityDb;Trusted_Connection=True"
},
"Redis": "localhost:6379",
"RedisSettings": { "TimeToliveInDays": "30" },
"JwtSettings": {
"Issuer": "TalabatApi",
"Audience": "TalabatClients",
"Key": "REPLACE_WITH_LONG_SECURE_KEY"
}
}

Database Migrations

Add migration:

dotnet ef migrations add InitialCreate -p ./src/LinkDev.Talabat.Infrastracture.Persistence -s ./src/LinkDev.Talabat.APIs

Apply migration:

dotnet ef database update -p ./src/LinkDev.Talabat.Infrastracture.Persistence -s ./src/LinkDev.Talabat.APIs

The project also includes automatic migration & seeding on startup via app.IntializeDbAsync().

Run the Application

cd src/LinkDev.Talabat.APIs
dotnet run

Swagger URL:
https://localhost:{port}/swagger

Docker (Optional)

Example docker-compose:

sqlserver → mcr.microsoft.com/mssql/server
redis → redis:6

Ports:
1433 → SQL Server
6379 → Redis

Features & Endpoints
Products

• Get all products
• Filtering, sorting, pagination
• Product by ID
• Brands & categories

Basket (Redis)

• Get basket
• Update basket
• Delete basket

Authentication

• Register
• Login
• JWT token generation
• Role-based authorization

Errors

Unified error models:
• ApiResponse
• ApiValidationErorrResponse
• ApiExceptionResponse

Core Concepts
Unit of Work

Manages repositories & SaveChanges using CompleteAsync().

Generic Repository

Basic CRUD, specification support, includes, filtering & sorting.

Specification Pattern

Used for:
• filtering
• includes
• sorting
• pagination

Example: ProudctWithBrandAndCategorySpacefications includes category and brand + filtering.

Redis Basket Repository

Baskets stored as JSON in Redis using IConnectionMultiplexer.

JWT Authentication

Token includes user id, email, roles, claims.
Configured in Program.cs.

Testing & Seed Data

Automatic seeding for:
• Products
• Brands
• Categories
• Identity default roles/users (if included)

Use Swagger/Postman for testing JWT-protected endpoints.

Troubleshooting

• Token validation error → check JWT key, issuer, audience
• Migrations fail → check database permissions & paths
• Redis error → ensure Redis is running at correct host/port
• Null references on includes → ensure AutoMapper profiles + specifications are correct

Contributing

• Fork repo
• Create feature branch
• Make changes
• Add tests if needed
• Submit PR

Follow Clean Architecture principles.

License

This project is provided for learning/demo purposes.
You can add MIT License if needed.

Author

Developed by Osama as part of advanced .NET backend practice.
Contributions & issues are welcome.
