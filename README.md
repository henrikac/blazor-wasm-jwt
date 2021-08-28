# BlazorWASM-JWT-Auth (WIP)

## Requirements
+ .NET 5 (previous versions might work too)
+ PostgreSQL
+ [LibMan](https://docs.microsoft.com/en-us/aspnet/core/client-side/libman/?view=aspnetcore-5.0)

## Setup
#### Add migrations
```terminal
dotnet ef migrations add <migration-name> --project BlazorWasmJwt.DAL/BlazorWasmJwt.DAL.csproj --startup-project BlazorWasmJwt.API/BlazorWasmJwt.API.csproj
```

#### Run migrations
```terminal
dotnet ef database update --project BlazorWasmJwt.DAL/BlazorWasmJwt.DAL.csproj --startup-project BlazorWasmJwt.API/BlazorWasmJwt.API.csproj
```

## Usage
#### Run the API (Port 5001 (HTTPS) and 5000 (HTTP))
+ Navigate to `BlazorWasmJwt.API`.
+ Run `dotnet run`.

#### Run the UI (Port 3001 (HTTPS) and 3000 (HTTP))
+ Navigate to `BlazorWasmJwt.UI`.
+ Run `libman restore` to install client-side libraries.
+ Run `dotnet run`.
