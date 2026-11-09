# Food Delivery System (MVC)

A web application for managing food deliveries, built using the MVC.

The system allows users to place orders through a web interface, while administrative operations are handled through a RESTful API built with ApiControllers while using Swagger for user interface.

## Features

### Customer-facing UI (MVC)
- View all restaurants
- View the restaurants menu
- Place food orders through a web interface

### Admin API (ApiController and Swagger)
- View all orders
- Assign orders to delivery drivers (couriers)
- Create and manage couriers
- Manage order status

## Tech Stack
- ASP.NET Core MVC
- ASP.NET Web API (ApiControllers)
- Entity Framework
- Sqlite Database

## Architecture
The solution follows a Clean Architecture approach, with a clear separation of concerns:

- **API** – REST API layer (ASP.NET Core Web API)
- **Web** – MVC frontend for customer interaction
- **Domain** – Core business logic and entities
- **Infrastructure** – Data access and external services

All projects (except tests) are organized under the /src directory to maintain a clean and scalable structure.

## Notes
This project was developed as part of a learning assignment and demonstrates fundamental full-stack web development concepts .
