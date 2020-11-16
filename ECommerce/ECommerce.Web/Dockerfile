#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
ENV ASPNETCORE_URLS "http://+:5000"
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ECommerce.Web/ECommerce.Web.csproj", "ECommerce.Web/"]
RUN dotnet restore "ECommerce.Web/ECommerce.Web.csproj"
COPY . .
WORKDIR "/src/ECommerce.Web"
RUN dotnet build "ECommerce.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ECommerce.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ECommerce.Web.dll"]