FROM mcr.microsoft.com/dotnet/nightly/sdk:6.0 AS build
WORKDIR /AuthenticationAPI

EXPOSE 80
EXPOSE 5000

# COPY PROJECT FILES
COPY ./*.csproj ./
RUN dotnet restore

# COPY EVEYTHING ELSE
COPY ../* .
RUN dotnet publish -c Release -o out

# BUILD IMAGE
FROM mcr.microsoft.com/dotnet/nightly/sdk:6.0
WORKDIR /AuthenticationAPI
COPY --from=build /AuthenticationAPI/out .
ENTRYPOINT [ "dotnet", "Authentication.Backend.Infrastructure.API.dll" ]