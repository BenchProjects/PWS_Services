ARG CACHEBUSTER=3
FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY LoanService/LoanService.csproj LoanService/ 
COPY HelloWorldService/HelloWorldService.csproj HelloWorldService/
RUN dotnet restore LoanService/LoanService.csproj
RUN dotnet restore HelloWorldService/HelloWorldService.csproj
COPY . .
WORKDIR /src/HelloWorldService
RUN dotnet build HelloWorldService/HelloWorldService.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish HelloWorldService.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "HelloWorldService.dll"]
