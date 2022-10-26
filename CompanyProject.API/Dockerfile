#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CompanyProject.API/CompanyProject.API.csproj", "CompanyProject.API/"]
COPY ["CompanyProject.Repository/CompanyProject.Repository.csproj", "CompanyProject.Repository/"]
COPY ["CompanyProject.Domain/CompanyProject.Domain.csproj", "CompanyProject.Domain/"]
COPY ["CompanyProject.ViewModels/CompanyProject.ViewModels.csproj", "CompanyProject.ViewModels/"]
RUN dotnet restore "CompanyProject.API/CompanyProject.API.csproj"
COPY . .
WORKDIR "/src/CompanyProject.API"
RUN dotnet build "CompanyProject.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CompanyProject.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CompanyProject.API.dll"]