FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["QuinielaFIFA2026.Web/QuinielaFIFA2026.Web.csproj", "QuinielaFIFA2026.Web/"]
RUN dotnet restore "QuinielaFIFA2026.Web/QuinielaFIFA2026.Web.csproj"
COPY . .
WORKDIR "/src/QuinielaFIFA2026.Web"
RUN dotnet publish "./QuinielaFIFA2026.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "QuinielaFIFA2026.Web.dll"]