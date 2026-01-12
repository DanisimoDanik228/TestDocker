FROM mcr.microsoft.com/dotnet/sdk:9.0
WORKDIR /app
COPY . .
RUN dotnet publish "TestDocker/TestDocker.csproj" -c Release -o ./out
EXPOSE 8080 8081
ENTRYPOINT ["dotnet", "out/TestDocker.dll"]