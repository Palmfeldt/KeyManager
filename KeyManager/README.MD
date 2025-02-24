### Instructions
To start the program do the following:

- docker-compose up -d
- dotnet ef migrations add InitialCreate --project ../KeyManager.Persistence --startup-project .
- dotnet ef database update