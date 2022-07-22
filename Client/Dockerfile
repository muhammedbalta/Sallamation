FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY Shared Shared
COPY Client Client
WORKDIR /src/Client
RUN dotnet restore Sallamation.Client.csproj
RUN dotnet publish Sallamation.Client.csproj -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=build /app/publish/wwwroot .
COPY /Client/nginx.conf /etc/nginx/nginx.conf
