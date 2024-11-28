# METAL ARCHIVES API

This is a simple API to get information about bands, albums, and songs from the Metal Archives website.
It uses .Net Core 8.0 and Identity Provider to authenticate users based on Entity Framework.

## Getting Started

This project uses `husky` to run pre-commit hooks, so you need to install it before starting development. You can install it by running the command:

```
npm install
npm run prepare
```

To run this project, you need to have .Net Core 8.0 installed on your machine. You can download it [here](https://dotnet.microsoft.com/download/dotnet/8.0).
For development, a Docker container is provided to run SQl Server database, just run the command:

```
docker-compose up -d
```

Once the database is running, you can apply the migrations to create the database schema using `dotnet-cli`:

```
dotnet ef database update
```
