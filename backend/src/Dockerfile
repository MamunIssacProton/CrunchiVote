#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CrunchiVote.Api/CrunchiVote.Api.csproj", "CrunchiVote.Api/"]
COPY ["CrunchiVote.Identity/CrunchiVote.Identity.csproj", "CrunchiVote.Identity/"]
COPY ["CrunchiVote.Infrastructure/CrunchiVote.Infrastructure.csproj", "CrunchiVote.Infrastructure/"]
COPY ["CrunchiVote.Domain/CrunchiVote.Domain.csproj", "CrunchiVote.Domain/"]
COPY ["CrunchiVote.Shared/CrunchiVote.Shared.csproj", "CrunchiVote.Shared/"]
COPY ["CrunchiVote.Service/CrunchiVote.Service.csproj", "CrunchiVote.Service/"]
RUN dotnet restore "./CrunchiVote.Api/CrunchiVote.Api.csproj"
COPY . .
WORKDIR "/src/CrunchiVote.Api"
RUN dotnet build "./CrunchiVote.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CrunchiVote.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CrunchiVote.Api.dll"]