FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Cronjob.Testing/Cronjob.Testing.csproj", "Cronjob.Testing/"]
RUN dotnet restore "Cronjob.Testing/Cronjob.Testing.csproj"
COPY . .
WORKDIR "/src/Cronjob.Testing"
RUN dotnet build "Cronjob.Testing.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Cronjob.Testing.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cronjob.Testing.dll"]
