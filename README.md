# Taskmanager WebApp

# Local dev environment setup

## Software Requirements
.NET Core, yarn, parcel, Visual Studio, Docker

## Build From Source
1. Clone the project and cd into the Web project's directory:
    ```sh
    git clone git@github.com:jesdin/taskmanager-webapp.git
    cd taskmanager-webapp
    ```
2. Build front end assets
    ```sh
    yarn
    yarn build
    ```

## Docker

Build using docker-compose
```sh
docker-compose build
```
Start Server
```sh
docker-compose up
```
Stop Server
```sh
docker-compose stop
```
Delete Containers
```sh
docker-compose down
```

# Screenshots

Index Page
![Alt text](/ScreenShots/index1.PNG?raw=true "Optional Title")
![Alt text](/ScreenShots/index2.PNG?raw=true "Optional Title")

Create Page
![Alt text](/ScreenShots/create.PNG?raw=true "Optional Title")