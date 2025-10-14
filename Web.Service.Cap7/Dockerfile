FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Web.Service.Cap7.csproj", "."]
RUN dotnet restore "Web.Service.Cap7.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "Web.Service.Cap7.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Web.Service.Cap7.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Web.Service.Cap7.dll"]
