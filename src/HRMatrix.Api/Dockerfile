FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ./HRMatrix.sln ./
COPY ./src/HRMatrix.Application/ ./HRMatrix.Application/
COPY ./src/HRMatrix.Persistence/ ./HRMatrix.Persistence/
COPY ./src/HRMatrix.Api/ ./HRMatrix.Api/
COPY ./src/HRMatrix.Domain/ ./HRMatrix.Domain/
COPY ./src/HRMatrix.IdentityService/ ./HRMatrix.IdentityService/

RUN dotnet restore "HRMatrix.Api/HRMatrix.Api.csproj"
RUN dotnet publish "HRMatrix.Api/HRMatrix.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "HRMatrix.Api.dll"]

 

#PS C:\Reps\HRMatrix\src\HRMatrix.Api> cd C:\Reps\HRMatrix
#docker build -t hommel5957/hrmatrix:latest_dev -f ./src/HRMatrix.Api/Dockerfile .
#docker push hommel5957/hrmatrix:latest_dev
#docker pull hommel5957/hrmatrix:latest_dev
#docker run -d --name hrmatrix_app --network hrmatrix-network -p 5000:8080 -e ASPNETCORE_ENVIRONMENT=Development --restart=always hommel5957/hrmatrix:latest_dev
