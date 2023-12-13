# Ticket Manager
##Projects:
### TicketManager.Client
--> Contains .NET MAUI CLient for  Windows, Android, IOS and MacOS
  --> Views:
    --> LoginPage
    --> MainPage
    --> TicketView
    --> CustomerView
    --> TODO: Add pages 
    
  --> ViewModels:
    --> VMs for each XAML Page
  --> probably: Models:
    --> custom changes for Domain.Models

### TicketManager.Domain
--> Contains Models for API and Client Architecture
  --> Enums:
    --> Priorities
    --> Status
  --> Models:
    --> Ticket.cs
    --> Developer.cs
    --> Customer.cs

### TicketManager.API
  --> Controllers:
    --> TicketController
      --> GET/POST/PUT/DELETE
    --> CustomerController
      --> GET/POST/PUT/DELETE
    --> DeveloperController
      --> GET/POST/PUT/DELETE
  
