.Net Challenge
====================================

This is the .Net Challenge project.

# Requirement
* [ASP.Net core 2.2](https://dotnet.microsoft.com/download).
* [Node.js](https://nodejs.org/en/download/package-manager/) ver 8.12.0 above

# Usage
BE and FE needs to run **in separated sessions**, e.g. multiple bash windows or in background.

**Cross platform**. Though only tested on Windows.

## Cloning the repo

```
git clone https://github.com/BenjaminZ/DotNetChallenge.git
```

## BE

In the solution root folder `DotNetChallenge/`:

```
dotnet restore
cd ./DotNetChallenge.Web
dotnet run
```

Url:
```
http://localhost:5000/api/conversion
https://localhost:5001/api/conversion
```

## FE

In the solution root folder:

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
