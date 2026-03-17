### Instructions
To start the program do the following:

- Navigate to the KeyManager.API folder
- docker-compose up -d
- dotnet ef migrations add InitialCreate --project ../KeyManager.Persistence --startup-project .
- dotnet ef database update