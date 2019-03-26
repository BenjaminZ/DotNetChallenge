# .Net Challenge
This is the .Net Challenge project.

# Requirement
* [ASP.Net core 2.2](https://dotnet.microsoft.com/download).
* [Node.js](https://nodejs.org/en/download/package-manager/) ver 8.12.0 above

# Usage
To run BE:

```
cd ./DotNetChallenge.Web
dotnet restore
dotnet run
```

To run FE:

```
cd ./DotNetChallenge.Web
npm ci
npm run start
```

# About solution

* `DotNetChallenge.Application` project contains business logic e.g. number to string converter
* `DotNetChallenge.Web` project contains Web APIs and UI
* `DotNetChallenge.Tests` project is the unit testing project
