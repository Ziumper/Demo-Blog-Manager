docker-compose -f docker-compose.yml -f docker-compose.dev.yml up --build -d

docker exec -ti blog_web_1 sh -c "cd Blog.Dal &&
 dotnet ef database update && cd ../Blog.Web && 
 dotnet bin/Debug/netcoreapp2.1/Blog.Web.dll --server.urls http://*:80"