FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Dwapi.Mnch/Dwapi.Mnch.csproj", "Dwapi.Mnch/"]
RUN dotnet restore "src/Dwapi.Mnch/Dwapi.Mnch.csproj"
COPY . .
WORKDIR "/src/Dwapi.Mnch"
RUN dotnet build "Dwapi.Mnch.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Dwapi.Mnch.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dwapi.Mnch.dll"]
