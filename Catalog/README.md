## ASP DOTNET API DEMO

This project is to learn on using Dotnet core to build a simple CRUD web api with Mongo DB and Docker.

The mongoDB database in this project is running on docker, hence please install docker in order to use 
the build in mongoDB setting. The command to start the MongoDB docker image is:
` docker run -d --rm --name mongo -p 27017:27017 -v mogodbdata:/data/db mongo`