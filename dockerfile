FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

WORKDIR /app

COPY *.sln ./
COPY CostTracker.Api/*.csproj CostTracker.Api/
COPY CostTracker.Common/*.csproj CostTracker.Common/
COPY CostTracker.Core/*.csproj CostTracker.Core/
COPY CostTracker.Domain/*.csproj CostTracker.Domain/
COPY CostTracker.Infrastructure/*.csproj CostTracker.Infrastructure/

RUN dotnet restore

COPY CostTracker.Api/. CostTracker.Api/
COPY CostTracker.Common/. CostTracker.Common/
COPY CostTracker.Core/. CostTracker.Core/
COPY CostTracker.Domain/. CostTracker.Domain/
COPY CostTracker.Infrastructure/. CostTracker.Infrastructure/

WORKDIR /app/CostTracker.Api

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS runtime

WORKDIR /app

ENV ASPNETCORE_URLS=http://*:5000/

COPY --from=build /app/CostTracker.Api/out /app

ENTRYPOINT [ "dotnet", "CostTracker.Api.dll" ]