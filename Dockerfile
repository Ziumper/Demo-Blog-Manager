FROM microsoft/dotnet:2.1-sdk

#Install node
RUN curl -sL https://deb.nodesource.com/setup_10.x |  bash -
RUN apt-get install -y nodejs
RUN apt-get install -y dos2unix

COPY . /app

WORKDIR /app
RUN dos2unix ./scripts/*

#Restore .net dependencies and build 
WORKDIR /app/Blog.Web
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]

EXPOSE 80/tcp

WORKDIR /app
RUN chmod +x scripts/kill.sh
