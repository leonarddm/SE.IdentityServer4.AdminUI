FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/SE.IdentityServer4.STS.Identity/SE.IdentityServer4.STS.Identity.csproj", "src/SE.IdentityServer4.STS.Identity/"]
COPY ["src/SE.IdentityServer4.Admin.EntityFramework.Shared/SE.IdentityServer4.Admin.EntityFramework.Shared.csproj", "src/SE.IdentityServer4.Admin.EntityFramework.Shared/"]
COPY ["src/SE.IdentityServer4.Shared/SE.IdentityServer4.Shared.csproj", "src/SE.IdentityServer4.Shared/"]
RUN dotnet restore "src/SE.IdentityServer4.STS.Identity/SE.IdentityServer4.STS.Identity.csproj"
COPY . .
WORKDIR "/src/src/SE.IdentityServer4.STS.Identity"
RUN dotnet build "SE.IdentityServer4.STS.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SE.IdentityServer4.STS.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "SE.IdentityServer4.STS.Identity.dll"]