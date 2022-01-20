FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["softius-task/softius-task.csproj", "softius-task/"]
RUN dotnet restore "softius-task/softius-task.csproj"
COPY . .
WORKDIR "/src/softius-task"
RUN dotnet build "softius-task.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "softius-task.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "softius-task.dll"]
