FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["IF-Tools/IF-Tools.csproj", "IF-Tools/"]
RUN dotnet restore "IF-Tools/IF-Tools.csproj"
COPY . .

WORKDIR "/src/IF-Tools"
RUN dotnet build "IF-Tools.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IF-Tools.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IF-Tools.dll"]
