#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MiniBlog.App.ManageUI/MiniBlog.App.ManageUI.csproj", "MiniBlog.App.ManageUI/"]
RUN dotnet restore "MiniBlog.App.ManageUI/MiniBlog.App.ManageUI.csproj"
COPY . .
WORKDIR "/src/MiniBlog.App.ManageUI"
RUN dotnet build "MiniBlog.App.ManageUI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MiniBlog.App.ManageUI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MiniBlog.App.ManageUI.dll"]