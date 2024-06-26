#Start with the base .NET SDK Image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

#Set the working directory inside the container
WORKDIR /app

#Copy the project files and restore the depencies
COPY *.csproj ./
RUN dotnet nuget

#Copy the remainign files and build the application
COPY . ./
RUN dotnet publish -c Release -o out

#Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime-env
WORKDIR /app
COPY --from=build-env /app/out .

#set entry point 
ENTRYPOINT ["dotnet", "Safrasas.Api.dll"]