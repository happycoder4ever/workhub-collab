# WorkHub Skeleton Project

## Overview

WorkHub is a training repository designed to teach professional development workflows with a starter architecture for backend and frontend development.

### Included features

- .NET 10 backend with layered architecture
- Entity Framework Core data access
- PostgreSQL database support
- Vue 3 + TypeScript frontend with Vue Router
- Docker Compose orchestration
- GitHub Actions CI pipeline
- Basic Project CRUD UI and API

## Local setup

### Backend

1. Open the repository root in your terminal.
2. Restore backend dependencies:
   ```bash
   cd backend
   dotnet restore
   ```
3. Build the backend:
   ```bash
   dotnet build
   ```
4. Run the backend:
   ```bash
   cd WorkHub.Api
   dotnet run
   ```

### Frontend

1. Install frontend dependencies:
   ```bash
   cd frontend
   npm ci
   ```
2. Start the frontend app:
   ```bash
   npm run dev
   ```
3. Open the local URL shown in the terminal.

## Docker setup

From the repository root run:

```bash
docker compose up
```

This command starts:

- PostgreSQL
- Redis
- Backend API
- Frontend app

## Development workflow

- Create a feature branch per WorkHub ticket.
- Follow naming conventions in `docs/contributing.md`.
- Use PRs for code review and CI validation.
- Update documentation and tests with new functionality.
