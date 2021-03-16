docker-compose -f docker-compose.yml -f docker-compose.dev.yml up --build -d
docker exec -ti blog_web_1 sh -c "bash scripts/entrypoint.sh"