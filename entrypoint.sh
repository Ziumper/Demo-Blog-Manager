#!/bin/bash

# set -e

# run_cmd="dotnet bin/Debug/netcoreapp2.1/Blog.Web.dll --server.urls http://*:80"

# until cd Blog.Dal && dotnet ef database update && cd ../Blog.Web; do
# >&2 echo "SQL Server is starting up"
# sleep 1
# done

# >&2 echo "SQL Server is up"
# exec $run_cmd
docker exec -ti blog_web_1 sh -c "cd Blog.Dal &&
 dotnet ef database update && cd ../Blog.Web && 
 dotnet bin/Debug/netcoreapp2.1/Blog.Web.dll --server.urls http://*:80"