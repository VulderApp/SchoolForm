# School form
[![Test](https://github.com/VulderApp/SchoolForm/actions/workflows/test.yml/badge.svg)](https://github.com/VulderApp/SchoolForm/actions/workflows/test.yml)
[![codecov](https://codecov.io/gh/VulderApp/SchoolForm/branch/dev/graph/badge.svg?token=4WP3BI0J8M)](https://codecov.io/gh/VulderApp/SchoolForm)

Microservice responsible for school form request management

## Run development server
```bash
$ docker-compose -f docker-compose.dev.yml up -d
$ dotnet restore
$ dotnet watch --project ./src/Vulder.School.Form.Api
```

## Build a release
```bash
$ dotnet restore
$ dotnet build
$ dotnet publish ./src/Vulder.School.Form.Api -c Release
```

## Build a docker image
```bash
$ docker build -t vulderapp/form:release .
```
## Run a docker image
```bash
$ docker run -p 80:80 -e MONGODB_CONNECTION_STRING=connection_string vulderapp/form:release
```