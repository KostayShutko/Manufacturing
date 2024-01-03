#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Transportations/Transportations.API/Transportations.API.csproj", "Transportations/Transportations.API/"]
RUN dotnet restore "Transportations/Transportations.API/Transportations.API.csproj"

COPY ./Transportations/ ./Transportations/
COPY ./Manufacturing.Common/ ./Manufacturing.Common/

WORKDIR "Transportations/Transportations.API"
RUN dotnet build "Transportations.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Transportations.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Transportations.API.dll"]