FROM mcr.microsoft.com/dotnet/sdk:8.0 AS builder
WORKDIR /app1

COPY ./ ./

WORKDIR /app1/TorcTest.Api/

RUN dotnet restore


RUN dotnet publish -c Release -o ./../build

FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app1
COPY --from=builder /app1/build/ ./
ENTRYPOINT ["dotnet", "TorcTest.Api.dll"]
