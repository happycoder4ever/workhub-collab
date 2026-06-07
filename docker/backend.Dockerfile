FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY WorkHub.Api/WorkHub.Api.csproj WorkHub.Api/
COPY WorkHub.Application/WorkHub.Application.csproj WorkHub.Application/
COPY WorkHub.Domain/WorkHub.Domain.csproj WorkHub.Domain/
COPY WorkHub.Infrastructure/WorkHub.Infrastructure.csproj WorkHub.Infrastructure/

RUN dotnet restore WorkHub.Api/WorkHub.Api.csproj

COPY . .
WORKDIR /src/WorkHub.Api
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT ["dotnet", "WorkHub.Api.dll"]
