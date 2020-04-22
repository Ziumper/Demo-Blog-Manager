# Blog

Blog management application in .net core and angular 2. Application is manged in docker. Currently only dev version.

## Setup

To build and run dev version use this script:

```bash
bash scripts/setup.sh
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
bash scripts/recompile.sh
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
