#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WorkflowOrchestrator/WorkflowOrchestrator.API/WorkflowOrchestrator.API.csproj", "WorkflowOrchestrator/WorkflowOrchestrator.API/"]
RUN dotnet restore "WorkflowOrchestrator/WorkflowOrchestrator.API/WorkflowOrchestrator.API.csproj"

COPY ./WorkflowOrchestrator/ ./WorkflowOrchestrator/
COPY ./Manufacturing.Common/ ./Manufacturing.Common/

WORKDIR "WorkflowOrchestrator/WorkflowOrchestrator.API"
RUN dotnet build "WorkflowOrchestrator.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WorkflowOrchestrator.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WorkflowOrchestrator.API.dll"]