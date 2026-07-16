# weather-alert-tracker
A cloud-enabled REST API built using ASP.NET Core that allows users to save cities and receive weather alerts whenever forecast conditions exceed configured thresholds.

---

## Features

- Save favourite cities
- Configure weather alerts
- Retrieve weather forecasts
- Scheduled weather checks
- Email notifications using AWS SNS
- PostgreSQL database
- Cloud deployment on AWS

---

## Tech Stack

- ASP.NET Core 9
- C#
- Entity Framework Core
- PostgreSQL
- AWS
- OpenWeatherMap API
- Swagger

---

## Project Structure

```text
WeatherAlertTracker.sln

src/
├── WeatherAlertTracker.API
├── WeatherAlertTracker.Application
├── WeatherAlertTracker.Domain
└── WeatherAlertTracker.Infrastructure

tests/
└── WeatherAlertTracker.Tests
```

---

## Database Schema

Cities
------
Id (Guid)
Name
Province
Country
Latitude
Longitude
CreatedAt

Alerts
------
Id (Guid)
CityId (FK)
WeatherType
Threshold
IsActive
Email
CreatedAt

---

## Relationship

City (1) ---- (*) Alert

A city can have multiple alerts.

