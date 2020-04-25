#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MiniBlog.App.UI/MiniBlog.App.UI.csproj", "MiniBlog.App.UI/"]
RUN dotnet restore "MiniBlog.App.UI/MiniBlog.App.UI.csproj"
COPY . .
WORKDIR "/src/MiniBlog.App.UI"
RUN dotnet build "MiniBlog.App.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MiniBlog.App.UI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MiniBlog.App.UI.dll"]