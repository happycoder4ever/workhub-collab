# Architecture

## High-level architecture

The WorkHub repository is organized into separate backend and frontend applications with a shared documentation area.

- `backend/` contains the .NET solution and layered services.
- `frontend/` contains the Vue 3 + TypeScript app.
- `docs/` contains architecture and contribution documentation.
- `docker/` contains Dockerfiles used by the compose stack.
- `docker-compose.yml` defines containers for backend, frontend, PostgreSQL, and Redis.

## Folder structure

### backend

- `WorkHub.Api` - ASP.NET Web API application and controllers.
- `WorkHub.Application` - application services, DTOs, and service contracts.
- `WorkHub.Domain` - domain entities and business models.
- `WorkHub.Infrastructure` - EF Core database context and repository implementations.

### frontend

- `src/` - application source code.
- `src/router` - Vue Router configuration.
- `src/pages` - page-level views.
- `src/components` - reusable UI components.
- `src/services` - API client code.

## Layer responsibilities

- **API layer:** exposes HTTP endpoints and handles request routing.
- **Application layer:** manages use cases, service orchestration, and business rules.
- **Domain layer:** defines core entities and data models.
- **Infrastructure layer:** connects domain models to persistence and external systems.
