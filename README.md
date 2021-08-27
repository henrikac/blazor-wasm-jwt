# BlazorWASM-JWT-Auth (WIP)

## Requirements
+ .NET 5 (previous versions might work too)
+ PostgreSQL

## Usage
#### Run the API
Navigate to `BlazorWasmJwt.API` and run `dotnet run`.

#### Add migrations
```terminal
dotnet ef migrations add <migration-name> --project BlazorWasmJwt.DAL/BlazorWasmJwt.DAL.csproj --startup-project BlazorWasmJwt.API/BlazorWasmJwt.API.csproj
```

#### Run migrations
```terminal
dotnet ef database update --project BlazorWasmJwt.DAL/BlazorWasmJwt.DAL.csproj --startup-project BlazorWasmJwt.API/BlazorWasmJwt.API.csproj
```
