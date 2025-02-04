# ScoreTracker

A useful tracker for creating a leaderboard for a year long baby foot game.

This tracker is made as a fun side project for work, where we wanted an application which could track our scores, and give stats for each player.

## Roadmap
    [ ] Create users
    [ ] Create teams
    [ ] Authentication

## Want to contribute
Requirements for project to run locally:
* You need a Postgresql database running
* Visual Studio (For your own ease)

The application is written in asp.net core MVC, so setting up the project on a windows machine should be straight forward.

You need to create a appsettings.json in the root of the project, not the repo.

The json file will need to contain this:
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "DataContext": "<<<CONNECTION STRING>>>"
  },
  "AllowedHosts": "*"
}
```

---
Any questions? Then create a issue