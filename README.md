# Database setup

## Using EntityFrameworkCore

1. Open appsetting.json file and change the connection string to the connection string of your local database.

```json
"ConnectionStrings": {
  "BitsOrchestraDb": "Your connection string"
}
```

2. Open the project in the terminal. Input the following commands to create the tables in your local database and fill them with initial data:

```
dotnet ef database update InitialCreate
dotnet ef database update SeedData
```

## Using database backup

1. Use the .bak file provided in this repository to restore the MSSQL database.

2. Open appsetting.json file and change the connection string to the connection string of restored database.

```json
"ConnectionStrings": {
  "BitsOrchestraDb": "Your connection string"
}
```
