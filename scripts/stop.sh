echo "Killing dotnet process"
docker exec -ti blog_web_1 sh -c "bash scripts/kill.sh"