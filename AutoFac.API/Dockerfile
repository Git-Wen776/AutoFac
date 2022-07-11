#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AutoFac.API/AutoFac.API.csproj", "AutoFac.API/"]
COPY ["AutoFac.Quartz/AutoFac.Quartz.csproj", "AutoFac.Quartz/"]
COPY ["AucoFac.Service/AucoFac.Service.csproj", "AucoFac.Service/"]
COPY ["AutoFac.Extentions/AutoFac.Extentions.csproj", "AutoFac.Extentions/"]
COPY ["AutoFac.Models/AutoFac.Models.csproj", "AutoFac.Models/"]
COPY ["AutoFac.Repository/AutoFac.Repository.csproj", "AutoFac.Repository/"]
COPY ["AutoFac.IRepository/AutoFac.IRepository.csproj", "AutoFac.IRepository/"]
RUN dotnet restore "AutoFac.API/AutoFac.API.csproj"
COPY . .
WORKDIR "/src/AutoFac.API"
RUN dotnet build "AutoFac.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AutoFac.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AutoFac.API.dll"]