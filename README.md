# LeadFlow — ASP.NET Core Strong Junior Course

LeadFlow is a production-like B2B CRM backend for managing leads, sales pipelines, users, activities and analytics.

## Goal

Build the project step-by-step from a simple ASP.NET Core Web API to a production-like backend by August 28, 2026.

## Stack

- C#
- .NET 8
- ASP.NET Core 8 Web API
- Entity Framework Core
- PostgreSQL
- ASP.NET Core Identity
- JWT + Refresh Tokens
- Swagger / OpenAPI
- NUnit
- Moq
- Integration Testing
- Docker / Docker Compose
- Linux / Nginx
- Git

## Learning rule

Do not copy a finished project. Each day:
1. Learn the concept.
2. Implement it in LeadFlow.
3. Test it.
4. Commit it to Git.
5. Explain why it works.

## Final architecture

Client
→ HTTPS / Nginx
→ ASP.NET Core API
→ Application / Business Logic
→ Infrastructure / EF Core
→ PostgreSQL

Supporting components:
- Identity / JWT
- Global exception handling
- Validation
- Logging
- Background services
- Unit tests
- Integration tests
- Docker
