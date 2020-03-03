FROM microsoft/dotnet:2.1-sdk
COPY . /app
WORKDIR /app/Blog.Web
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]
EXPOSE 80/tcp
#TODO Add runing from different catalog
RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh