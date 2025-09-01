# CleanArch-MyApp-CRUD

A .NET Core Web API implementing Clean Architecture principles with simple CRUD operations. This guide is designed for DevOps engineers to deploy and maintain the application.

## Table of Contents

- [Deployment Requirements](#deployment-requirements)
- [Quick Start Guide](#quick-start-guide)
- [Configuration](#configuration)
- [Deployment Steps](#deployment-steps)
- [Health Checks](#health-checks)
- [Monitoring](#monitoring)
- [Troubleshooting](#troubleshooting)

## Deployment Requirements

### System Prerequisites
- **.NET Runtime**: .NET 9.0 SDK
- **Database**: SQL Server 2019 or later (Express/Standard/Enterprise)
- **Web Server**: IIS (Windows) or Nginx (Linux)
- **OS**: Windows Server 2019+ or Linux (Ubuntu 20.04+)

### Resource Requirements
- **CPU**: 2 cores minimum
- **RAM**: 4GB minimum
- **Storage**: 1GB for application, 10GB+ for database
- **Network**: HTTP/HTTPS ports (default: 5176)

## Quick Start Guide

1. **Verify .NET Installation**:
   ```bash
   dotnet --version   # Should show 9.0.x
   ```

2. **Clone Repository**:
   ```bash
   git clone https://github.com/mazhar-invobyte/CleanArch-MyApp-CRUD.git
   cd CleanArch-MyApp-CRUD
   ```

3. **Build Application**:
   ```bash
   dotnet build
   ```

## Configuration

### Database Setup
1. **Create Database**:
   - Open SQL Server Management Studio
   - Create new database named `MyAppDb`
   - Or use command line:
     ```sql
     CREATE DATABASE MyAppDb;
     ```

2. **Configure Connection String**:
   - Location: `MyApp.Api/appsettings.json`
   - Format:
     ```json
     {
       "ConnectionStrings": {
         "MyAppDb": "Server=YOUR_SQL_SERVER;Database=MyAppDb;User Id=YOUR_USER;Password=YOUR_PASSWORD;TrustServerCertificate=True;"
       }
     }
     ```

### Environment Variables
Required environment variables:
```bash
ASPNETCORE_ENVIRONMENT=Production
ASPNETCORE_URLS=http://+:5176
```

## Deployment Steps

1. **Publish Application**:
   ```bash
   dotnet publish -c Release -o ./publish
   ```

2. **Database Migration**:
   ```bash
   cd publish
   dotnet ef database update --project MyApp.Infrastructure
   ```

3. **Start Application**:
   ```bash
   cd publish
   dotnet MyApp.Api.dll
   ```

4. **Verify Deployment**:
   - API URL: `http://localhost:5176`
   - Swagger Documentation: `http://localhost:5176/swagger`

### Docker Deployment
```bash
# Build image
docker build -t cleanarch-myapp .

# Run container
docker run -d -p 5176:5176 \
  -e "ConnectionStrings__MyAppDb=Server=host.docker.internal;Database=MyAppDb;..." \
  cleanarch-myapp
```

## Health Checks

- **API Health**: `GET http://localhost:5176/health`
- **Database Health**: `GET http://localhost:5176/health/db`

Expected Response:
```json
{
  "status": "Healthy",
  "checks": [
    {
      "name": "Database",
      "status": "Healthy"
    }
  ]
}
```

## Monitoring

### Key Metrics to Monitor
- CPU Usage
- Memory Usage
- HTTP Request Rate
- Database Connection Count
- Response Times
- Error Rate

### Log Locations
- **Application Logs**: `./logs/app-{date}.log`
- **Error Logs**: `./logs/error-{date}.log`

## Troubleshooting

### Common Issues

1. **Database Connection Failed**
   - Verify SQL Server is running
   - Check connection string
   - Ensure firewall allows SQL port (default 1433)

2. **Application Won't Start**
   - Check port availability
   - Verify .NET runtime version
   - Check log files for errors

3. **Migration Errors**
   - Ensure database exists
   - Verify database user permissions
   - Check migration history table

### Support Contacts
- **Development Team**: dev-team@company.com
- **Database Admin**: dba@company.com

## License

This project is licensed under the MIT License.

---

**Last Updated**: 2025-09-01 12:26:31 UTC  
**Updated By**: [mazhar-invobyte](https://github.com/mazhar-invobyte)