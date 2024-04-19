FROM mcr.microsoft.com/dotnet/sdk:8.0 AS builder
WORKDIR /app1

COPY ./ ./

WORKDIR /app1/TorcTest.Api/


COPY TorcApiTest/*.csproj /app1/TorcApiTest/
COPY TorcLibraryWeb/*.csproj /app1/TorcLibraryWeb/
COPY TorcTest.Api/*.csproj /app1/TorcTest.Api/
COPY TorcTest.Application/*.csproj /app1/TorcTest.Application/
COPY TorcTest.Domain/*.csproj /app1/TorcTest.Domain/
COPY TorcTest.Infrastructure/*.csproj /app1/TorcTest.Infrastructure/

RUN dotnet restore


RUN dotnet publish -c Release -o ./../build

FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app1
COPY --from=builder /app1/build/ ./
ENTRYPOINT ["dotnet", "TorcTest.Api.dll"]
