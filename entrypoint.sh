#!/bin/bash

set -e

run_cmd="dotnet bin/Debug/netcoreapp2.1/Blog.Web.dll --server.urls http://*:80"

until cd /app/Blog.Dal && dotnet ef database update; do
>&2 echo "SQL Server is starting up"
sleep 1
done

>&2 echo "SQL Server is up";
cd /app/Blog.Web;
exec $run_cmd;
