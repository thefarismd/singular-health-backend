## Prerequisites

- .NET 9 SDK (version 9.0.203 or later)
  
## Development Setup

1. Navigate to the `/singular-health-backend` folder:
   
2. Restore all NuGet packages:
    ```bash
    dotnet restore
    ```

3. CD to `src/ScanNotesManager.API` folder
    ```bash
    dotnet run
    ```

## Assumptions & Trade-offs

- The backend uses **in-memory data storage**; all data will be lost when the server restarts.
- No custom exception handling or global error middleware — only basic model validation.
- No logging
- No API versioning

## Estimated Time Spent

- 2.5 Hours