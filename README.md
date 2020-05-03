# Blog

Blog management application in .net core and angular 2. Application is manged in docker. Currently only dev version.

## Setup

To build and run dev version use this script:

```bash
bash scripts/setup.sh
```

Application should be avialibale on this addres

<http://localhost:8000>

## Stop

It is stoping only application inside container not container itself.

```bash
bash scripts/stop.sh
```

## Run 

To run builded containers but stopped containers
```bash
bash scripts/start.sh
```

## Update

To recompile just use:

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
