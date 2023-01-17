#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["GameStore.API/GameStore.API.csproj", "GameStore.API/"]
COPY ["GameStore.BLL/GameStore.BLL.csproj", "GameStore.BLL/"]
COPY ["GameStore.Common/GameStore.Common.csproj", "GameStore.Common/"]
COPY ["GameStore.DAL/GameStore.DAL.csproj", "GameStore.DAL/"]
RUN dotnet restore "GameStore.API/GameStore.API.csproj"
COPY . .
WORKDIR "/src/GameStore.API"
RUN dotnet build "GameStore.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GameStore.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GameStore.API.dll"]