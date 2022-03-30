#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["NetCore-Tutorial/NetCore-Tutorial.csproj", "NetCore-Tutorial/"]
RUN dotnet restore "NetCore-Tutorial/NetCore-Tutorial.csproj"
COPY . .
WORKDIR "/src/NetCore-Tutorial"
RUN dotnet build "NetCore-Tutorial.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NetCore-Tutorial.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NetCore-Tutorial.dll"]