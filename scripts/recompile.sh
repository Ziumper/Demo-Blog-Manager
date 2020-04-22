echo "Killing dotnet process"
docker exec -ti blog_web_1 sh -c "bash scripts/kill.sh"
#Dotnet database update
docker exec -ti blog_web_1 sh -c "cd Blog.Dal && dotnet ef database update" 
#Dotnet restore
echo "Dotnet restore"
docker exec -ti blog_web_1 sh -c "cd Blog.Web && dotnet restore"
echo "Dotnet build"
docker exec -ti blog_web_1 sh -c "cd Blog.Web && dotnet build"
#Run
docker exec -ti blog_web_1 sh -c "cd Blog.Web && dotnet bin/Debug/netcoreapp2.1/Blog.Web.dll --server.urls http://*:80"