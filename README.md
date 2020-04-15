# Blog

Blog management application in .net core and angular 2. Application is manged in docker. Currently only dev version.

## Run

To run application go to application folder and run this in your terminal

```bash
docker-compose -f docker-compose.yml -f docker-compose.dev.yml up --build

```

Application should be avialibale on this addres

<http://localhost:8000>

To stop

```bash
docker-compose stop
```

## Update

To update the C# code inside docker container first stop the containers and then rebuild to copy new code.

```bash
docker system prune
docker-compose stop && docker-compose -f docker-compose.yml -f docker-compose.dev.yml up --build
```

## Debug

Example launch.json file in vsc code

```json
{
        "name": ".NET Core Docker Attach",
        "type": "coreclr",
        "request": "attach",
        "processId": "${command:pickRemoteProcess}",
        "sourceFileMap": {
            "/app": "${workspaceFolder}"
        },
        "pipeTransport": {
            "pipeProgram": "docker",
            "pipeArgs": [ "exec", "-i", "blog_web_1" ],
            "debuggerPath": "./vsdbg/vsdbg",
            "pipeCwd": "${workspaceRoot}",
            "quoteArgs": false
        },
}
```
