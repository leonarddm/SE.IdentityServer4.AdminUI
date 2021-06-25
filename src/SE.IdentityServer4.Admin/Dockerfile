FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/SE.IdentityServer4.Admin/SE.IdentityServer4.Admin.csproj", "src/SE.IdentityServer4.Admin/"]
COPY ["src/SE.IdentityServer4.Admin.EntityFramework.Shared/SE.IdentityServer4.Admin.EntityFramework.Shared.csproj", "src/SE.IdentityServer4.Admin.EntityFramework.Shared/"]
COPY ["src/SE.IdentityServer4.Admin.EntityFramework.SqlServer/SE.IdentityServer4.Admin.EntityFramework.SqlServer.csproj", "src/SE.IdentityServer4.Admin.EntityFramework.SqlServer/"]
COPY ["src/SE.IdentityServer4.Admin.EntityFramework.PostgreSQL/SE.IdentityServer4.Admin.EntityFramework.PostgreSQL.csproj", "src/SE.IdentityServer4.Admin.EntityFramework.PostgreSQL/"]
COPY ["src/SE.IdentityServer4.Shared/SE.IdentityServer4.Shared.csproj", "src/SE.IdentityServer4.Shared/"]
COPY ["src/SE.IdentityServer4.Admin.EntityFramework.MySql/SE.IdentityServer4.Admin.EntityFramework.MySql.csproj", "src/SE.IdentityServer4.Admin.EntityFramework.MySql/"]
RUN dotnet restore "src/SE.IdentityServer4.Admin/SE.IdentityServer4.Admin.csproj"
COPY . .
WORKDIR "/src/src/SE.IdentityServer4.Admin"
RUN dotnet build "SE.IdentityServer4.Admin.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SE.IdentityServer4.Admin.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "SE.IdentityServer4.Admin.dll"]