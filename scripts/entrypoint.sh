#!/bin/bash

set -e

run_cmd="dotnet bin/Debug/netcoreapp2.1/Blog.Web.dll --server.urls http://*:80"

until dotnet ef database update --startup-project /app/Blog.Web --project /app/Blog.Dal; do
>&2 echo "SQL Server is starting up"
sleep 1
done

>&2 echo "SQL Server is up";
cd /app/Blog.Web;
exec $run_cmd;
