# DotNet Full Stack Journey - Notification System

## Overview
This repository showcases my journey to becoming a professional .NET Full Stack Developer. It starts with a modular notification system, built iteratively to demonstrate core skills in C#, .NET, SOLID principles, and more.

## Tasks & User Stories
### Task 1: Implement NotificationService with SOLID Principles
- **User Story**: "As a developer, I need a notification system that supports multiple delivery methods (email, SMS, push notifications), follows SOLID principles, and allows easy testing."
- Implemented `INotificationService`, `EmailNotificationService`, `SMSNotificationService`, and `PushNotificationService` with Dependency Injection (DI) and unit tests using Moq.

### Task 2: Refactor Code Duplication Using Interfaces & Abstract Classes
- **User Story**: "As a developer, I want to reduce repeated code in notification services by extracting common logic into a base class."
- Refactored with `BaseNotificationService`, ensuring Liskov Substitution Principle (LSP) and adding logging with ILogger.

## Tech Stack
- C#, .NET 8
- ASP.NET Core (for DI setup)
- xUnit, Moq (testing)
- Microsoft.Extensions.Logging (logging)

## How to Run
1. Clone this repo: `git clone <your-repo-url>`
2. Open in Visual Studio 2022
3. Build the solution: `dotnet build`
4. Run the Runner: `dotnet run NotificationSystem.Runner` (or F5 in VS)

## Future Work
- Task 3: Implementing `ITextTransformer` for dynamic text processing in notifications.

## License
MIT License