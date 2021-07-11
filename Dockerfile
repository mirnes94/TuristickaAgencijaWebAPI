FROM mcr.microsoft.com/dotnet/aspnet:3.1.15 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:3.1.409 AS build
WORKDIR /src
COPY ["./TuristickaAgencija.WebAPI/TuristickaAgencija.WebAPI.csproj", "TuristickaAgencija.WebAPI/"]

RUN dotnet restore "./TuristickaAgencija.WebAPI/TuristickaAgencija.WebAPI.csproj"
COPY . .
WORKDIR "/src/./TuristickaAgencija.WebAPI"
RUN dotnet build "./TuristickaAgencija.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish ./TuristickaAgencija.WebAPI.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .


ENTRYPOINT ["dotnet","TuristickaAgencija.WebAPI.dll"]