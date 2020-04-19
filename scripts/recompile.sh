echo "Killing dotnet process"
docker exec -ti blog_web_1 sh -c "bash scripts/kill.sh"
#Copy 
echo "copy files"
# docker cp ./Blog.Bll/Dto blog_web_1:/app/Blog.Bll/Dto
# docker cp ./Blog.Bll/Exceptions blog_web_1:/app/Blog.Bll/Exceptions
# docker cp ./Blog.Bll/Middlewares blog_web_1:/app/Blog.Bll/Middlewares
# docker cp ./Blog.Bll/Services blog_web_1:/app//Blog.Bll/Services
# docker cp ./Blog.Dal/Migrations blog_web_1:/app/Blog.Dal/Migrations
# docker cp ./Blog.Dal/Models blog_web_1:/app/Blog.Dal/Models
# docker cp ./Blog.Dal/Repositories blog_web_1:/app//Blog.Dal/Repositories
# docker cp ./Blog.Web/Controllers blog_web_1:/app/Blog.Web/Controllers
# docker cp ./Blog.Web/Mappings  blog_web_1:/app/Blog.Web/Mappings
echo "end copy files"
#Dotnet database update
#docker exec -ti blog_web_1 sh -c "cd Blog.Dal && dotnet ef database update" 
#Dotnet restore
echo "Dotnet restore"
docker exec -ti blog_web_1 sh -c "cd Blog.Web && dotnet restore"
echo "Dotnet build"
docker exec -ti blog_web_1 sh -c "cd Blog.Web && dotnet build"
#Run
docker exec -ti blog_web_1 sh -c "cd Blog.Web && dotnet bin/Debug/netcoreapp2.1/Blog.Web.dll --server.urls http://*:80"