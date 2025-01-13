# DonatorAPI
 API Request for Donation data


## Migrations
For using EFCore migrations, make sure you have `dotnet-ef` package insalled globally:
```bash
dotnet tool install --global dotnet-ef
```

To create a new migration with EF Core, use the following command:
```bash
dotnet ef migrations add <migration name> --project DonatorAPI.Data/DonatorAPI.Data.csproj --startup-project DonatorAPI
```

To migrate database to latest version, use the following command:
```bash
dotnet ef database update --project DonatorAPI.Data/DonatorAPI.Data.csproj --startup-project DonatorAPI
```

For more related information see [EF Core tool guide](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)
