FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/PetTransport.Web/PetTransport.Web.csproj", "PetTransport.Web/"]
RUN dotnet restore "src/PetTransport.Web/PetTransport.Web.csproj"
COPY . .
WORKDIR "/src/PetTransport.Web"
RUN dotnet build "PetTransport.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PetTransport.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PetTransport.Web.dll"]
