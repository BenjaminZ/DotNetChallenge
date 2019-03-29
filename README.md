.Net Challenge
====================================

This is the .Net Challenge project.

# Requirement
* [ASP.Net core 2.2](https://dotnet.microsoft.com/download).
* [Node.js](https://nodejs.org/en/download/package-manager/) ver 8.12.0 above

# Usage
BE and FE needs to run separately.

**Cross platform**. Though only tested on Windows.

## Cloning the repo

`git clone` the repository to run the project. If it gives `permission denied` error, please clone via `htts` instead of `ssh`.

## BE

```
dotnet restore
cd ./DotNetChallenge.Web
dotnet run
```

Url:
```
http://localhost:5000/api/conversion
https://localhost:5001/api/conversiion
```

## FE

```
cd ./DotNetChallenge.Web
npm ci
npm run start
```

Url: `http://localhost:8080`

# About solution

* `DotNetChallenge.Application` project contains business logic e.g. number to string converter
* `DotNetChallenge.Web` project contains Web APIs and UI
* `DotNetChallenge.Tests` project is the unit testing project

# Features

BE:

* Swagger UI url: `https://localhost:5001/swagger`. Library [Swashbuckle.AspNetCore](https://github.com/domaindrivendev/Swashbuckle.AspNetCore).
* [Fluent validation](https://fluentvalidation.net/). Used in `DotNetChallenge.Web.Validators`
* [xUnit](https://xunit.github.io/) and [Fluent Assertions](https://fluentassertions.com/) for unit testing.

FE: 

* [Webpack](https://webpack.js.org/)
* [Vue](https://cn.vuejs.org/index.html)
