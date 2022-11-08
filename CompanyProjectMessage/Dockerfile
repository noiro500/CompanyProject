#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CompanyProjectMessage/CompanyProjectMessage.csproj", "CompanyProjectMessage/"]
RUN dotnet restore "CompanyProjectMessage/CompanyProjectMessage.csproj"
COPY . .
WORKDIR "/src/CompanyProjectMessage"
RUN dotnet build "CompanyProjectMessage.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CompanyProjectMessage.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CompanyProjectMessage.dll"]