# Blog

Demo Blog management application in .net core and angular 2. Application is manged in docker. Currently only dev version.

## Setup

To build and run dev version on OS Mac/Linux use this script. 

```bash
bash scripts/setup.sh
```
There could be some problems with compile or connection durring setup like, just ingore it, 
the database will setup properly in some time.
```log
 System.Data.SqlClient.SqlException (0x80131904): Login failed for user 'sa'.
```

On windows use powershell
```
.scripts/setup.cmd
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


## Wsl2 Min configuration for Windows 10
Check the configuration link: https://docs.microsoft.com/en-us/windows/wsl/wsl-config#configure-global-options-with-wslconfig

```bash
notepad "$env:USERPROFILE/.wslconfig"
```

```
[wsl2]
memory=4GB
processors=2
```