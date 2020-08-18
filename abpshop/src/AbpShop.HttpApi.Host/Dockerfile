FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/AbpShop.HttpApi.Host/AbpShop.HttpApi.Host.csproj", "src/AbpShop.HttpApi.Host/"]
COPY ["src/AbpShop.EntityFrameworkCore.DbMigrations/AbpShop.EntityFrameworkCore.DbMigrations.csproj", "src/AbpShop.EntityFrameworkCore.DbMigrations/"]
COPY ["src/AbpShop.EntityFrameworkCore/AbpShop.EntityFrameworkCore.csproj", "src/AbpShop.EntityFrameworkCore/"]
COPY ["src/AbpShop.Domain/AbpShop.Domain.csproj", "src/AbpShop.Domain/"]
COPY ["src/AbpShop.Domain.Shared/AbpShop.Domain.Shared.csproj", "src/AbpShop.Domain.Shared/"]
COPY ["src/AbpShop.HttpApi/AbpShop.HttpApi.csproj", "src/AbpShop.HttpApi/"]
COPY ["src/AbpShop.Application.Contracts/AbpShop.Application.Contracts.csproj", "src/AbpShop.Application.Contracts/"]
COPY ["src/AbpShop.Application/AbpShop.Application.csproj", "src/AbpShop.Application/"]
RUN dotnet restore "src/AbpShop.HttpApi.Host/AbpShop.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/src/AbpShop.HttpApi.Host"
RUN dotnet build "AbpShop.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AbpShop.HttpApi.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AbpShop.HttpApi.Host.dll"]