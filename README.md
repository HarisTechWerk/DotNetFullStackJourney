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

- **Live Demo**:
  - **Solution Structure**: 
    <details><summary>Click to see VS 2022 Solution Explorer</summary>
    <img src="docs\Task2_Structure.png" alt="Task 2 Solution Structure" width="600"/>
    </details>
  - **Runner Output**: 
    <details><summary>Click to see Debug Console Logs</summary>
    <img src="docs\Task2_Output.png" alt="Task 2 Runner Output" width="600"/>
    </details>
  - **Tests Passing**: 
    <details><summary>Click to see Test Explorer</summary>
    <img src="docs\Task2_Tests.png" alt="Task 2 Unit Tests" width="600"/>
    </details>

### Task 3: Implement a ITextTransformer Interface to Standardize Text Processing
- **User Story**: "As a developer, I want all text transformations to happen via `ITextTransformer` so we can easily swap different transformation strategies."
- Created `ITextTransformer` interface, implemented `UpperCaseTransformer` and `ReverseTextTransformer`, and integrated with DI to dynamically transform notification messages (e.g., uppercase for email/Push, reverse for SMS). Refactored `EmailNotificationService` and `SMSNotificationService` to inherit `BaseNotificationService` and use `ITextTransformer`.
- **Live Demo**:
  - **Solution Structure**: 
    <details><summary>Click to see VS 2022 Solution Explorer</summary>
    <img src="docs\Task3_Structure.png" alt="Task 3 Solution Structure" width="600"/>
    </details>
  - **Runner Output**: 
    <details><summary>Click to see Debug Console Logs</summary>
    <img src="docs\Task3_Output.png" alt="Task 3 Runner Output" width="600"/>
    </details>
  

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

## License
MIT License