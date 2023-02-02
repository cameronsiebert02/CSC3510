#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TestSalary/TestSalary.csproj", "TestSalary/"]
COPY ["InClass_2_2_Salart/InClass_2_2_Salart.csproj", "InClass_2_2_Salart/"]
RUN dotnet restore "TestSalary/TestSalary.csproj"
COPY . .
WORKDIR "/src/TestSalary"
RUN dotnet build "TestSalary.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestSalary.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestSalary.dll"]
