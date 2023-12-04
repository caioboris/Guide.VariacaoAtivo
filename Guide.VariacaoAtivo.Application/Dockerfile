#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Guide.VariacaoAtivo.Application/Guide.VariacaoAtivo.Application.csproj", "Guide.VariacaoAtivo.Application/"]
COPY ["Guide.VariacaoAtivo.Data/Guide.VariacaoAtivo.Data.csproj", "Guide.VariacaoAtivo.Data/"]
COPY ["Guide.VariacaoAtivo.Domain/Guide.VariacaoAtivo.Domain.csproj", "Guide.VariacaoAtivo.Domain/"]
RUN dotnet restore "Guide.VariacaoAtivo.Application/Guide.VariacaoAtivo.Application.csproj"
COPY . .
WORKDIR "/src/Guide.VariacaoAtivo.Application"
RUN dotnet build "Guide.VariacaoAtivo.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Guide.VariacaoAtivo.Application.dll"]